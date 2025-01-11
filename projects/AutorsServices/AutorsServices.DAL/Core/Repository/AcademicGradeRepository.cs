using AutorsServices.DAL.Context;
using AutorsServices.DAL.Core.Interfaces;
using AutorsServices.DAL.Entities;

namespace AutorsServices.DAL.Core.Repository
{
    public class AcademicGradeRepository : BaseRepository<AcademicGrade>, IAcademicGradeRepository
    {
        public AcademicGradeRepository(AutorDbContext context) : base(context)
        {
        }
    }
}
