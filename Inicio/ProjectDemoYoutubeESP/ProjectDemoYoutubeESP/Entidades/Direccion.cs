namespace ProjectDemoYoutubeESP.Entidades
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Comentario { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
