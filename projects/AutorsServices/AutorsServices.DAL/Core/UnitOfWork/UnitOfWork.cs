using AutorsServices.DAL.Context;
using AutorsServices.DAL.Core.Interfaces;
using AutorsServices.DAL.Core.Repository;

namespace AutorsServices.DAL.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AutorDbContext _context;

        public IBookAutorRepository BookAutors { get; private set; }
        public IAcademicGradeRepository AcademicGrades { get; private set; }

        public UnitOfWork(AutorDbContext context)
        {
            _context = context;
            BookAutors = new BookAutorRepository(_context);
            AcademicGrades = new AcademicGradeRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
