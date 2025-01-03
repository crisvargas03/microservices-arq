using CartServices.DAL.Context;
using CartServices.DAL.Core.Interfaces;
using CartServices.DAL.Core.Repository;

namespace CartServices.DAL.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ShoppingCartDbContext _context;

        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IShoppingCartDetailsRepository ShoppingCartDetails { get; private set; }

        public UnitOfWork(ShoppingCartDbContext context)
        {
            _context = context;
            ShoppingCart = new ShoppingCartRepository(_context);
            ShoppingCartDetails = new ShoppingCartDetailsRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}