namespace RestaurangGuiden.Models
{
    public class Restaurang
    {
        public int Id { get; set; } // Primär nyckel
        public string Namn { get; set; } // Namn på restaurangen
        public string Adress { get; set; } // Adress
        public string? BildUrl { get; set; }
        public ICollection<Meny> Menyer { get; set; } = new List<Meny>();
        public List<Omdome>? Omdomen { get; set; }
    }
}
