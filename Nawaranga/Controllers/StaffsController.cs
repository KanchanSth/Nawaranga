using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Data;
using Nawaranga.Data.Services;
using Nawaranga.Models;
using System.Data;

namespace Nawaranga.Controllers
{
    public class StaffsController : Controller
    {
        private readonly IStaffsService _context;

        public StaffsController(IStaffsService context)
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
            var staffDetails = await _context.GetByIdAsync(id);

            if (staffDetails == null)
            {
                return View("NotFound");
            }

            return View(staffDetails);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> Create(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            await _context.AddAsync(staff);

            return RedirectToAction(nameof(Index));

        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            var staffDetails = await _context.GetByIdAsync(id);

            if (staffDetails == null)
            {
                return View("NotFound");
            }

            return View(staffDetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> Edit(int id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            await _context.UpdateAsync(id, staff);

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            var staffDetails = await _context.GetByIdAsync(id);

            if (staffDetails == null)
            {
                return View("NotFound");
            }

            return View(staffDetails);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffDetails = await _context.GetByIdAsync(id);

            if (staffDetails == null)
            {
                return View("NotFound");
            }

            await _context.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
