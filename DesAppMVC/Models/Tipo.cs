using System;
using System.Collections.Generic;

namespace DesAppMVC.Models;

public partial class Tipo
{

    public Tipo()
    {
        Productos = new HashSet<Producto>();
    }
    public int IdTipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } 
}
