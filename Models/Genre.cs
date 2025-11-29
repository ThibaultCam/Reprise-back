namespace Reprise_back.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<FilmGenre> FilmGenres { get; set; } = new List<FilmGenre>();
        public List<SerieGenre> SerieGenres { get; set; } = new List<SerieGenre>();
        public List<Serie> Series { get; set; } = new List<Serie>();
        public List<Film> Films { get; set; } = new List<Film>();

    }
}
