using OdontoVision.Application.DTOs;
using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdontoVision.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public void CreatePaciente(PacienteDTO pacienteDto)
        {
            try
            {
                var paciente = new Paciente
                {
                    Nome = pacienteDto.Nome,
                    Cpf = pacienteDto.Cpf,
                    DataNascimento = pacienteDto.DataNascimento,
                    Telefone = pacienteDto.Telefone,
                    Genero = pacienteDto.Genero,
                    Endereco = pacienteDto.Endereco
                };
                _pacienteRepository.Adicionar(paciente);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar paciente: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<PacienteDTO> GetAllPacientes()
        {
            try
            {
                return _pacienteRepository.ObterTodos()
                    .Select(p => new PacienteDTO
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Cpf = p.Cpf,
                        DataNascimento = p.DataNascimento,
                        Telefone = p.Telefone,
                        Genero = p.Genero,
                        Endereco = p.Endereco
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter pacientes: {ex.Message}");
                throw;
            }
        }

        public PacienteDTO GetPacienteById(int id)
        {
            try
            {
                var paciente = _pacienteRepository.GetById(id);
                if (paciente == null) return null;

                return new PacienteDTO
                {
                    Id = paciente.Id,
                    Nome = paciente.Nome,
                    Cpf = paciente.Cpf,
                    DataNascimento = paciente.DataNascimento,
                    Telefone = paciente.Telefone,
                    Genero = paciente.Genero,
                    Endereco = paciente.Endereco
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter paciente por ID: {ex.Message}");
                throw;
            }
        }

        public void UpdatePaciente(int id, PacienteDTO pacienteDto)
        {
            try
            {
                var paciente = _pacienteRepository.GetById(id);
                if (paciente != null)
                {
                    paciente.Nome = pacienteDto.Nome;
                    paciente.Cpf = pacienteDto.Cpf;
                    paciente.DataNascimento = pacienteDto.DataNascimento;
                    paciente.Telefone = pacienteDto.Telefone;
                    paciente.Genero = pacienteDto.Genero;
                    paciente.Endereco = pacienteDto.Endereco;
                    _pacienteRepository.Atualizar(paciente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar paciente: {ex.Message}");
                throw;
            }
        }

        public void DeletePaciente(int id)
        {
            try
            {
                _pacienteRepository.Remover(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar paciente: {ex.Message}");
                throw;
            }
        }
    }
}
