namespace Reprise_back.Models
{
    public class SerieGenre
    {
        public Guid SerieId { get; set; }
        public Serie? Serie { get; set; }

        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
