namespace BookServices.BLL.Features.Books.Queries.GetAll
{
    public class GetAllBooksDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime? PublishDate { get; set; }
        public Guid AutorId { get; set; }
    }
}
