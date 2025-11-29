using Reprise_back.Models;
using Reprise_back.Models.Dto;
using Reprise_back.Models.Mapper;
using Reprise_back.Repository.Interface;
using Reprise_back.Service.Interface;

namespace Reprise_back.Service
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repo;
        public FilmService(IFilmRepository repo) => _repo = repo;

        public async Task<List<FilmDto>> GetAllAsync()
        {
            var films = await _repo.GetAllAsync(); ;
            return films.Select(DtoMapper.ToFilmDto).ToList();
        }
       
        public async Task<FilmDto?> GetByIdAsync(Guid id)
        {
            var film = await _repo.GetByIdAsync(id);
            return film == null ? null : DtoMapper.ToFilmDto(film);
        }
        
        public async Task<FilmDto> AddAsync(FilmDto film)
        {
            film.Id = Guid.NewGuid();
            var entity = DtoMapper.ToFilmEntity(film);
            await _repo.AddAsync(entity); ;
            return DtoMapper.ToFilmDto(entity);
        }
        
        public async Task UpdateAsync(FilmDto film)
        {
            await _repo.UpdateAsync(DtoMapper.ToFilmEntity(film));
        }
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }

}
