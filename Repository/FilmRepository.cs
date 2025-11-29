using Microsoft.EntityFrameworkCore;
using Reprise_back.Models;
using Reprise_back.Repository.Interface;

namespace Reprise_back.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;
        public FilmRepository(AppDbContext context) => _context = context;

        public async Task<List<Film>> GetAllAsync() => await _context.Films.Include(s => s.Genres).ToListAsync();
        public async Task<Film?> GetByIdAsync(Guid id) => await _context.Films.Include(s => s.Genres).FirstOrDefaultAsync(s => s.Id == id);
        public async Task AddAsync(Film film) { _context.Films.Add(film); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Film film) { _context.Films.Update(film); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Guid id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null) { _context.Films.Remove(film); await _context.SaveChangesAsync(); }
        }
    }

}
