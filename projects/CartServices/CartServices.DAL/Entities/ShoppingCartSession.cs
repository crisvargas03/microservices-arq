namespace CartServices.DAL.Entities
{
    public class ShoppingCartSession
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }

        public ICollection<ShoppingCartSessionDetails>? Details { get; set; }
    }
}
