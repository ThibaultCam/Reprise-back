using Reprise_back.Models.Dto;
using Reprise_back.Models.DTO;

namespace Reprise_back.Models.Mapper
{
    public static class DtoMapper
    {
        #region Serie Dto
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
                Genres = s.SerieGenres.Select(sg => sg.Genre != null ? new GenreDto {
                    Id = sg.Genre.Id,
                    Name = sg.Genre.Name
                }: new GenreDto {}).ToList()
            };
        }

        public static Serie ToSerieEntity(SerieDto dto) =>
        new Serie
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            ReleaseDate = dto.ReleaseDate,
            Seasons = dto.Seasons.Select(se => new Seasons
            {
                Id = se.Id,
                SeasonNumber = se.SeasonNumber,
                NbEpisodes = se.NbEpisodes,
                SerieId = dto.Id
            }).ToList(),
            SerieGenres = dto.Genres.Select(genre => new SerieGenre
            {
                SerieId = dto.Id,
                GenreId = genre.Id
            }).ToList()
        };
        #endregion

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
