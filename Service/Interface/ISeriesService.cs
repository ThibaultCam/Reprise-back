using Reprise_back.Models;
using Reprise_back.Models.DTO;

namespace Reprise_back.Service.Interface
{
    public interface ISeriesService
    {
        Task<List<SerieDto>> GetAllAsync();
        Task<SerieDto?> GetByIdAsync(int id);
        Task<SerieDto> AddAsync(SerieDto series);
        Task UpdateAsync(SerieDto series);
        Task DeleteAsync(int id);
    }
}
