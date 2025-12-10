using Reprise_back.Models.DTO;

namespace Reprise_back.Service.Interface
{
    public interface ISeriesService
    {
        Task<List<SerieDto>> GetAllAsync();
        Task<SerieDto?> GetByIdAsync(Guid id);
        Task<SerieDto> AddAsync(SerieDto series);
        Task UpdateAsync(SerieDto series);
        Task DeleteAsync(Guid id);
    }
}
