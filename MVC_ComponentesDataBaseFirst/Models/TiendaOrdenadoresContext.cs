using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_ComponentesDataBaseFirst.Models;

public partial class TiendaOrdenadoresContext : DbContext
{
    public TiendaOrdenadoresContext()
    {
    }

    public TiendaOrdenadoresContext(DbContextOptions<TiendaOrdenadoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Componente> Componentes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Ordenadore> Ordenadores { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;initial catalog=TiendaOrdenadores");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Componente>(entity =>
        {
            entity.HasIndex(e => e.OrdenadorId, "IX_Componentes_OrdenadorId");

            entity.Property(e => e.NumeroDeSerie).HasMaxLength(100);

            entity.HasOne(d => d.Ordenador).WithMany(p => p.Componentes).HasForeignKey(d => d.OrdenadorId);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.Property(e => e.NombreFactura).HasMaxLength(100);
        });

        modelBuilder.Entity<Ordenadore>(entity =>
        {
            entity.HasIndex(e => e.PedidoId, "IX_Ordenadores_PedidoId");

            entity.Property(e => e.NombreOrdenador).HasMaxLength(100);

            entity.HasOne(d => d.Pedido).WithMany(p => p.Ordenadores).HasForeignKey(d => d.PedidoId);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(e => e.NombrePedido).HasMaxLength(100);

            entity.HasMany(d => d.Facturas).WithMany(p => p.Pedidos)
                .UsingEntity<Dictionary<string, object>>(
                    "PedidoFactura",
                    r => r.HasOne<Factura>().WithMany().HasForeignKey("FacturaId"),
                    l => l.HasOne<Pedido>().WithMany().HasForeignKey("PedidoId"),
                    j =>
                    {
                        j.HasKey("PedidoId", "FacturaId");
                        j.ToTable("PedidoFactura");
                        j.HasIndex(new[] { "FacturaId" }, "IX_PedidoFactura_FacturaId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
