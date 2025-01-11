using CartServices.BLL.Models;
using CartServices.DAL.Core.UnitOfWork;
using CartServices.DAL.Entities;
using MediatR;
using System.Net;

namespace CartServices.BLL.Features.ShoppingCart.Commands.Create
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, APIResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        APIResponse _apiResponse;

        public CreateShoppingCartCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = new APIResponse();
        }
        
        public async Task<APIResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = new ShoppingCartSession
            {
                CreateAt = request.CreationDate
            };

            await _unitOfWork.ShoppingCart.CreateAsync(shoppingCart);

            foreach (var book in request.BooksToShop)
            {
                var shoppingCartDetails = new ShoppingCartSessionDetails
                {
                    CreatedAt = request.CreationDate,
                    ShoppingCartSessionId = shoppingCart.Id,
                    SelectedBook = book.ToString()
                };
                await _unitOfWork.ShoppingCartDetails.CreateAsync(shoppingCartDetails);
            }
            await _unitOfWork.CompleteAsync();
            var responseData = new { shoppingCart.Id };
            return _apiResponse.SuccesResponse(HttpStatusCode.Created, responseData);
        }
    }
}
