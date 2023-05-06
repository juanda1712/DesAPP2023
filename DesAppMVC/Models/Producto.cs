using System;
using System.Collections.Generic;

namespace DesAppMVC.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public double? Valor { get; set; }

    public int? IdTipo { get; set; }

    public virtual Tipo? DetTipo { get; set; }
}
