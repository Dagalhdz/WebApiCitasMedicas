using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.DTOS
{
    public class ParentescoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { set; get; }
    }
}
