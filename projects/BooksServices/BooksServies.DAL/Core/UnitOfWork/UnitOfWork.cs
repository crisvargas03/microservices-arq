using BooksServies.DAL.Context;
using BooksServies.DAL.Core.Interfaces.Books;
using BooksServies.DAL.Core.Repository.Books;

namespace BooksServies.DAL.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookDbContext _context;

        public IBooksRepository Books { get; private set; }

        public UnitOfWork(BookDbContext context)
        {
            _context = context;
            Books = new BooksRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
