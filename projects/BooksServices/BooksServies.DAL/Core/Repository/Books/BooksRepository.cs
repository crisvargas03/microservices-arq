using BooksServies.DAL.Context;
using BooksServies.DAL.Core.Interfaces.Books;
using BooksServies.DAL.Entites;

namespace BooksServies.DAL.Core.Repository.Books
{
    public class BooksRepository : BaseRepository<MaterialBooks>, IBooksRepository
    {
        public BooksRepository(BookDbContext context) : base(context)
        {
        }
    }
}
