using Microsoft.EntityFrameworkCore;
using Reprise_back.Models;
using Reprise_back.Repository.Interface;

namespace Reprise_back.Repository
{
    public class UserDataFilmRepository : IUserDataFilmRepository
    {
        private readonly AppDbContext _context;
        public UserDataFilmRepository(AppDbContext context) => _context = context;
        public async Task DeleteFilmRate(Guid filmId, string userId)
        {
            var rate = await _context.UserFilmRates.Where(r => r.FilmId == filmId && r.UserId == userId).FirstOrDefaultAsync();
            if (rate != null) { _context.UserFilmRates.Remove(rate); await _context.SaveChangesAsync(); }
        }

        public async Task UpdateFilmRate(double rate, Guid filmId, string userId)
        {
            var userFilmRate = await _context.UserFilmRates.Where(r => r.FilmId == filmId && r.UserId == userId).FirstOrDefaultAsync();
            
            if (userFilmRate != null) {
                userFilmRate.Rate = rate;
                _context.UserFilmRates.Update(userFilmRate);
                await _context.SaveChangesAsync();
            }
            else {
                var newRate = new UserFilmRate { FilmId = filmId, UserId = userId, Rate = rate };
                _context.UserFilmRates.Add(newRate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
