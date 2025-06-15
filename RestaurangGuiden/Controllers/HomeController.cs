using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestaurangGuiden.Models;
using System.Net.Http.Json;

namespace RestaurangGuiden.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: formulär för nytt omdöme
        public IActionResult CreateOmdome(int restaurangId)
        {
            var model = new Omdome { RestaurangId = restaurangId };
            return View(model); // /Views/Home/CreateOmdome.cshtml
        }

        // POST: Skickar nytt omdöme till API:t
        [HttpPost]
        public async Task<IActionResult> SkickaOmdome(Omdome omdome)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOmdome", omdome);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7292/api/omdomen", omdome);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Tack"] = "Tack för ditt omdöme!";
                    return RedirectToAction("RestaurangOmdome", "Restauranger", new { id = omdome.RestaurangId });
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"API-fel: {response.StatusCode} - {error}");
                    ModelState.AddModelError("", "API-fel: " + error);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Nätverksfel: {ex.Message}");
            }

            return View("CreateOmdome", omdome);
        }

        public IActionResult Restu()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
