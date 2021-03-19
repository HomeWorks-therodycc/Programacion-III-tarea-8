using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tarea7.Data.Models
{
    public partial class vacunaContext : DbContext
    {
        public vacunaContext()
        {
        }

        public vacunaContext(DbContextOptions<vacunaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Vacuna> Vacunas { get; set; }
        public virtual DbSet<Vacunado> Vacunados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=vacuna.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.ToTable("provincias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.ToTable("vacunas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca");

                entity.Property(e => e.CantidadRestante).HasColumnName("cantidad_restante");
                
                entity.Property(e => e.CantidadEntrante).HasColumnName("cantidad_entrante");
            });

            modelBuilder.Entity<Vacunado>(entity =>
            {
                entity.ToTable("vacunados");

                entity.HasIndex(e => e.Cedula, "IX_vacunados_cedula")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasColumnName("cedula");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired()
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.SignoZodiacal)
                    .IsRequired()
                    .HasColumnName("signo_zodiacal");

                entity.Property(e => e.ProvinciaId).HasColumnName("provincia_id");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono");

                entity.Property(e => e.Vacuna1Fecha).HasColumnName("vacuna1_fecha");

                entity.Property(e => e.Vacuna1Id).HasColumnName("vacuna1_id");

                entity.Property(e => e.Vacuna2Fecha).HasColumnName("vacuna2_fecha");

                entity.Property(e => e.Vacuna2Id).HasColumnName("vacuna2_id");

                entity.Property(e => e.Latitud)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasColumnName("longitud");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Vacunados)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vacuna1)
                    .WithMany(p => p.VacunadoVacuna1s)
                    .HasForeignKey(d => d.Vacuna1Id);

                entity.HasOne(d => d.Vacuna2)
                    .WithMany(p => p.VacunadoVacuna2s)
                    .HasForeignKey(d => d.Vacuna2Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
