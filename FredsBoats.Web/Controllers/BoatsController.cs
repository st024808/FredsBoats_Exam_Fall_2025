using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;
using FredsBoats.Web.Models;

namespace FredsBoats.Web.Controllers
{
    public class BoatsController : Controller
    {
        private readonly FredsBoatsContext _context;

        public BoatsController(FredsBoatsContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            var boats = _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour);
            return View(await boats.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var boat = await _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour)
                // We include this in anticipation of the exam task (Comments)
                // but for now it will just prevent errors if the property exists
                .FirstOrDefaultAsync(m => m.BoatId == id);

            if (boat == null) return NotFound();

            return View(boat);
        }
    }
}