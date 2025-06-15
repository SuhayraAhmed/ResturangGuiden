using System.Text.Json.Serialization;

namespace RestaurangGuiden.Models;
public class Omdome
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("restaurangId")]
    public int RestaurangId { get; set; }

    [JsonPropertyName("betyg")]
    public int Betyg { get; set; }  // T.ex. 1–5

    [JsonPropertyName("kommentar")]
    public string Kommentar { get; set; } = string.Empty;
}