namespace ProjectDemoYoutubeESP.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Salario { get; set; }
        public bool EstaLogueado { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }
}
