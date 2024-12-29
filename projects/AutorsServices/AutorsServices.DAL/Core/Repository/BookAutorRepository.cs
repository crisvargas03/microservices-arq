using AutorsServices.DAL.Context;
using AutorsServices.DAL.Core.Interfaces;
using AutorsServices.DAL.Entities;

namespace AutorsServices.DAL.Core.Repository
{
    public class BookAutorRepository : BaseRepository<BookAutor>, IBookAutorRepository
    {
        public BookAutorRepository(AutorDbContext context) : base(context)
        {
        }
    }
}
