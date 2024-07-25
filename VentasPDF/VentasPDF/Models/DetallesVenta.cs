using System.ComponentModel.DataAnnotations;

namespace VentasPDF.Models;

public partial class DetallesVenta
{
    public int IdDetalleVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }

    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal TotalProducto => IdProductoNavigation == null ? 0 : (decimal)Cantidad! * IdProductoNavigation.Precio;

    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal SubTotal => IdVentaNavigation!.DetallesVenta.Sum(d => d.TotalProducto);

    public decimal Impuesto => IdProductoNavigation == null ? 0 : SubTotal! * (decimal)0.15;

    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Total => IdProductoNavigation == null ? 0 : SubTotal! + Impuesto;


}
