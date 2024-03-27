using Microsoft.EntityFrameworkCore;
using MonApplicationWebMVC.Models;

namespace MonApplicationWebMVC.Data
{
    public class MonContextEntityFramework : DbContext
    {
        public virtual DbSet<Pays> Pays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pays>().HasKey(p => p.Id);
            modelBuilder.Entity<Pays>().Ignore(p => p.ImportDrapeau);
        }
    }
}
