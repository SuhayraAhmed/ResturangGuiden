namespace RestaurangGuiden.Models
{
    public class Restaurang
    {
        public int Id { get; set; } 
        public string Namn { get; set; } 
        public string Adress { get; set; } 
        public string? BildUrl { get; set; }
        public ICollection<Meny> Menyer { get; set; } = new List<Meny>();
        public List<Omdome>? Omdomen { get; set; }
    }
}
