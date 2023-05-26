using System.ComponentModel.DataAnnotations;

namespace WebApiCitasMedicas.Entities
{
    public class Parentesco
    {
        [Required]
        public int Id { set; get; }
        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        public List<Familiares> Familias { get; set; }
    }
}
