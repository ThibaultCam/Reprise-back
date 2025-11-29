using Reprise_back.Models;
using Reprise_back.Models.DTO;

namespace Reprise_back.Service.Interface
{
    public interface ISeriesService
    {
        Task<List<Serie>> GetAllAsync();
        Task<SerieDto?> GetByIdAsync(int id);
        Task AddAsync(Serie series);
        Task UpdateAsync(Serie series);
        Task DeleteAsync(int id);
    }
}
