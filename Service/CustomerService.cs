using Elham.OrderManagement.Data;
using Elham.OrderManagement.Model;
using Microsoft.Extensions.Logging;

namespace Elham.OrderManagement.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly Context _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(Context context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create()
        {
            Console.WriteLine("Enter Firstname: (non for exit)");
            string? firstName = Console.ReadLine();
            if (firstName.Equals("non"))
                return;

            Console.WriteLine("Enter Lastname:");
            string? lastName = Console.ReadLine();

            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName
            };

            //add entitiy to the context
            _context.Customers.Add(customer);
            ////save data to the database tables
            _context.SaveChanges();

            _logger.LogInformation("Create customer");
        }

        public void Update()
        {
            var customer = new Customer() { Id = 1, FirstName="Elham",LastName="Barari" };

            _context.Customers.Update(customer);
            ////save data to the database tables
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Single(x => x.Id == id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void GetList()
        {
            Console.WriteLine("==========================\nCustomerList");

            var customerList = _context.Customers.Where(x => x.Id > 0)
                .ToList();

            foreach (var item in customerList)
            {
                Console.WriteLine($"Id: {item.Id}, FullName: {item.FirstName} {item.LastName}");
            }
        }

        public void Get(int id)
        {

            var customer = _context.Customers.Single(x => x.Id == id);

            Console.WriteLine($"Id: {customer.Id}, FullName: {customer.FirstName} {customer.LastName}");

        }
    }
}
