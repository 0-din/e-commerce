namespace Core.Entities
{
    public class Order: BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}