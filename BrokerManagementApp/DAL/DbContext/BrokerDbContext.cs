using Microsoft.EntityFrameworkCore;
using BrokerManagementApp.Models;

namespace BrokerManagementApp.DAL
{
    public class BrokerDbContext : DbContext
    {
        public BrokerDbContext(DbContextOptions<BrokerDbContext> options) : base(options)
        {
        }

        public DbSet<Broker> Brokers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can configure additional settings for your entities here
            // Example: modelBuilder.Entity<Broker>().Property(v => v.FirstName).IsRequired();
        }
    }
}