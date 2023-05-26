using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.Entities
{
    public class HistorialPaciente
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public InformacionPaciente Informacion { get; set; }
        [Required]
        [MaxLength(100)]
        public string Enfermedad { get; set; }
        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

    }
}
