using System;
using System.Collections.Generic;

namespace VentasPDF.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
