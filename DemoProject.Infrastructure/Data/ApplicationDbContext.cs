using DemoProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=12,Name="Science", DisplayOrder=56},
                new Category { Id = 13, Name = "Adventure", DisplayOrder = 58 },
                new Category { Id = 14, Name = "Geo", DisplayOrder = 59 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
