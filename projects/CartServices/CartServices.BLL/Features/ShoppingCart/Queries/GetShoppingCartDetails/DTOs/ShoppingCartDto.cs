namespace CartServices.BLL.Features.ShoppingCart.Queries.GetShoppingCartDetails.DTOs
{
    public class ShoppingCartDto
    {
        public Guid ShoppingCartId { get; set; }
        public DateTime CreateAt { get; set; }
        public List<ShoppingCartDetailsDto> Details { get; set; } = [];
    }
}
