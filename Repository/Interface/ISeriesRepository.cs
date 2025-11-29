using Reprise_back.Models;
using Reprise_back.Models.DTO;

namespace Reprise_back.Repository.Interface
{
    public interface ISeriesRepository
    {
        Task<List<Serie>> GetAllAsync();
        Task<Serie?> GetByIdAsync(int id);
        Task AddAsync(Serie series);
        Task UpdateAsync(Serie series);
        Task DeleteAsync(int id);
    }

}
