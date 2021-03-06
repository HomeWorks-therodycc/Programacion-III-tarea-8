// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea7.Data.Models;

namespace Tarea7.Migrations
{
    [DbContext(typeof(vacunaContext))]
    [Migration("20210306171740_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Tarea7.Data.Models.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("provincias");
                });

            modelBuilder.Entity("Tarea7.Data.Models.Vacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("CantidadEntrante")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cantidad_entrante");

                    b.Property<int>("CantidadRestante")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cantidad_restante");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("marca");

                    b.HasKey("Id");

                    b.ToTable("vacunas");
                });

            modelBuilder.Entity("Tarea7.Data.Models.Vacunado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("apellido");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("cedula");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<double?>("Latitud")
                        .HasColumnType("REAL")
                        .HasColumnName("latitud");

                    b.Property<double?>("Longitud")
                        .HasColumnType("REAL")
                        .HasColumnName("longitud");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("provincia_id");

                    b.Property<string>("SignoZodiacal")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("signo_zodiacal");

                    b.Property<string>("Telefono")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("telefono");

                    b.Property<DateTime?>("Vacuna1Fecha")
                        .HasColumnType("TEXT")
                        .HasColumnName("vacuna1_fecha");

                    b.Property<int?>("Vacuna1Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vacuna1_id");

                    b.Property<DateTime?>("Vacuna2Fecha")
                        .HasColumnType("TEXT")
                        .HasColumnName("vacuna2_fecha");

                    b.Property<int?>("Vacuna2Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vacuna2_id");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.HasIndex("Vacuna1Id");

                    b.HasIndex("Vacuna2Id");

                    b.HasIndex(new[] { "Cedula" }, "IX_vacunados_cedula")
                        .IsUnique();

                    b.ToTable("vacunados");
                });

            modelBuilder.Entity("Tarea7.Data.Models.Vacunado", b =>
                {
                    b.HasOne("Tarea7.Data.Models.Provincia", "Provincia")
                        .WithMany("Vacunados")
                        .HasForeignKey("ProvinciaId")
                        .IsRequired();

                    b.HasOne("Tarea7.Data.Models.Vacuna", "Vacuna1")
                        .WithMany("VacunadoVacuna1s")
                        .HasForeignKey("Vacuna1Id");

                    b.HasOne("Tarea7.Data.Models.Vacuna", "Vacuna2")
                        .WithMany("VacunadoVacuna2s")
                        .HasForeignKey("Vacuna2Id");

                    b.Navigation("Provincia");

                    b.Navigation("Vacuna1");

                    b.Navigation("Vacuna2");
                });

            modelBuilder.Entity("Tarea7.Data.Models.Provincia", b =>
                {
                    b.Navigation("Vacunados");
                });

            modelBuilder.Entity("Tarea7.Data.Models.Vacuna", b =>
                {
                    b.Navigation("VacunadoVacuna1s");

                    b.Navigation("VacunadoVacuna2s");
                });
#pragma warning restore 612, 618
        }
    }
}
