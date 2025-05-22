using System.Collections.Generic;
using OdontoVision.Domain.Entities;

namespace OdontoVision.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        void Adicionar(Paciente paciente);          // Método para adicionar um paciente
        IEnumerable<Paciente> ObterTodos();         // Método para obter todos os pacientes
        Paciente GetById(int id);                   // Método para obter um paciente por ID
        void Atualizar(Paciente paciente);          // Método para atualizar um paciente
        void Remover(int id);                       // Método para remover um paciente
    }
}
