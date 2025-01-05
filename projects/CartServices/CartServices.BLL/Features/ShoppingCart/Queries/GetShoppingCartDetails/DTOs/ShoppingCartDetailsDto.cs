namespace CartServices.BLL.Features.ShoppingCart.Queries.GetShoppingCartDetails.DTOs
{
    public class ShoppingCartDetailsDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
    }
}
