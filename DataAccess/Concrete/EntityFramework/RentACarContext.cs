using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-4886AGDL\SQLEXPRESS;Database=RentACar;Trusted_Connection=True");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentMapping veri tabanı oluştururken bundan sonra dikkatli olunacak AutoMapping yapılamsına özen göstrilecek.
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Brand>().Property(b => b.BrandId).HasColumnName("BrandsId");
            modelBuilder.Entity<Brand>().Property(b => b.BrandName).HasColumnName("Name");
           
            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<Color>().Property(b => b.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Color>().Property(b => b.ColorName).HasColumnName("Name");
        }
       

    }
}
