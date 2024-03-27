using Microsoft.EntityFrameworkCore;
using MonApplicationWebMVC.Models;

namespace MonApplicationWebMVC.Data
{
    public class MonContextEntityFramework : DbContext
    {
        private string Filepath;
        public MonContextEntityFramework()
        {
            Filepath = "localDb.db";
        }
        // Ici un autre methode pour ajouter le Filpath mais que ne marche pas dans le context actuelle. 
        //
        //public MonContextEntityFramework(string filpath = null)
        //{
        //    if (filpath != null) { Filepath = filpath; }
        //    else 
        //    {
        //        WebApplication app = builder.Build(); => A effectuer dasn le Program. cs qui defini builder.
        //        string Filepath = Path.Combine(app.Environment.ContentRootPath,"localDb.db");
        //       
        //    }
        //}
        public virtual DbSet<Pays> Pays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pays>().HasKey(p => p.Id);
            modelBuilder.Entity<Pays>().Ignore(p => p.ImportDrapeau);
            base.OnModelCreating(modelBuilder);
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Filepath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
