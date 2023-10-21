using Microsoft.EntityFrameworkCore;

namespace ProjeComplatedFull1.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dersler> Dersler { get; set; }
        public virtual DbSet<Notlar> Not { get; set; }
        public virtual DbSet<Roller> Rol { get; set; }


    }

}
