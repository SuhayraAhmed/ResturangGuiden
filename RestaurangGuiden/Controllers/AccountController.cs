using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestaurangGuiden.Models;
using System.Security.Claims;

namespace RestaurangGuiden.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account input)                                           //Denna är från canvas för inlogning och säkerhet 
        {

            bool accountValid = input.Username == "restaurang@gudien.se" && input.Password == "Admin123";                         // användarnamn och lösenord


            if (!accountValid)
            {
                ViewBag.ErrorMessage = "Login failed: Wrong username or password";
                return View("Login");
            }

            // Om inloggning är korrekt
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, input.Username));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Admin");                                                                                      // går vi till till admin-sidan


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");                                                                                      // tillbaka till inloggningssidan
        }

        
    }



}
