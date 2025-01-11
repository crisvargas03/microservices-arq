using CartServices.DAL.Context;
using CartServices.DAL.Core.Interfaces;
using CartServices.DAL.Entities;

namespace CartServices.DAL.Core.Repository
{
    public class ShoppingCartDetailsRepository : BaseRepository<ShoppingCartSessionDetails>, IShoppingCartDetailsRepository
    {
        public ShoppingCartDetailsRepository(ShoppingCartDbContext context) : base(context)
        {
        }
    }
}
