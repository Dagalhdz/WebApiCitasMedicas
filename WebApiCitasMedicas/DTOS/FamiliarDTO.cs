using System.ComponentModel.DataAnnotations;
using WebApiCitasMedicas.Entities;

namespace WebApiCitasMedicas.DTOS
{
    public class FamiliarDTO
    {
        [Required]
        public string PacienteId { get; set; }
        [Required]
        public string FamiliarId { get; set; }
        [Required]
        public int ParentescoId { get; set; }
    }
}
