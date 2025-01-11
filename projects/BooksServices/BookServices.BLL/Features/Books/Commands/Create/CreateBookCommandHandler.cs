using BookServices.BLL.Models;
using BooksServies.DAL.Core.UnitOfWork;
using BooksServies.DAL.Entites;
using MediatR;
using System.Net;

namespace BookServices.BLL.Features.Books.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, APIResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        APIResponse _apiResponse;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = new APIResponse();
        }

        public async Task<APIResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
                return _apiResponse.FailedResponse(HttpStatusCode.BadRequest, 
                    validationResult.Errors.FirstOrDefault()!.ErrorMessage);

            var newBook = new MaterialBooks
            {
                Title = request.Title,
                PublishDate = request.PublishDate,
                AutorId = request.AutorId,
            };
            await _unitOfWork.Books.CreateAsync(newBook);
            _ = await _unitOfWork.CompleteAsync();
            return _apiResponse.SuccesResponse(HttpStatusCode.Created, true);
        }
    }
}
