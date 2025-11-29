namespace Reprise_back.Models
{
    public class Film : Media
    {
        public int DurationMinutes { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<FilmGenre> FilmGenres { get; set; } = new List<FilmGenre>();
    }
}
