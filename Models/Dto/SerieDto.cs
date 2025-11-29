using Reprise_back.Models.Dto;

namespace Reprise_back.Models.DTO
{
    public class SerieDto : MediaDto
    {
        public List<SeasonDto> Seasons { get; set; } = new();
        public List<GenreDto> Genres { get; set; } = new();

    }
}
