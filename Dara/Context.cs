using Elham.OrderManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace Elham.OrderManagement.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
        }

        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
        //        .EnableSensitiveDataLogging();
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            //Write Fluent API configurations here

            // Property Configurations
            //modelBuilder.Entity<Customer>()
            //    .Property(c => c.CustomerId)
            //    .HasDefaultValue(0)
            //    .IsRequired();

            //modelBuilder.Entity<Order>()
            //    .Property(o => o.OrderId)
            //    .HasDefaultValue(0)
            //    .IsRequired();

            // one-to-many relationship
            //modelBuilder.Entity<Customer>()
            //    .HasMany<Order>(c => c.Orders)
            //    .WithOne(o => o.Customer)
            //    .HasForeignKey(o => o.CustomerId);

            // or
            //modelBuilder.Entity<Order>()
            //    .HasOne<Customer>(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId);

            //shadow
            //modelBuilder.Entity<Order>().Property<DateTime>("CreatedDate");
            //modelBuilder.Entity<Order>().Property<DateTime>("UpdatedDate");
        //}

        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker
        //        .Entries<Order>()
        //        .Where(e =>
        //                e.State == EntityState.Added
        //                || e.State == EntityState.Modified);

        //    foreach (var entityEntry in entries)
        //    {
        //        entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
        //        }
        //    }

        //    return base.SaveChanges();
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
