using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using RestaurangGuiden.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurangGuiden.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly MainDbContext _context;

        public AdminController(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var restauranger = await _context.Restauranger
                .Include(r => r.Menyer)
                .ToListAsync();
            return View(restauranger);
        }

       
        public async Task<IActionResult> CreateRestaurang(int? id)
        {
            if (id == null)
            {
                return View(new Restaurang());  
            }

            var restaurang = await _context.Restauranger.FindAsync(id);
            if (restaurang == null) return NotFound();

            return View(restaurang);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRestaurang(Restaurang restaurang, IFormFile bild)
        {
            if (ModelState.IsValid)
            {
                
                if (bild != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(bild.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await bild.CopyToAsync(stream);
                    }

                    restaurang.BildUrl = "/Img/" + fileName;
                }

                
                if (restaurang.Id == 0)  
                {
                    _context.Add(restaurang);
                }
                else  
                {
                    _context.Update(restaurang);
                }

                await _context.SaveChangesAsync();
            }

            return View(restaurang);  
        }


        public IActionResult CreateMeny(int restaurangId)
        {
            ViewData["RestaurangId"] = restaurangId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMeny(Meny meny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meny);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var restaurang = await _context.Restauranger
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurang == null)
            {
                return NotFound();
            }

            return View(restaurang);  
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurang = await _context.Restauranger.FindAsync(id);

            if (restaurang != null)
            {
                
                if (!string.IsNullOrEmpty(restaurang.BildUrl))
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", restaurang.BildUrl.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Restauranger.Remove(restaurang);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));  
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");  
        }
    }
}
