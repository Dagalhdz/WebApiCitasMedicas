namespace WebApiCitasMedicas.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<ApplicationUser> Users { get; set; }
    }
}
