using Elham.OrderManagement.Data;
using Elham.OrderManagement.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elham.OrderManagement.Service
{
    internal class OrderService: IOrderService
    {
        private readonly Context _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(Context context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create()
        {
            Console.WriteLine("Enter order name: (non for exit)");
            string? orderName = Console.ReadLine();
            if (orderName.Equals("non"))
                return;

            Order order = new Order()
            {
                Name = orderName,
                CustomerId = 1
            };

            //add entitiy to the context
            _context.Orders.Add(order);
            //save data to the database tables
            _context.SaveChanges();

            _logger.LogInformation("Create Order");
        }

        public void Update()
        {
            var order = new Order() { Id = 1, Name="custom order" };

            _context.Orders.Update(order);
            ////save data to the database tables
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var order = _context.Orders.Single(x => x.Id == id);

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void GetList()
        {
            var orderList = _context.Orders.Where(x => x.Id > 0)
                .ToList();

            foreach (var item in orderList)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
            }
        }

        public void Get(int id)
        {

            var order = _context.Orders.Single(x => x.Id == id);

            Console.WriteLine($"Id: {order.Id}, Name: {order.Name}");

        }
    }
}
