using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using OdontoVision.Infrastructure.Context;

namespace OdontoVision.Infrastructure.Repositories
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly OdontoVisionDbContext _context;

        public DiagnosticoRepository(OdontoVisionDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Diagnostico diagnostico)
        {
            _context.Diagnosticos.Add(diagnostico);
            _context.SaveChanges(); // <-- ESSENCIAL para persistir
        }

        public Diagnostico? GetById(int id)
        {
            return _context.Diagnosticos.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Diagnostico> ObterTodos()
        {
            return _context.Diagnosticos.ToList();
        }

        public void Atualizar(Diagnostico diagnostico)
        {
            _context.Diagnosticos.Update(diagnostico);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var diagnostico = GetById(id);
            if (diagnostico != null)
            {
                _context.Diagnosticos.Remove(diagnostico);
                _context.SaveChanges();
            }
        }
    }
}
