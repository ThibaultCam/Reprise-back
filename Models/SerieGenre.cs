namespace Reprise_back.Models
{
    public class SerieGenre
    {
        public int SerieId { get; set; }
        public Serie? Serie { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
