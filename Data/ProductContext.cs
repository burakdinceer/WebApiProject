using Microsoft.EntityFrameworkCore;
using Ornek2.Api.Models;

namespace Ornek2.Api.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options ) : base( options )
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new() { Id = 1, Name ="Bilgisayar", Price=15000, Stock=100 },
                new() { Id = 2, Name ="Klavye", Price =5000,Stock=50},
                new() { Id = 3, Name ="Mouse", Price =1000,Stock=200}
            });
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }

    }
}
