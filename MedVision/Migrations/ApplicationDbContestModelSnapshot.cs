﻿// <auto-generated />
using System;
using MedVision;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedVision.Migrations
{
    [DbContext(typeof(ApplicationDbContest))]
    partial class ApplicationDbContestModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CitaMotivoCita", b =>
                {
                    b.Property<int>("CitasId")
                        .HasColumnType("int");

                    b.Property<int>("MotivosCitaId")
                        .HasColumnType("int");

                    b.HasKey("CitasId", "MotivosCitaId");

                    b.HasIndex("MotivosCitaId");

                    b.ToTable("CitaMotivoCita");
                });

            modelBuilder.Entity("MedVision.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraCita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("Lugar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("MedVision.Models.MotivoCita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MotivosCita");
                });

            modelBuilder.Entity("MedVision.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("CitaMotivoCita", b =>
                {
                    b.HasOne("MedVision.Models.Cita", null)
                        .WithMany()
                        .HasForeignKey("CitasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedVision.Models.MotivoCita", null)
                        .WithMany()
                        .HasForeignKey("MotivosCitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedVision.Models.Cita", b =>
                {
                    b.HasOne("MedVision.Models.Persona", "Persona")
                        .WithMany("Citas")
                        .HasForeignKey("PersonaId");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("MedVision.Models.Persona", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
