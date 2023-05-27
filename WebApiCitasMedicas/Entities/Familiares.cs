using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.Entities
{
    public class Familiares
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string PacienteId { get; set; }
        [Required]
        public string FamiliarId { get; set; }
        [Required]
        public int ParentescoId { get; set; }

        public Paciente Paciente { get; set; }
        public Parentesco Parentesco { get; set; }
    }
}
