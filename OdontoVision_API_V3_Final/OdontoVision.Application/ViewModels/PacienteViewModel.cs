using System.ComponentModel.DataAnnotations;

namespace OdontoVision.Application.ViewModels
{
    public class PacienteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
    }
}
