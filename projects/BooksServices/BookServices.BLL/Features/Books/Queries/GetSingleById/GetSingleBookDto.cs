namespace BookServices.BLL.Features.Books.Queries.GetSingleById
{
    public class GetSingleBookDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime? PublishDate { get; set; }
        public Guid AutorId { get; set; }
    }
}
