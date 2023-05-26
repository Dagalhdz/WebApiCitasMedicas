using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.Entities
{
    public class InformacionPaciente
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Paciente Paciente { get; set; }
        [Required]
        public double Peso { get; set; }
        [Required]
        [RegularExpression(@"^[1-2]([.][0-9]{1,2})?$")]
        public double Altura { get; set; }

        public List<HistorialPaciente> HistorialPaciente { get; set; }
    }

}
