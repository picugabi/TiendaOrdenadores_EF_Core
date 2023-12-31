﻿// <auto-generated />
using System;
using MVC_ComponentesCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20230821215113_Migration6")]
    partial class Migration6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Almacenamiento")
                        .HasColumnType("float");

                    b.Property<double>("Calor")
                        .HasColumnType("float");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDeSerie")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(2);

                    b.Property<int?>("OrdenadorId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("TipoComponente")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("OrdenadorId");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Ordenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calor")
                        .HasColumnType("float");

                    b.Property<string>("NombreOrdenador")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Ordenadores");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calor")
                        .HasColumnType("float");

                    b.Property<string>("NombrePedido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Componente", b =>
                {
                    b.HasOne("MVC_ComponentesCodeFirst.Models.Ordenador", null)
                        .WithMany("ComponentesAgregados")
                        .HasForeignKey("OrdenadorId");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Ordenador", b =>
                {
                    b.HasOne("MVC_ComponentesCodeFirst.Models.Pedido", null)
                        .WithMany("OrdenadoresAgregados")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Ordenador", b =>
                {
                    b.Navigation("ComponentesAgregados");
                });

            modelBuilder.Entity("MVC_ComponentesCodeFirst.Models.Pedido", b =>
                {
                    b.Navigation("OrdenadoresAgregados");
                });
#pragma warning restore 612, 618
        }
    }
}
