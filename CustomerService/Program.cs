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
                services.AddLogging();
            });

            var host = builder.Build();


            var executer = host.Services.GetService<ICustomerService>();
            executer.GetList();
                

            host.Run();
        }
    }
}