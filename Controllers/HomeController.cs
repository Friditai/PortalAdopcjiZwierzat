using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalAdopcjiZwierzat.Models;
using System.Diagnostics;
using PortalAdopcjiZwierzat.Data;
using PortalAdopcjiZwierzat.Models.Zwierzeta;

using Microsoft.AspNetCore.Mvc.Rendering;




namespace PortalAdopcjiZwierzat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortalAdopcjiZwierzatContext _context;

        public HomeController(ILogger<HomeController> logger, PortalAdopcjiZwierzatContext context)
        {
            _logger = logger;
            _context = context;
        
        }

        public async Task<IActionResult> Index()
        {
            var zwierzeta = from z in _context.Zwierze
                            select z;

            return View(await zwierzeta.ToListAsync());
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