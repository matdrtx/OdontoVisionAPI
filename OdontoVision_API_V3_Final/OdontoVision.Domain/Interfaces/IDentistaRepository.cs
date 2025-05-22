using System.Collections.Generic;
using System.Threading.Tasks;
using OdontoVision.Domain.Entities;

namespace OdontoVision.Domain.Interfaces
{
    public interface IDentistaRepository
    {
        Task<IEnumerable<Dentista>> GetAllAsync();
        Task<Dentista> GetByIdAsync(int id);
        Task AddAsync(Dentista dentista);
        Task UpdateAsync(Dentista dentista);
        Task DeleteAsync(int id);
    }
}
