using clean.core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace clean.Data
{
    public class DataContext: DbContext
    {
        public DbSet<customer> Customers { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

        }

    }
}
