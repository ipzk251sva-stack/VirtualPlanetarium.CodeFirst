using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using VirtualPlanetarium.CodeFirst;

namespace VirtualPlanetarium.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlanetariumDbContext _context;

        public HomeController(PlanetariumDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Authorize] 
        public IActionResult Profile()
        {
            return View();
        }
    }
}