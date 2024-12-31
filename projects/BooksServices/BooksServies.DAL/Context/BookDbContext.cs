using BooksServies.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace BooksServies.DAL.Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<MaterialBooks> MaterialBooks => Set<MaterialBooks>();
    }
}
