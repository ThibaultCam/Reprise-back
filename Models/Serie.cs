namespace Reprise_back.Models
{
    public class Serie : Media
    {
        public List<Seasons> Seasons { get; set; } = new List<Seasons>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<SerieGenre> SerieGenres { get; set; } = new List<SerieGenre>();

    }
}
