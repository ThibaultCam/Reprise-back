using Reprise_back.Models;
using Reprise_back.Repository.Interface;
using Reprise_back.Service.Interface;

namespace Reprise_back.Service
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repo;
        public FilmService(IFilmRepository repo) => _repo = repo;

        public Task<List<Film>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Film?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Film film) => _repo.AddAsync(film);
        public Task UpdateAsync(Film film) => _repo.UpdateAsync(film);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

}
