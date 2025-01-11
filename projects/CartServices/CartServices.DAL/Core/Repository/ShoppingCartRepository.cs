using CartServices.DAL.Context;
using CartServices.DAL.Core.Interfaces;
using CartServices.DAL.Entities;

namespace CartServices.DAL.Core.Repository
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCartSession>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ShoppingCartDbContext context) : base(context)
        {
        }
    }
}
