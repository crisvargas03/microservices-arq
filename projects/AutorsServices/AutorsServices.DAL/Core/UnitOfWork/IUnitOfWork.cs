using AutorsServices.DAL.Core.Interfaces;

namespace AutorsServices.DAL.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAcademicGradeRepository AcademicGrades { get; }
        IBookAutorRepository BookAutors { get; }

        Task CompleteAsync();
        void Dispose();
    }
}
