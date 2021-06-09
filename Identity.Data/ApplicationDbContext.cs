using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Identity.Domain.User;
using Identity.Domain;

namespace Identity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }

        public virtual DbSet<AddressEntity> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserEntity(modelBuilder.Entity<UserEntity>());
            ConfigureAddressEntity(modelBuilder.Entity<AddressEntity>());

            void ConfigureUserEntity(EntityTypeBuilder<UserEntity> etb)
            {
                etb.HasKey(x => x.Id);
                etb.Property(x => x.Id).ValueGeneratedOnAdd();

                etb.Property(x => x.FirstName).IsRequired();
                etb.Property(x => x.LastName).IsRequired();
                etb.Property(x => x.PasswordHash).IsRequired();
                etb.Property(x => x.Login).IsRequired();
                etb.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");

                etb.HasIndex(x => x.Login).IsUnique();

                etb.HasOne(x => x.Address)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Cascade);
            }

            void ConfigureAddressEntity(EntityTypeBuilder<AddressEntity> etb)
            {
                etb.HasKey(x => x.Id);
                etb.Property(x => x.Id).ValueGeneratedOnAdd();

                etb.Property(x => x.Country).IsRequired();
                etb.Property(x => x.City).IsRequired();
                etb.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");

                etb.HasIndex(x => x.Country);
            }
        }
    }
}