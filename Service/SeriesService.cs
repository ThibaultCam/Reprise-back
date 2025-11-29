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

        public async Task<List<SerieDto>> GetAllAsync() {
            var series = await _repo.GetAllAsync();
            return series.Select(DtoMapper.ToSerieDto).ToList();
        }
        public async Task<SerieDto?> GetByIdAsync(int id)
        {
            var series = await _repo.GetByIdAsync(id);
            return series == null ? null : DtoMapper.ToSerieDto(series);
        }
        public async Task<SerieDto> AddAsync(SerieDto series)
        {
            series.Id = null;
            var entity = DtoMapper.ToSerieEntity(series);
            await _repo.AddAsync(entity);
            return DtoMapper.ToSerieDto(entity);
        }
        public async Task UpdateAsync(SerieDto series)
        {
            await _repo.UpdateAsync(DtoMapper.ToSerieEntity(series));
        }
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
