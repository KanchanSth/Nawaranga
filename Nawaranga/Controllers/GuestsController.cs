using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Data;

namespace Nawaranga.Controllers
{
    public class GuestsController : Controller
    {
        private readonly AppDbContext _context;

        public GuestsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Guests.ToListAsync();

            return View(data);
        }
    }
}
