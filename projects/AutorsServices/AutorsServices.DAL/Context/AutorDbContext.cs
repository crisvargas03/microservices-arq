using AutorsServices.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutorsServices.DAL.Context;

public class AutorDbContext: DbContext
{
    public AutorDbContext(DbContextOptions<AutorDbContext> options) : base(options) {}

    public DbSet<AcademicGrade> AcademicGrades => Set<AcademicGrade>();
    public DbSet<BookAutor> BookAutors => Set<BookAutor>();

}