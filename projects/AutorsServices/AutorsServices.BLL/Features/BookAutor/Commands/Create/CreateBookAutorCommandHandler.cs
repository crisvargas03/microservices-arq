using AutorsServices.DAL.Core.UnitOfWork;
using MediatR;

namespace AutorsServices.BLL.Features.BookAutor.Commands.Create
{
    public class CreateBookAutorCommandHandler : IRequestHandler<CreateBookAutorCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookAutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateBookAutorCommand request, CancellationToken cancellationToken)
        {

            var bookAuthor = new DAL.Entities.BookAutor
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Birthdate = request.Birthdate!.Value.ToUniversalTime(),
            };

            await _unitOfWork.BookAutors.CreateAsync(bookAuthor);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
