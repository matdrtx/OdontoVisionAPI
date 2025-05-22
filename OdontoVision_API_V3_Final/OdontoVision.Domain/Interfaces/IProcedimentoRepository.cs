using OdontoVision.Domain.Entities;
using System.Collections.Generic;

namespace OdontoVision.Domain.Interfaces
{
    public interface IProcedimentoRepository
    {
        void Adicionar(Procedimento procedimento);    // Método para adicionar
        Procedimento GetById(int id);                 // Método para obter por ID
        IEnumerable<Procedimento> ObterTodos();       // Método para obter todos
        void Atualizar(Procedimento procedimento);    // Método para atualizar
        void Remover(int id);                         // Método para remover por ID
    }
}
