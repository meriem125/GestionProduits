using Microsoft.EntityFrameworkCore;
using MonProjetFac.Models;

namespace MonProjetFac.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding ta' el Categories
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Nom = "Informatique" },
                new Categorie { Id = 2, Nom = "Bureau" }
            );
        }
    }
}