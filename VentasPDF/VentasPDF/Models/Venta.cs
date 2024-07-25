using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VentasPDF.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime? Fecha { get; set; }

    public string Cliente { get; set; } = null!;

    public string EstadoVenta { get; set; } = null!;
 

    public virtual ICollection<DetallesVenta> DetallesVenta { get; set; } = new List<DetallesVenta>();

    
    
}
