using CartServices.BLL.Features.ExternalServices.Interfaces;
using CartServices.BLL.Features.ShoppingCart.Queries.GetShoppingCartDetails.DTOs;
using CartServices.BLL.Models;
using CartServices.DAL.Core.UnitOfWork;
using MediatR;
using System.Net;

namespace CartServices.BLL.Features.ShoppingCart.Queries.GetShoppingCartDetails
{
    public class GetShoppingCartDetailsQueryHandler : IRequestHandler<GetShoppingCartDetailsQuery, APIResponse>
    {
        private readonly IBookExternalServices _bookExternalServices;
        private readonly IUnitOfWork _unitOfWork;
        APIResponse _apiResponse;

        public GetShoppingCartDetailsQueryHandler(IBookExternalServices bookExternalServices, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookExternalServices = bookExternalServices;
            _apiResponse = new APIResponse();
        }

        public async Task<APIResponse> Handle(GetShoppingCartDetailsQuery request, CancellationToken cancellationToken)
        {
            var shoppingCartDetailsList = await _unitOfWork.ShoppingCartDetails
                .GetAllAsync(
                whereExpression: x => x.ShoppingCartSessionId == request.Id,
                paginationArguments: new());
            var shoppinCart = await _unitOfWork.ShoppingCart
                .GetAsync(whereExpression: x => x.Id == request.Id);

            if (shoppingCartDetailsList.Count == 0 || shoppinCart is null)
            {
                return _apiResponse
                    .FailedResponse(HttpStatusCode.NotFound, "Not found");
            }

            var listShoppingCartDetails = new List<ShoppingCartDetailsDto>();
            foreach (var item in shoppingCartDetailsList)
            {
                var bookResponse = await _bookExternalServices.GetById(Guid.Parse(item.SelectedBook));
                if (bookResponse.isSuccess)
                {
                    var shoppingcartDetails = new ShoppingCartDetailsDto
                    {
                        Title = bookResponse.payload.title,
                        PublishDate = bookResponse.payload.publishDate,
                        BookId = Guid.Parse(item.SelectedBook)
                    };
                    listShoppingCartDetails.Add(shoppingcartDetails);
                }
            }
            var shopingCartDto = new ShoppingCartDto
            {
               ShoppingCartId = shoppinCart.Id,
               CreateAt = shoppinCart.CreateAt,
               Details = listShoppingCartDetails
            };
            _apiResponse.Payload = shopingCartDto;
            return _apiResponse;
        }
    }
}
