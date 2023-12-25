using Microsoft.EntityFrameworkCore;
using StockMarket.Domain.Entities;
using System.Collections;
using System.Reflection.Emit;

namespace StockMarket.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Stock)
                .WithMany()
                .HasForeignKey(o => o.StockId);
        }
    }

}
