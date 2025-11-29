namespace Reprise_back.Models.Dto
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime ReleaseDate { get; set; }
        public int DurationMinutes { get; set; }

        public List<string> Genres { get; set; } = new();
    }

}
