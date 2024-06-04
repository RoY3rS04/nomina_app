﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanillaSalarial.Data;

#nullable disable

namespace PlanillaSalarial.Migrations
{
    [DbContext(typeof(NominaContext))]
    [Migration("20240604203637_modifying_fields")]
    partial class modifying_fields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanillaSalarial.Models.Deducciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Anticipos")
                        .HasColumnType("float");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoId");

                    b.Property<double>("IR")
                        .HasColumnType("float");

                    b.Property<double>("Prestamos")
                        .HasColumnType("float");

                    b.Property<double>("SalarioBruto")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Deducciones");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodigoEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaTerminacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("INSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nacimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RUC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Ingresos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Bonos")
                        .HasColumnType("float");

                    b.Property<double>("Comision")
                        .HasColumnType("float");

                    b.Property<double>("Depreciacion")
                        .HasColumnType("float");

                    b.Property<int>("DiasExtras")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoId");

                    b.Property<int>("HorasExtras")
                        .HasColumnType("int");

                    b.Property<bool>("Nocturnidad")
                        .HasColumnType("bit");

                    b.Property<double>("RiesgoLaboral")
                        .HasColumnType("float");

                    b.Property<double>("SalarioOrdinario")
                        .HasColumnType("float");

                    b.Property<double>("Viatico")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Nomina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoId");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Nominas");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Deducciones", b =>
                {
                    b.HasOne("PlanillaSalarial.Models.Empleado", "Empleado")
                        .WithMany("Deducciones")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Ingresos", b =>
                {
                    b.HasOne("PlanillaSalarial.Models.Empleado", "Empleado")
                        .WithMany("Ingresos")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Nomina", b =>
                {
                    b.HasOne("PlanillaSalarial.Models.Empleado", "Empleado")
                        .WithMany("Nominas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("PlanillaSalarial.Models.Empleado", b =>
                {
                    b.Navigation("Deducciones");

                    b.Navigation("Ingresos");

                    b.Navigation("Nominas");
                });
#pragma warning restore 612, 618
        }
    }
}
