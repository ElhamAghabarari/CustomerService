namespace Elham.OrderManagement.Model
{
    public class Order
    {
        public Order()
        {
            
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
