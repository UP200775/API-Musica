namespace APIMusica.Models
{
    public class Canciones
    {
        public int ID_Cancion { get; set; }
        public string Nombre_Cancion { get; set; }
        public int ID_Artista { get; set; }
        public int ID_Genero { get; set; }
        public int ID_Album { get; set; }
    }
}
