namespace WebApiCitasMedicas.Entities
{
    public class Citas
    {
        public int Id { get; set; }
        public MedicoPaciente MedicoPaciente { get; set; }
        public DateOnly Fecha { get; set; }
        public DateTime TiempoInicio { get; set; }
        public DateTime TiempoFin { get; set; }
        public string Descripcion { get; set; }
    }
}
