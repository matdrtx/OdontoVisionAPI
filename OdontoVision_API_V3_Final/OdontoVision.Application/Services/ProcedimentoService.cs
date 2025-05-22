using OdontoVision.Application.DTOs;
using OdontoVision.Domain.Entities;
using OdontoVision.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdontoVision.Application.Services
{
    public class ProcedimentoService
    {
        private readonly IProcedimentoRepository _procedimentoRepository;

        public ProcedimentoService(IProcedimentoRepository procedimentoRepository)
        {
            _procedimentoRepository = procedimentoRepository;
        }

        public void CreateProcedimento(ProcedimentoDTO procedimentoDto)
        {
            try
            {
                var procedimento = new Procedimento
                {
                    Descricao = procedimentoDto.Descricao,
                    Custo = procedimentoDto.Custo
                };
                _procedimentoRepository.Adicionar(procedimento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar procedimento: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<ProcedimentoDTO> GetAllProcedimentos()
        {
            try
            {
                return _procedimentoRepository.ObterTodos()
                    .Select(p => new ProcedimentoDTO
                    {
                        Id = p.Id,
                        Descricao = p.Descricao,
                        Custo = p.Custo
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter procedimentos: {ex.Message}");
                throw;
            }
        }

        public ProcedimentoDTO GetProcedimentoById(int id)
        {
            try
            {
                var procedimento = _procedimentoRepository.GetById(id);
                if (procedimento == null) return null;

                return new ProcedimentoDTO
                {
                    Id = procedimento.Id,
                    Descricao = procedimento.Descricao,
                    Custo = procedimento.Custo
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter procedimento por ID: {ex.Message}");
                throw;
            }
        }

        public void UpdateProcedimento(int id, ProcedimentoDTO procedimentoDto)
        {
            try
            {
                var procedimento = _procedimentoRepository.GetById(id);
                if (procedimento != null)
                {
                    procedimento.Descricao = procedimentoDto.Descricao;
                    procedimento.Custo = procedimentoDto.Custo;
                    _procedimentoRepository.Atualizar(procedimento);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar procedimento: {ex.Message}");
                throw;
            }
        }

        public void DeleteProcedimento(int id)
        {
            try
            {
                _procedimentoRepository.Remover(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar procedimento: {ex.Message}");
                throw;
            }
        }
    }
}
