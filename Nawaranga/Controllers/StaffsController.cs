﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Data;

namespace Nawaranga.Controllers
{
    public class StaffsController : Controller
    {
        private readonly AppDbContext _context;

        public StaffsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Rooms.ToListAsync();

            return View(data);
        }
    }
}