using OdontoVision.Domain.Entities;
using System.Collections.Generic;

namespace OdontoVision.Domain.Interfaces
{
    public interface IDiagnosticoRepository
    {
        void Adicionar(Diagnostico diagnostico);
        Diagnostico GetById(int id);
        IEnumerable<Diagnostico> ObterTodos();
        void Atualizar(Diagnostico diagnostico);
        void Remover(int id);
    }
}
