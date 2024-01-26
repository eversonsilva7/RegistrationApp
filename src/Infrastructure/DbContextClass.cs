namespace Infrastructure
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbContextClass : DbContext
    {
        public DbContextClass()
        {
        }

        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
        }

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

            modelBuilder.Entity<Client>()
                .Property(c => c.UpdatedAt);

            // Integration Entity
            modelBuilder.Entity<Integration>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Integration>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Integration>()
                .Property(i => i.Status)
                .IsRequired();

            modelBuilder.Entity<Integration>()
                .Property(i => i.Error);

            modelBuilder.Entity<Integration>()
                .Property(i => i.ClientId);

            modelBuilder.Entity<Integration>()
                .HasOne(i => i.Client)
                .WithMany(i => i.Integrations)
                .HasForeignKey(i => i.ClientId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Integration> Integrations { get; set; }
    }
}
