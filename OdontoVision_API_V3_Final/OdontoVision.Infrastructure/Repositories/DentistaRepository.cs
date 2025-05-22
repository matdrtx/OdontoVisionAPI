using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using OdontoVision.Infrastructure.Context;

namespace OdontoVision.Infrastructure.Repositories
{
    public class DentistaRepository : IDentistaRepository
    {
        private readonly OdontoVisionDbContext _context;

        public DentistaRepository(OdontoVisionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dentista>> GetAllAsync()
        {
            return await _context.Dentistas.ToListAsync();
        }

        public async Task<Dentista> GetByIdAsync(int id)
        {
            return await _context.Dentistas.FindAsync(id);
        }

        public async Task AddAsync(Dentista dentista)
        {
            await _context.Dentistas.AddAsync(dentista);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dentista dentista)
        {
            _context.Dentistas.Update(dentista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista != null)
            {
                _context.Dentistas.Remove(dentista);
                await _context.SaveChangesAsync();
            }
        }
    }
}
