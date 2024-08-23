using System;
using System.Collections.Generic;

namespace VentasPDF.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<DetallesVenta> DetallesVenta { get; set; } = new List<DetallesVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
