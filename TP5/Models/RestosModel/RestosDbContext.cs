using Microsoft.EntityFrameworkCore;

namespace RestoManager_YourName.Models.RestosModel
{
    public class RestosDbContext : DbContext
    {
        public RestosDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Avis> Avis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Proprietaire configuration
            modelBuilder.Entity<Proprietaire>(entity =>
            {
                entity.ToTable("TProprietaire", "resto");
                entity.HasKey(p => p.Numero);
                entity.Property(p => p.Nom).HasColumnName("NomProp").HasMaxLength(20).IsRequired();
                entity.Property(p => p.Email).HasColumnName("EmailProp").HasMaxLength(50).IsRequired();
                entity.Property(p => p.Gsm).HasColumnName("GsmProp").HasMaxLength(8).IsRequired();
            });

            // Restaurant configuration + Relation with Proprietaire
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("TRestaurant", "resto");
                entity.HasKey(r => r.CodeResto);
                entity.Property(r => r.NomResto).HasMaxLength(20).IsRequired();
                entity.Property(r => r.Specialite).HasColumnName("SpecResto").HasMaxLength(20).IsRequired().HasDefaultValue("Tunisienne");
                entity.Property(r => r.Ville).HasColumnName("VilleResto").HasMaxLength(20).IsRequired();
                entity.Property(r => r.Tel).HasColumnName("TelResto").HasMaxLength(8).IsRequired();

                entity.HasOne(r => r.LeProprio)
                      .WithMany(p => p.LesRestos)
                      .HasForeignKey(r => r.NumProp)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("Relation_Proprio_Restos");
            });

            // Avis configuration (added later in Step 7)
        }
    }
}