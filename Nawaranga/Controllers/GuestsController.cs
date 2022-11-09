using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Data;
using Nawaranga.Data.Services;
using Nawaranga.Data.Static;
using Nawaranga.Models;
using System.Data;

namespace Nawaranga.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestsService _context;

        public GuestsController(IGuestsService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.GetAllAsync();

            return View(data);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            var guestDetails = await _context.GetByIdAsync(id);

            if (guestDetails == null)
            {
                return View("NotFound");
            }

            return View(guestDetails);
        }

        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]

        public async Task<IActionResult> Create(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return View(guest);
            }

            await _context.AddAsync(guest);

            return RedirectToAction(nameof(Index));

        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            var guestDetails = await _context.GetByIdAsync(id);

            if (guestDetails == null)
            {
                return View("NotFound");
            }

            return View(guestDetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> Edit(int id, Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return View(guest);
            }

            await _context.UpdateAsync(id, guest);

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            var guestDetails = await _context.GetByIdAsync(id);

            if (guestDetails == null)
            {
                return View("NotFound");
            }

            return View(guestDetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestDetails = await _context.GetByIdAsync(id);

            if (guestDetails == null)
            {
                return View("NotFound");
            }

            await _context.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
