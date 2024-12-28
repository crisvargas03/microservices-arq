namespace AutorsServices.DAL.Entities;

public class BookAutor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? Birthdate { get; set; }

    public ICollection<AcademicGrade>? AcademicGrades { get; set; }
}