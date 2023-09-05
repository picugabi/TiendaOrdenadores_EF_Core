using System.ComponentModel.DataAnnotations;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Models
{
    public class Ordenador
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1),MaxLength(100)]
        public string? NombreOrdenador { get; set; }
        [Display(Name = "Calor total")]
        public double Calor { get; set; }
        [Display(Name = "Precio Total")]
        public double Precio { get; set; }
        public virtual ICollection<Componente>? ComponentesAgregados { get; set; }
        public int? PedidoId { get; set; }
    }
}
