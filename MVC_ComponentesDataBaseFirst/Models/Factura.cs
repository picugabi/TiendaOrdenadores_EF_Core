using System;
using System.Collections.Generic;

namespace MVC_ComponentesDataBaseFirst.Models;

public partial class Factura
{
    public int Id { get; set; }

    public string NombreFactura { get; set; } = null!;

    public double Calor { get; set; }

    public double Precio { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
