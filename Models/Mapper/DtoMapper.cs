using Reprise_back.Models.Dto;
using Reprise_back.Models.DTO;

namespace Reprise_back.Models.Mapper
{
    public static class DtoMapper
    {
        public static SerieDto ToSerieDto(Serie s)
        {
            return new SerieDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ReleaseDate = s.ReleaseDate,
                Seasons = s.Seasons.Select(se => new SeasonDto
                {
                    Id = se.Id,
                    SeasonNumber = se.SeasonNumber,
                    NbEpisodes = se.NbEpisodes
                }).ToList(),
                Genres = s.SerieGenres.Select(sg => sg.Genre.Name).ToList()
            };
        }

        public static FilmDto ToFilmDto(Film f)
        {
            return new FilmDto
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                ReleaseDate = f.ReleaseDate,
                DurationMinutes = f.DurationMinutes,
                Genres = f.FilmGenres.Select(fg => fg.Genre.Name).ToList()
            };
        }
    }
}
