using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;
using FredsBoats.Web.Models;

namespace FredsBoats.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly FredsBoatsContext _context;

        public CustomersController(FredsBoatsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Surname,Name,Address,Telephone,Licence")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}