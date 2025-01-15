using AutoMapper;
using BookServices.BLL.Features.Books.Commands.Create;
using BookServices.BLL.Features.Books.Queries.GetAll;
using BooksServies.DAL.Core.Shared;
using BooksServies.DAL.Core.UnitOfWork;
using BooksServies.DAL.Entites;
using GenFu;
using Moq;
using System.Linq.Expressions;
using System.Net;

namespace BooksServices.Test
{
    public class BookServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetAllBooksQueryHandler _handler;
        private readonly CreateBookCommandHandler _createHandler;

        public BookServiceTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingTest());
            });
            var mapper = mapperConfig.CreateMapper();
            _handler = new GetAllBooksQueryHandler(_unitOfWorkMock.Object, _mapperMock.Object);
            _createHandler = new CreateBookCommandHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetAllBooks()
        {
            var fakeBooks = A.ListOf<MaterialBooks>(5);
            foreach (var book in fakeBooks)
            {
                book.AutorId = Guid.NewGuid();
                book.Id = Guid.NewGuid();
                book.Title = $"Title {A.Random.Next(1, 100)}";
                book.PublishDate = DateTime.Now;
            }

            var fakeBookDtos = fakeBooks.Select(book => new GetAllBooksDto
            {
                Title = book.Title,
                PublishDate = book.PublishDate
            }).ToList();

            _unitOfWorkMock
                .Setup(u => u.Books.GetAllAsync(
                    It.IsAny<PaginationArguments>(),
                    It.IsAny<bool>(),
                    It.IsAny<Expression<Func<MaterialBooks, bool>>>(),
                    null,
                    null))
                .ReturnsAsync(fakeBooks);

            _mapperMock
                .Setup(m => m.Map<List<GetAllBooksDto>>(fakeBooks))
                .Returns(fakeBookDtos);

            var result = await _handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            // Assert: Verificar el resultado
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(fakeBookDtos, result.Payload);

            // Verificar interacciones con mocks
            _unitOfWorkMock.Verify(u => u.Books.GetAllAsync(
                It.IsAny<PaginationArguments>(),
                It.IsAny<bool>(),
                It.IsAny<Expression<Func<MaterialBooks, bool>>>(),
                null,
                null), Times.Once);

            _mapperMock.Verify(m => m.Map<List<GetAllBooksDto>>(fakeBooks), Times.Once);
        }

        [Fact]
        public async Task CreateBook()
        {
            // Arrange
            var fakeBookCommand = new CreateBookCommand
            {
                Title = "Test Book Title",
                PublishDate = DateTime.UtcNow,
                AutorId = Guid.NewGuid()
            };

            var fakeBookEntity = new MaterialBooks
            {
                Title = fakeBookCommand.Title,
                PublishDate = fakeBookCommand.PublishDate,
                AutorId = fakeBookCommand.AutorId,
                Id = Guid.NewGuid()
            };

            _unitOfWorkMock
                .Setup(u => u.Books.CreateAsync(It.IsAny<MaterialBooks>()))
                .Callback<MaterialBooks>(b =>
                {
                    b.Id = fakeBookEntity.Id;
                })
                .Returns(Task.CompletedTask);

            _unitOfWorkMock
                .Setup(u => u.CompleteAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _createHandler.Handle(fakeBookCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            Assert.True((bool)result.Payload!);

            _unitOfWorkMock.Verify(u => u.Books.CreateAsync(It.Is<MaterialBooks>(b =>
                b.Title == fakeBookCommand.Title &&
                b.PublishDate == fakeBookCommand.PublishDate &&
                b.AutorId == fakeBookCommand.AutorId
            )), Times.Once);

            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }
    }
}
