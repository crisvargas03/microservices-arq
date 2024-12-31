namespace CartServices.DAL.Entities
{
    public class ShoppingCartSessionDetails
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string SelectedBook { get; set; } = string.Empty;
        public Guid ShoppingCartSessionId { get; set; }

        public ShoppingCartSession? ShoppingCartSession { get; set; }
    }
}
