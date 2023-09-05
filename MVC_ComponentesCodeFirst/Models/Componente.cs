using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Models
{
    public class Componente
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MinLength(3),MaxLength(100)]
        [Column(Order = 2)]
        public string? NumeroDeSerie { get; set; }
        [Required]
        [Range(0,Double.MaxValue)]
        [Display(Description = "euros")]
        public double Precio { get; set; }
        [Column(Order = 1)]
        [Required(ErrorMessage = "Tipo componente obligatorio")]
        public EnumTipoComponente TipoComponente { get; set; }
        [Range(0,1000)]
        public double Calor { get; set; }
        [Range(0,Double.MaxValue)]
        public double Almacenamiento { get; set; }
        [Range(0,1000)]
        public int Cores { get; set; }
        [Display(Name = "Ordenador Cliente")]
        public int? OrdenadorId { get; set; }


    }
}
