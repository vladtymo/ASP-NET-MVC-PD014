using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public static class Seeder
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole() { Id = (int)Roles.User, Name = "User" },
                new ApplicationRole() { Id = (int)Roles.Manager, Name = "Manager" },
                new ApplicationRole() { Id = (int)Roles.Moderator, Name = "Moderator" },
                new ApplicationRole() { Id = (int)Roles.Administrator, Name = "Administrator" }
            );
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category() { Id = (int)Categories.Fashion, Name = "Fashion" },
               new Category() { Id = (int)Categories.Electronics, Name = "Electronics" },
               new Category() { Id = (int)Categories.Art, Name = "Art" },
               new Category() { Id = (int)Categories.Musical, Name = "Musical" },
               new Category() { Id = (int)Categories.HomeAndGarder, Name = "Home & Garder" },
               new Category() { Id = (int)Categories.AutoParts, Name = "Auto Parts" },
               new Category() { Id = (int)Categories.Sport, Name = "Sport" },
               new Category() { Id = (int)Categories.ToysAndHobbies, Name = "Toys & Hobbies" }
           );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Name = "Vlad",
                    Surname = "Tymo",
                    Email = "rejv434@gmail.com",
                    BirthDate = DateTime.Now,
                    RoleId = (int)Roles.Moderator
                },
                new ApplicationUser() { Name = "Bob", Surname = "Bobovich", Email = "super4344@gmail.com", BirthDate = DateTime.Now },
                new ApplicationUser() { Name = "Igor", Surname = "Rufer", Email = "hgkkkkff@gmail.com", BirthDate = DateTime.Now }
            );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "iPhone X",
                    Description = "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor.",
                    Price = 650,
                    Rating = 8.2F,
                    CategoryId = (int)Categories.Electronics
                },
                new Product()
                {
                    Id = 2,
                    Name = "Lenovo G580",
                    Description = "Summary ; performanceCore i3 2nd Gen, 2.4 Ghz, 4 GB RAM ; design15.6 inches, 1366 x 768 , 2.7 Kg, 34.3 mm thick ; storage320 GB HDD, SATA, 5400 RPM.",
                    Price = 200,
                    Rating = 6.5F,
                    CategoryId = (int)Categories.Electronics
                },
                new Product()
                {
                    Id = 3,
                    Name = "Monitor LG G6",
                    Description = "LG's Monitor allows you to maximize work efficiency and bring other practical benefits to your workplace with advanced and unique solutions. Learn more now.",
                    Price = 440,
                    Rating = 7.7F,
                    CategoryId = (int)Categories.Electronics
                },
                new Product()
                {
                    Id = 4,
                    Name = "T-Shirt Nike",
                    Description = "A T-shirt, or tee, is a style of fabric shirt named after the T shape of its body and sleeves.",
                    Price = 80,
                    Rating = 8,
                    CategoryId = (int)Categories.Fashion
                }
            );
        }
    }
}
