using System;
using System.Collections.Generic;

namespace MVC_ComponentesDataBaseFirst.Models;

public partial class Componente
{
    public int TipoComponente { get; set; }

    public string NumeroDeSerie { get; set; } = null!;

    public int Id { get; set; }

    public double Precio { get; set; }

    public double Calor { get; set; }

    public double Almacenamiento { get; set; }

    public int Cores { get; set; }

    public int? OrdenadorId { get; set; }

    public virtual Ordenadore? Ordenador { get; set; }
}
