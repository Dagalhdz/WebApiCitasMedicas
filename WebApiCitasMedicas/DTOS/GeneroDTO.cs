using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.DTOS
{
    public class GeneroDTO
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
