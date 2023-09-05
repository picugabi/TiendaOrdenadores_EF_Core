using System;
using System.Collections.Generic;

namespace MVC_ComponentesDataBaseFirst.Models;

public partial class Ordenadore
{
    public int Id { get; set; }

    public string NombreOrdenador { get; set; } = null!;

    public double Calor { get; set; }

    public double Precio { get; set; }

    public int? PedidoId { get; set; }

    public virtual ICollection<Componente> Componentes { get; set; } = new List<Componente>();

    public virtual Pedido? Pedido { get; set; }
}
