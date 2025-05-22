using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OdontoVision.Infrastructure.Repositories
{
    public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly List<Procedimento> _procedimentos = new List<Procedimento>();

        public void Adicionar(Procedimento procedimento)
        {
            _procedimentos.Add(procedimento);
        }

        public Procedimento GetById(int id)
        {
            return _procedimentos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Procedimento>? ObterTodos()
        {
            return _procedimentos;
        }

        public void Atualizar(Procedimento procedimento)
        {
            var existing = GetById(procedimento.Id);
            if (existing != null)
            {
                existing.Descricao = procedimento.Descricao;
                existing.Custo = procedimento.Custo;
            }
        }

        public void Remover(int id)
        {
            var procedimento = GetById(id);
            if (procedimento != null)
            {
                _procedimentos.Remove(procedimento);
            }
        }
    }
}
