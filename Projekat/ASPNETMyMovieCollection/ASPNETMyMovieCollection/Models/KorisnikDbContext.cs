using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ASPNETMyMovieCollection.Models
{
    public class KorisnikDbContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}