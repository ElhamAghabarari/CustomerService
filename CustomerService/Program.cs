using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Elham.OrderManagement.Data;
using Elham.OrderManagement.Service;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            IHostBuilder builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices(services =>
            {
                services.AddDbContext<Context>(Opt =>
                {
                    Opt.UseSqlServer(configuration.GetConnectionString("OrderDBLocalConnection"));

                });

                services.AddTransient<ICustomerService, CustomerService>();
                services.AddTransient<IOrderService, OrderService>();
                services.AddLogging();
            });

            var host = builder.Build();


            var customerService = host.Services.GetService<ICustomerService>();
            customerService.GetList();

            var orderService = host.Services.GetService<IOrderService>();
            orderService.GetList();


            host.Run();
        }
    }
}