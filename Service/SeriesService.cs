using Reprise_back.Models;
using Reprise_back.Models.DTO;
using Reprise_back.Models.Mapper;
using Reprise_back.Repository.Interface;
using Reprise_back.Service.Interface;

namespace Reprise_back.Service
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _repo;
        public SeriesService(ISeriesRepository repo) => _repo = repo;

        public Task<List<Serie>> GetAllAsync() => _repo.GetAllAsync();
        public async Task<SerieDto?> GetByIdAsync(int id)
        {
            var series = await _repo.GetByIdAsync(id);
            return series == null ? null : DtoMapper.ToSerieDto(series);
        }
        public Task AddAsync(Serie series) => _repo.AddAsync(series);
        public Task UpdateAsync(Serie series) => _repo.UpdateAsync(series);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
