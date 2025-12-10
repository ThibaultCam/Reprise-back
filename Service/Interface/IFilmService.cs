using Reprise_back.Models.Dto;

namespace Reprise_back.Service.Interface
{
    public interface IFilmService
    {
        Task<List<FilmDto>> GetAllAsync();
        Task<FilmDto?> GetByIdAsync(Guid id, string userId = "");
        Task<FilmDto> AddAsync(FilmDto film);
        Task UpdateAsync(FilmDto film);
        Task DeleteAsync(Guid id);
    }
}
