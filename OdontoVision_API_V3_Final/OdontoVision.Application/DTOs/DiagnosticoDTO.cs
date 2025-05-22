using System;

namespace OdontoVision.Application.DTOs
{
    public class DiagnosticoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDiagnostico { get; set; }
        public int PacienteId { get; set; }
        public int DentistaId { get; set; }
    }
}
