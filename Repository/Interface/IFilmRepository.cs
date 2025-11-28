using Reprise_back.Models;

namespace Reprise_back.Repository.Interface
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetAllAsync();
        Task<Film?> GetByIdAsync(int id);
        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(int id);
    }

}
