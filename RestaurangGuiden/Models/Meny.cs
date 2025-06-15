namespace RestaurangGuiden.Models
{
    public class Meny
    {
        public int Id { get; set; }
        public string Rätt { get; set; }
        public decimal Pris { get; set; }

        // Främmande nyckel till Restaurang
        public int RestaurangId { get; set; }
        public Restaurang? Restaurang { get; set; }
    }
}
