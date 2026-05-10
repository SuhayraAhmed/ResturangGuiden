using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurangGuiden.Models;
using System;
using System.Threading.Tasks;

namespace RestaurangGuiden.Controllers
{
    public class RestaurangerController : Controller
    {
        private readonly MainDbContext _context;

        public RestaurangerController(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Restu()
        {
            var restauranger = await _context.Restauranger
                .Include(r => r.Menyer) 
                .ToListAsync();
            return View(restauranger);
        }
    }
}
