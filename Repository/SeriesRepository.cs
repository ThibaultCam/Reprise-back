using Reprise_back.Models;
using Reprise_back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace Reprise_back.Repository
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly AppDbContext _context;
        public SeriesRepository(AppDbContext context) => _context = context;

        public async Task<List<Serie>> GetAllAsync() => await _context.Series.ToListAsync();
        public async Task<Serie?> GetByIdAsync(int id) => await _context.Series.FindAsync(id);
        public async Task AddAsync(Serie series) { _context.Series.Add(series); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Serie series) { _context.Series.Update(series); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series != null) { _context.Series.Remove(series); await _context.SaveChangesAsync(); }
        }
    }
}
