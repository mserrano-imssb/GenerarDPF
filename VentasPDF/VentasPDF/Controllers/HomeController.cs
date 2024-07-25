using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Rotativa.AspNetCore;
using System.Diagnostics;
using System.Net.Http;
using VentasPDF.Models;

namespace VentasPDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EcommerceContext _context;

        public HomeController(ILogger<HomeController> logger, EcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
                                    
            var ventas = _context.DetallesVenta
                .Include(d => d.IdVentaNavigation)
                .Include(d => d.IdProductoNavigation)
                .ThenInclude(p => p!.IdCategoriaNavigation)
                .ToList();
            return View(ventas);
        }

        public async Task<IActionResult> GenerarPdf(int id)
        {
            var detalle = await _context.DetallesVenta
                .Include(d => d.IdVentaNavigation)
                .Include(d => d.IdProductoNavigation)
                .ThenInclude(p => p!.IdCategoriaNavigation)
                .FirstOrDefaultAsync(x => x.IdDetalleVenta == id);

            if(detalle == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("GenerarPdf", detalle)
            {
                FileName = $"Venta {detalle!.IdDetalleVenta}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };           
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
