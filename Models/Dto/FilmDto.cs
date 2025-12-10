namespace Reprise_back.Models.Dto
{
    public class FilmDto : MediaDto
    {
        public int DurationMinutes { get; set; }
        public List<GenreDto> Genres { get; set; } = new();
    }

}
