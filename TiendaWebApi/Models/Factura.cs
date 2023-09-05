using System.ComponentModel.DataAnnotations;

namespace TiendaWebApi.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(100)]
        public string? NombreFactura { get; set; }
        [Display(Name = "Calor total")]
        public double Calor { get; set; }
        [Display(Name = "Precio Total")]
        public double Precio { get; set; }
        [Display(Name = "Pedido")]
        public virtual ICollection<PedidoFactura>? PedidoFactura { get; set; }
    }
}
