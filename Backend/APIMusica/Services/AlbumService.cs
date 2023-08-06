using APIMusica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace APIMusica.Services
{
    public class AlbumService : Controller
    {
        private string BuildConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Database = "musica";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "";

            return builder.ConnectionString;
        }

        public bool GuardarAlbum(Albumes albumes)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("INSERT INTO albumes (ID_Artista, Nombre_Album, ID_Genero) VALUES (@idArtista, @nombre_album, @idGenero)", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idArtista", albumes.ID_Artista));
                        com.Parameters.Add(new MySqlParameter("@nombre_album", albumes.Nombre_Album));
                        com.Parameters.Add(new MySqlParameter("@idGenero", albumes.ID_Genero));

                        int rowsAffected = com.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool EliminarAlbum(int idAlbum)
        {
            try
            {
                using (MySqlCommand com = new MySqlCommand("DELETE FROM albumes WHERE ID_Album = @idAlbum", new MySqlConnection(BuildConnection())))
                {
                    com.Connection.Open();

                    com.Parameters.Add(new MySqlParameter("@idAlbum", idAlbum));

                    int rowsAffected = com.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Albumes> LeerAlbumes()
        {
            List<Albumes> albums = new List<Albumes>();

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM albumes", conexion))
            {
                com.Connection.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var album = new Albumes();
                    album.ID_Album = Convert.ToInt32(reader["ID_Album"]);
                    album.ID_Artista = Convert.ToInt32(reader["ID_Artista"]);
                    album.Nombre_Album = reader["Nombre_Album"].ToString();
                    album.ID_Genero = Convert.ToInt32(reader["ID_Genero"]);

                    albums.Add(album);
                }
            }

            return albums;
        }

        public Albumes BuscarAlbum(int idAlbum)
        {
            Albumes album = null;

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM albumes WHERE ID_Album = @idAlbum", conexion))
            {
                com.Connection.Open();
                com.Parameters.Add(new MySqlParameter("@idAlbum", idAlbum));
                MySqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    album = new Albumes();
                    album.ID_Album = Convert.ToInt32(reader["ID_Album"]);
                    album.ID_Artista = Convert.ToInt32(reader["ID_Artista"]);
                    album.Nombre_Album = reader["Nombre_Album"].ToString();
                    album.ID_Genero = Convert.ToInt32(reader["ID_Genero"]);
                }
            }

            return album;
        }

        public bool EditarAlbum(int idAlbum, Albumes albumes)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("UPDATE albumes SET ID_Artista = @idArtista, Album = @album, ID_Genero = @idGenero WHERE ID_Album = @idAlbum", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idAlbum", idAlbum));
                        com.Parameters.Add(new MySqlParameter("@idArtista", albumes.ID_Artista));
                        com.Parameters.Add(new MySqlParameter("@album", albumes.Nombre_Album));
                        com.Parameters.Add(new MySqlParameter("@idGenero", albumes.ID_Genero));

                        int rowsAffected = com.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
