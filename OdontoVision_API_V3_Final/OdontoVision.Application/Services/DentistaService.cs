using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdontoVision.Application.Services
{
    public class DentistaService
    {
        private readonly IDentistaRepository _dentistaRepository;

        public DentistaService(IDentistaRepository dentistaRepository)
        {
            _dentistaRepository = dentistaRepository;
        }

        public async Task<IEnumerable<Dentista>> GetAllDentistasAsync()
        {
            return await _dentistaRepository.GetAllAsync();
        }

        public async Task<Dentista> GetDentistaByIdAsync(int id)
        {
            return await _dentistaRepository.GetByIdAsync(id);
        }

        public async Task AddDentistaAsync(Dentista dentista)
        {
            await _dentistaRepository.AddAsync(dentista);
        }

        public async Task UpdateDentistaAsync(Dentista dentista)
        {
            await _dentistaRepository.UpdateAsync(dentista);
        }

        public async Task DeleteDentistaAsync(int id)
        {
            await _dentistaRepository.DeleteAsync(id);
        }
    }
}
