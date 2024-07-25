namespace VentasPDF.Models
{
    public class FacturaViewModel
    {
        Categoria Categoria { get; set; } = null!;

        Producto Producto { get; set; } = null!;

        Venta Venta { get; set; } = null!;

        DetallesVenta DetallesVenta { get; set; } = null!;


    }
}
