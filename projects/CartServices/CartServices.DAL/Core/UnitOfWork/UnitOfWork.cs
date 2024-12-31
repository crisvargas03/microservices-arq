using CartServices.DAL.Context;

namespace CartServices.DAL.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ShoppingCartDbContext _context;

        // public IBooksRepository Books { get; private set; }

        public UnitOfWork(ShoppingCartDbContext context)
        {
            _context = context;
            // Books = new BooksRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}