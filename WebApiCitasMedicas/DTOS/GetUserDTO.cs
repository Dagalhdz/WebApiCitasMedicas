using System.ComponentModel.DataAnnotations;


namespace WebApiCitasMedicas.DTOS
{
    public class GetUserDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo paso el maximo de 150 carateres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo paso el maximo de 150 carateres")]
        public string ApellidoPaterno { get; set; }

        /*[Required(ErrorMessage = "El apellido materno es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo paso el maximo de 150 carateres")]
        public string ApellidoMaterno { get; set; }*/

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha valida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Info { get; set; }

    }
}
