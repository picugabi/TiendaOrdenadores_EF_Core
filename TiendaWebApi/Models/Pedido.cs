using System.ComponentModel.DataAnnotations;

namespace TiendaWebApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(100)]
        public string? NombrePedido { get; set; }
        [Display(Name = "Calor total")]
        public double Calor { get; set; }
        [Display(Name = "Precio Total")]
        public double Precio { get; set; }
        public virtual ICollection<Ordenador>? OrdenadoresAgregados { get; set; }
        public virtual ICollection<PedidoFactura>? PedidoFactura { get; set; }

    }
}
