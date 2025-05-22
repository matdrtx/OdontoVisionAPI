using System.ComponentModel.DataAnnotations;

namespace OdontoVision.Application.ViewModels
{
    public class DiagnosticoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
    }
}
