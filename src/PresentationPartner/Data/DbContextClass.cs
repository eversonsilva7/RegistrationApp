using Microsoft.EntityFrameworkCore;
using PresentationPartner.Models;

namespace PresentationPartner.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Client Entity
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Document)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Email);

            modelBuilder.Entity<Client>()
                .Property(c => c.Cellphone);

            modelBuilder.Entity<Client>()
                .Property(c => c.CreatedAt);

            base.OnModelCreating(modelBuilder);
        }
    }
}
