using System;

namespace OdontoVision.Domain.Entities
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDiagnostico { get; set; }
        public int PacienteId { get; set; }
        public int DentistaId { get; set; }
    }
}
