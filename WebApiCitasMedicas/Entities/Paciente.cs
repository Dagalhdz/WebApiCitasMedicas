using Microsoft.AspNetCore.Identity;

namespace WebApiCitasMedicas.Entities
{
    public class Paciente : ApplicationUser
    {
        public string PacientesInfo { get; set; }

        public List<Familiares> Familiares { get; set; }
        public List<MedicoPaciente> MedicoPaciente { get; set; }
        public List<InformacionPaciente> InformacionPaciente { get; set; }
    }
}
