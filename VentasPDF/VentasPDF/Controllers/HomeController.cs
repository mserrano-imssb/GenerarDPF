using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Diagnostics;
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
            var ventas = _context.Ventas.ToList();           
            return View(ventas);
        }

        public async Task<IActionResult> GenerarPdf(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            Venta venta = await _context.Ventas!
                .Include(d => d.DetallesVenta)
                .ThenInclude(s => s.IdProductoNavigation)
                .FirstOrDefaultAsync(x => x.IdVenta == id);

            if (venta == null)
            {
                return NotFound();
            }           
           
            return new ViewAsPdf("GenerarPdf", venta)
            {
                FileName = $"Venta {id}.pdf",
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
