using Microsoft.EntityFrameworkCore;
using QuarterApp.Core.Entities;
using QuarterApp.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
