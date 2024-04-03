namespace Elham.OrderManagement.Model
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public IList<Order> Orders { get; set; }
    }
}
