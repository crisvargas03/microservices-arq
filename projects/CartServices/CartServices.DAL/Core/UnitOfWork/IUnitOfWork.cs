using CartServices.DAL.Core.Interfaces;

namespace CartServices.DAL.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IShoppingCartRepository ShoppingCart { get; }
        IShoppingCartDetailsRepository ShoppingCartDetails { get; }

        Task<int> CompleteAsync();
        void Dispose();
    }
}
