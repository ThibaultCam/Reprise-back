using Reprise_back.Models;

namespace Reprise_back.Service.Interface
{
    public interface ISeriesService
    {
        Task<List<Serie>> GetAllAsync();
        Task<Serie?> GetByIdAsync(int id);
        Task AddAsync(Serie series);
        Task UpdateAsync(Serie series);
        Task DeleteAsync(int id);
    }
}
