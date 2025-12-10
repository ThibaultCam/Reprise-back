using Reprise_back.Models;

namespace Reprise_back.Repository.Interface
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetAllAsync();
        Task<Film?> GetByIdAsync(Guid id);
        Task<Film?> GetByIdAsync(Guid id, string userId);
        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(Guid id);
    }

}
