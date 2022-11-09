using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Data;
using Nawaranga.Data.Services;
using Nawaranga.Models;

namespace Nawaranga.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService _context;

        public RoomsController(IRoomsService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.GetAllAsync();

            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _context.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var result = data.Where(n => n.Description.Contains(searchString)).ToList();
                return View("Index", result);
            }
            return View("Index", data);


        }


        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> Create(Room room)
        {
            if(!ModelState.IsValid)
            {
               return View(room);
            }

           await _context.AddAsync(room);

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var roomDetails = await _context.GetByIdAsync(id);

            if(roomDetails==null)
            {
                return View("NotFound");
            }

            return View(roomDetails);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            var roomDetails = await _context.GetByIdAsync(id);

            if (roomDetails == null)
            {
                return View("NotFound");
            }

            return View(roomDetails);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> Edit(int id,Room room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }

            await _context.UpdateAsync(id,room);

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            var roomDetails = await _context.GetByIdAsync(id);

            if (roomDetails == null)
            {
                return View("NotFound");
            }

            return View(roomDetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomDetails = await _context.GetByIdAsync(id);

            if (roomDetails == null)
            {
                return View("NotFound");
            }

            await _context.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }

        
    }
}
