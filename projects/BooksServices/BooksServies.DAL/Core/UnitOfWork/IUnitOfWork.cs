using BooksServies.DAL.Context;
using BooksServies.DAL.Core.Interfaces.Books;

namespace BooksServies.DAL.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBooksRepository Books { get; }

        Task<int> CompleteAsync();
        void Dispose();
    }
}
