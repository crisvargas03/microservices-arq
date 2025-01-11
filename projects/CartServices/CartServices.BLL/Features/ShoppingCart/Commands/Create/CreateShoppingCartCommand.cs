using CartServices.BLL.Models;
using MediatR;

namespace CartServices.BLL.Features.ShoppingCart.Commands.Create
{
    public class CreateShoppingCartCommand : IRequest<APIResponse>
    {
        public DateTime CreationDate { get; set; }
        public List<Guid> BooksToShop { get; set; } = [];
    }
}
