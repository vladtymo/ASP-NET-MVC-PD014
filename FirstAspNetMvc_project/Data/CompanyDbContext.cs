using FirstAspNetMvc_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
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
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
