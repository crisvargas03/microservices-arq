namespace BooksServies.DAL.Entites
{
    public class MaterialBooks
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? PublishDate { get; set; }
        public Guid AutorId { get; set; }
    }
}
