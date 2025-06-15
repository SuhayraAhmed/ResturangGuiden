using System.Text.Json;
using RestaurangGuiden.Models;

namespace RestaurangGuiden.Services;

public class RestaurantService
{
    private readonly HttpClient _httpClient;

    public RestaurantService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Omdome>> GetRestaurantsAsync()
    {
        try
        {
            var url = "https://localhost:7292/api/Resturanger";
            Console.WriteLine($"📡 Hämtar data från API: {url}");

            var response = await _httpClient.GetAsync(url);
            Console.WriteLine($"🔄 API-svar: {response.StatusCode}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"📦 JSON från API: {json}");

            var restaurants = JsonSerializer.Deserialize<List<Omdome>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (restaurants == null)
            {
                Console.WriteLine("❌ JSON var null! API returnerar ingen data.");
                return new List<Omdome>();
            }

            Console.WriteLine($"✅ {restaurants.Count} restauranger hämtade.");
            return restaurants;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ API-fel: {ex.Message}");
            return new List<Omdome>();
        }
    }
}
