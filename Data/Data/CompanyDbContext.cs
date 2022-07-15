using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-O0M8V28\\SQLEXPRESS;Initial Catalog=DreamCompanyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Initialize
            modelBuilder.Entity<User>().HasData(
                new User() 
                { 
                    Id = 1, 
                    Name = "Vlad", 
                    Surname = "Tymo", 
                    Email = "rejv434@gmail.com", 
                    BirthDate = DateTime.Now 
                },
                new User() { Id = 2, Name = "Bob", Surname = "Bobovich", Email = "super4344@gmail.com", BirthDate = DateTime.Now },
                new User() { Id = 3, Name = "Igor", Surname = "Rufer", Email = "hgkkkkff@gmail.com", BirthDate = DateTime.Now }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "iPhone X",
                    Description = "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor.",
                    Price= 650,
                    Rating = 8.2F
                },
                new Product()
                {
                    Id = 2,
                    Name = "Lenovo G580",
                    Description = "Summary ; performanceCore i3 2nd Gen, 2.4 Ghz, 4 GB RAM ; design15.6 inches, 1366 x 768 , 2.7 Kg, 34.3 mm thick ; storage320 GB HDD, SATA, 5400 RPM.",
                    Price = 200,
                    Rating = 6.5F
                },
                new Product()
                {
                    Id = 3,
                    Name = "Monitor LG G6",
                    Description = "LG's Monitor allows you to maximize work efficiency and bring other practical benefits to your workplace with advanced and unique solutions. Learn more now.",
                    Price = 440,
                    Rating = 7.7F
                }
            );
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
