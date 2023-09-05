using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MVC_ComponentesCodeFirst.Models
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
        {
        }

        public DbSet<Componente>? Componentes { get; set; }
        public DbSet<Ordenador>? Ordenadores { get; set; }
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Factura>? Facturas { get; set; }
        public DbSet<PedidoFactura> PedidoFactura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoFactura>().HasKey(sc => new { sc.PedidoId, sc.FacturaId });
        }

    }
}

