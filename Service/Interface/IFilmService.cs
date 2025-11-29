using Reprise_back.Models;

namespace Reprise_back.Service.Interface
{
    public interface IFilmService
    {
        Task<List<Film>> GetAllAsync();
        Task<Film?> GetByIdAsync(Guid id);
        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(Guid id);
    }
}
