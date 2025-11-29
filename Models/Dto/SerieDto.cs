using Reprise_back.Models.Dto;

namespace Reprise_back.Models.DTO
{
    public class SerieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime ReleaseDate { get; set; }

        public List<SeasonDto> Seasons { get; set; } = new();
        public List<GenreDto> Genres { get; set; } = new();

    }
}
