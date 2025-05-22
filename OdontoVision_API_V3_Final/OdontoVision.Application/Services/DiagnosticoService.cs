using OdontoVision.Application.DTOs;
using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdontoVision.Application.Services
{
    public class DiagnosticoService
    {
        private readonly IDiagnosticoRepository _diagnosticoRepository;

        public DiagnosticoService(IDiagnosticoRepository diagnosticoRepository)
        {
            _diagnosticoRepository = diagnosticoRepository;
        }

        public void CreateDiagnostico(DiagnosticoDTO diagnosticoDto)
        {
            try
            {
                var diagnostico = new Diagnostico
                {
                    Descricao = diagnosticoDto.Descricao,
                    DataDiagnostico = diagnosticoDto.DataDiagnostico,
                    PacienteId = diagnosticoDto.PacienteId,
                    DentistaId = diagnosticoDto.DentistaId
                };
                _diagnosticoRepository.Adicionar(diagnostico);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar diagnóstico: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<DiagnosticoDTO> GetAllDiagnosticos()
        {
            try
            {
                return _diagnosticoRepository.ObterTodos()
                    .Select(d => new DiagnosticoDTO
                    {
                        Id = d.Id,
                        Descricao = d.Descricao,
                        DataDiagnostico = d.DataDiagnostico,
                        PacienteId = d.PacienteId,
                        DentistaId = d.DentistaId
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter diagnósticos: {ex.Message}");
                throw;
            }
        }

        public DiagnosticoDTO GetDiagnosticoById(int id)
        {
            try
            {
                var diagnostico = _diagnosticoRepository.GetById(id);
                return diagnostico == null ? null : new DiagnosticoDTO
                {
                    Id = diagnostico.Id,
                    Descricao = diagnostico.Descricao,
                    DataDiagnostico = diagnostico.DataDiagnostico,
                    PacienteId = diagnostico.PacienteId,
                    DentistaId = diagnostico.DentistaId
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter diagnóstico por ID: {ex.Message}");
                throw;
            }
        }

        public void UpdateDiagnostico(int id, DiagnosticoDTO diagnosticoDto)
        {
            try
            {
                var diagnostico = _diagnosticoRepository.GetById(id);
                if (diagnostico != null)
                {
                    diagnostico.Descricao = diagnosticoDto.Descricao;
                    diagnostico.DataDiagnostico = diagnosticoDto.DataDiagnostico;
                    _diagnosticoRepository.Atualizar(diagnostico);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar diagnóstico: {ex.Message}");
                throw;
            }
        }

        public void DeleteDiagnostico(int id)
        {
            try
            {
                _diagnosticoRepository.Remover(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar diagnóstico: {ex.Message}");
                throw;
            }
        }
    }
}
