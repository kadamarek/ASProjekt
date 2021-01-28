using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASProjekt.Models
{
    public partial class ASProjektContext : DbContext
    {
        public ASProjektContext()
        {
        }

        public ASProjektContext(DbContextOptions<ASProjektContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Mechanic> Mechanics { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Marka)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumerRej).HasColumnName("Numer_rej");

                entity.Property(e => e.RokProdukcji).HasColumnName("Rok_produkcji");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_cars_clients");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mechanic>(entity =>
            {
                entity.ToTable("mechanics");

                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.ToTable("repairs");

                entity.Property(e => e.CarsId).HasColumnName("cars_id");

                entity.Property(e => e.DataNaprawy)
                    .HasColumnType("date")
                    .HasColumnName("Data_naprawy");

                entity.Property(e => e.MechanicId).HasColumnName("mechanic_id");

                entity.Property(e => e.NazwaNaprawy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nazwa_naprawy");

                entity.Property(e => e.OpisNaprawy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Opis_naprawy");

                entity.HasOne(d => d.Cars)
                    .WithMany(p => p.Repairs)
                    .HasForeignKey(d => d.CarsId)
                    .HasConstraintName("FK_repairs_cars");

                entity.HasOne(d => d.Mechanic)
                    .WithMany(p => p.Repairs)
                    .HasForeignKey(d => d.MechanicId)
                    .HasConstraintName("FK_repairs_mechanics");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
