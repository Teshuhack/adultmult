using AdultMult.Models;
using Microsoft.EntityFrameworkCore;

namespace AdultMult.DataProvider
{
    public class AdultMultContext : DbContext
    {
        public AdultMultContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Mult> Mults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mult>(entity =>
            {
                entity.ToTable("mults");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.RussianCaption)
                    .HasColumnName("russiancaption")
                    .IsRequired();

                entity.Property(x => x.EnglishCaption)
                    .HasColumnName("englishcaption")
                    .IsRequired();

                entity.Property(x => x.Series)
                    .HasColumnName("series")
                    .IsRequired();

                entity.Property(x => x.Thumbnail)
                    .HasColumnName("thumbnail")
                    .IsRequired();
            });
        }
    }
}
