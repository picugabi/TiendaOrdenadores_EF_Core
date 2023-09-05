using System;
using System.Collections.Generic;

namespace MVC_ComponentesDataBaseFirst.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public string NombrePedido { get; set; } = null!;

    public double Calor { get; set; }

    public double Precio { get; set; }

    public virtual ICollection<Ordenadore> Ordenadores { get; set; } = new List<Ordenadore>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
