﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NominaAPI.Data;

#nullable disable

namespace NominaAPI.Migrations
{
    [DbContext(typeof(NominaContext))]
    partial class NominaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SharedModels.Deducciones", b =>
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

            modelBuilder.Entity("SharedModels.Empleado", b =>
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

                    b.Property<string>("CodigoEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaTerminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Nacimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroINSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroRUC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
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

            modelBuilder.Entity("SharedModels.Ingresos", b =>
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

            modelBuilder.Entity("SharedModels.Nomina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoId");

                    b.Property<DateTime>("FechaRealizacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Nominas");
                });

            modelBuilder.Entity("SharedModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SharedModels.Deducciones", b =>
                {
                    b.HasOne("SharedModels.Empleado", "Empleado")
                        .WithMany("Deducciones")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("SharedModels.Ingresos", b =>
                {
                    b.HasOne("SharedModels.Empleado", "Empleado")
                        .WithMany("Ingresos")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("SharedModels.Nomina", b =>
                {
                    b.HasOne("SharedModels.Empleado", "Empleado")
                        .WithMany("Nominas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("SharedModels.Empleado", b =>
                {
                    b.Navigation("Deducciones");

                    b.Navigation("Ingresos");

                    b.Navigation("Nominas");
                });
#pragma warning restore 612, 618
        }
    }
}
