using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualPlanetarium.CodeFirst;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.Controllers
{
    public class CelestialObjectsController : Controller
    {
        private readonly PlanetariumDbContext _context;

        public CelestialObjectsController(PlanetariumDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Map() => View();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMapData()
        {
            try
            {
                if (!_context.Database.CanConnect())
                    return BadRequest(new { error = "DB Connection failed" });

                var objects = _context.CelestialObjects
                    .Include(o => o.Type)
                    .Select(o => new
                    {
                        id = o.Id,
                        name = o.Name ?? "Unknown",
                        distance = o.RightAscension ?? 0,
                        speed = o.Declination ?? 0,
                        description = o.Description ?? "",
                        type = o.Type != null ? o.Type.Name : "Planet",
                        // Проста генерація кольору на льоту, щоб не ускладнювати
                        color = "#" + (o.Id * 123456).ToString("X6").Substring(0, 6)
                    })
                    .ToList();

                return Json(objects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var context = _context.CelestialObjects.Include(c => c.Group).Include(c => c.Type);
            return View(await context.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var obj = await _context.CelestialObjects
                .Include(c => c.Group).Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(CelestialObject celestialObject)
        {
            ModelState.Remove("Type");
            ModelState.Remove("Group");
            ModelState.Remove("Observations");

            if (ModelState.IsValid)
            {
                _context.Add(celestialObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropdowns(celestialObject.GroupId, celestialObject.TypeId);
            return View(celestialObject);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var celestialObject = await _context.CelestialObjects.FindAsync(id);
            if (celestialObject == null) return NotFound();

            PopulateDropdowns(celestialObject.GroupId, celestialObject.TypeId);
            return View(celestialObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, CelestialObject celestialObject)
        {
            if (id != celestialObject.Id) return NotFound();
            ModelState.Remove("Type");
            ModelState.Remove("Group");
            ModelState.Remove("Observations");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celestialObject);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelestialObjectExists(celestialObject.Id)) return NotFound();
                    else throw;
                }
            }
            PopulateDropdowns(celestialObject.GroupId, celestialObject.TypeId);
            return View(celestialObject);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var celestialObject = await _context.CelestialObjects
                .Include(c => c.Group).Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celestialObject == null) return NotFound();
            return View(celestialObject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celestialObject = await _context.CelestialObjects.FindAsync(id);
            if (celestialObject != null)
            {
                _context.CelestialObjects.Remove(celestialObject);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CelestialObjectExists(int id) => _context.CelestialObjects.Any(e => e.Id == id);

        private void PopulateDropdowns(int? selectedGroup = null, int? selectedType = null)
        {
            ViewData["GroupId"] = new SelectList(_context.ObjectGroups, "Id", "Name", selectedGroup);
            ViewData["TypeId"] = new SelectList(_context.ObjectTypes, "Id", "Name", selectedType);
        }
    }
}