using Microsoft.EntityFrameworkCore;
using inscription.Models;
using inscription.Models.Enums;

namespace inscription.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnneeScolaire>().HasData(
                new AnneeScolaire
                {
                    Id = 1,
                    Libelle = "2025-2026",
                    Statut = StatutAnneeScolaire.EnCours
                }
            );
        }
    }
}
