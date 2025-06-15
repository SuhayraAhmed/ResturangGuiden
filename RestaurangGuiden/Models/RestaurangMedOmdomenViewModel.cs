namespace RestaurangGuiden.Models
{
    public class RestaurangMedOmdomenViewModel
    {
        public Restaurang Restaurang { get; set; } = null!;
        public List<Omdome> Omdomen { get; set; } = new();
    }
}
