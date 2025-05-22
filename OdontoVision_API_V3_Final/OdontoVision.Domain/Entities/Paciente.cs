using System;  // Adicionado para DateTime

namespace OdontoVision.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }  // DateTime agora é reconhecido
        public string Telefone { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }
    }
}
