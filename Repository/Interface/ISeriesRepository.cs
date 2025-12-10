using Reprise_back.Models;

namespace Reprise_back.Repository.Interface
{
    public interface ISeriesRepository
    {
        Task<List<Serie>> GetAllAsync();
        Task<Serie?> GetByIdAsync(Guid id);
        Task AddAsync(Serie series);
        Task UpdateAsync(Serie series);
        Task DeleteAsync(Guid id);
    }

}
