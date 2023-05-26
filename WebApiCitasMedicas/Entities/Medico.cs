using Microsoft.AspNetCore.Identity;

namespace WebApiCitasMedicas.Entities
{
    public class Medico : ApplicationUser
    {
        public string MedicoInfo { get; set; }

        public List<MedicoPaciente> MedicoPaciente { get; set; }
    }
}
