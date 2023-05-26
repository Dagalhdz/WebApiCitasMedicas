using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.Entities
{
    public class MedicoPaciente
    {
        [Required]
        public int Id { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        public List<Citas> Citas { get; set; }
    }
}
