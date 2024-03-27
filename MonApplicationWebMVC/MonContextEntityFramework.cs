using Microsoft.EntityFrameworkCore;
using MonApplicationWebMVC.Models;

namespace MonApplicationWebMVC.Data
{
    public class MonContextEntityFramework : DbContext
    {
        public virtual DbSet<Pays> Pays { get; set; }
    }
}
