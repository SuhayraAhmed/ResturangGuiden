using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurangGuiden.Models;
using System.Net.Http.Json;

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

        public async Task<IActionResult> RestaurangOmdome(int id)
        {
            var restaurang = await _context.Restauranger
                .Include(r => r.Menyer)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurang == null)
            {
                return NotFound();
            }

            List<Omdome> omdomen = new();

            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"https://localhost:7292/api/omdomen/restaurang/{id}");

                if (response.IsSuccessStatusCode)
                {
                    omdomen = await response.Content.ReadFromJsonAsync<List<Omdome>>() ?? new();
                }
            }
            catch (Exception ex)
            {
                // logga vid behov
            }

            var modell = new RestaurangMedOmdomenViewModel
            {
                Restaurang = restaurang,
                Omdomen = omdomen
            };

            return View(modell);
        }
    }
}
