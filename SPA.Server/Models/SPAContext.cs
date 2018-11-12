using Microsoft.EntityFrameworkCore;

namespace SPA.Server.Models
{
    public partial class SPAContext : DbContext
    {
        public SPAContext()
        {
        }

        public SPAContext(DbContextOptions<SPAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<GlobalTerm> GlobalTerm { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Term> Term { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<WorkerRole> WorkerRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Client__PersonId__628FA481");
            });

            modelBuilder.Entity<GlobalTerm>(entity =>
            {
                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OpenSaloon).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__RoleId__6754599E");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Person__LoginId__5FB337D6");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__TermId__7A672E12");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Done).HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Term)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Term__ClientId__73BA3083");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Term)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Term__OfferId__74AE54BC");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Term)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Term__WorkerId__75A278F5");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Worker)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Worker__PersonId__6A30C649");
            });

            modelBuilder.Entity<WorkerRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.WorkerRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkerRol__RoleI__7D439ABD");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.WorkerRole)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkerRol__Worke__7E37BEF6");
            });
        }
    }
}
