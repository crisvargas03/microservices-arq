namespace AutorsServices.DAL.Entities;

public class AcademicGrade
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CollageName { get; set; } = string.Empty;
    public DateTime? FinishedDate  { get; set; }
    
    public Guid AutorId { get; set; }
    public  BookAutor Autor { get; set; }
}