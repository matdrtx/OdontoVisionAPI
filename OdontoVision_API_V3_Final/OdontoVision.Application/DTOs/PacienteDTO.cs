using System;  // Adicionado para DateTime

namespace OdontoVision.Application.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }
    }
}
