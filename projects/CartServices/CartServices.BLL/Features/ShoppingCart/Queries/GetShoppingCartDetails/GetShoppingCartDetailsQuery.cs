using CartServices.BLL.Models;
using MediatR;

namespace CartServices.BLL.Features.ShoppingCart.Queries.GetShoppingCartDetails
{
    public class GetShoppingCartDetailsQuery : IRequest<APIResponse>
    {
        public Guid Id { get; set; }
    }
}
