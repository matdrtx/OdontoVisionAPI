using System.Collections.Generic;
using System.Linq;
using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using OdontoVision.Infrastructure.Context;

namespace OdontoVision.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly OdontoVisionDbContext _context;

        public PacienteRepository(OdontoVisionDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public IEnumerable<Paciente>? ObterTodos()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente GetById(int id)
        {
            return _context.Pacientes.Find(id);
        }

        public void Atualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var paciente = GetById(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();
            }
        }
    }
}
