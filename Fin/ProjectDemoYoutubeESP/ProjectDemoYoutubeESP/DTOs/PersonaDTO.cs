namespace ProjectDemoYoutubeESP.DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public List<DireccionDTO> Direcciones { get; set; }
    }
}
