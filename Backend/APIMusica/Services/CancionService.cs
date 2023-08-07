using APIMusica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace APIMusica.Services
{
    public class CancionesService : Controller
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

        public bool GuardarCancion(Canciones cancion)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("INSERT INTO canciones (ID_Artista, Cancion, ID_Genero,ID_Album,ID_Cancion) VALUES (@idArtista, @nombre_cancion, @idGenero,@idalbum,@idcancion)", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idArtista", cancion.ID_Artista));
                        com.Parameters.Add(new MySqlParameter("@nombre_cancion", cancion.Nombre_Cancion));
                        com.Parameters.Add(new MySqlParameter("@idGenero", cancion.ID_Genero));
                        com.Parameters.Add(new MySqlParameter("@idalbum", cancion.ID_Album));
                        com.Parameters.Add(new MySqlParameter("@idcancion", cancion.ID_Cancion));

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

        public bool EliminarCancion(int idCancion)
        {
            try
            {
                using (MySqlCommand com = new MySqlCommand("DELETE FROM canciones  WHERE ID_Cancion = @idcancion", new MySqlConnection(BuildConnection())))
                {
                    com.Connection.Open();

                    com.Parameters.Add(new MySqlParameter("@idcancion", idCancion));

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

        public List<Canciones> LeerCanciones()
        {
            List<Canciones> Canciones = new List<Canciones>();

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM canciones", conexion))
            {
                com.Connection.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var cancion = new Canciones();
                    cancion.ID_Cancion = Convert.ToInt32(reader["ID_Cancion"]);
                    cancion.ID_Album= Convert.ToInt32(reader["ID_Album"]);
                    cancion.Nombre_Cancion = Convert.ToString(reader["Cancion"]);
                    cancion.ID_Genero = Convert.ToInt32(reader["ID_Genero"]);
                    cancion.ID_Artista = Convert.ToInt32(reader["ID_Artista"]);
                    Canciones.Add(cancion);
                }
            }

            return Canciones;
        }

        public Canciones BuscarCancion(int idCancion)
        {
            Canciones cancion = null;

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM canciones WHERE ID_Cancion = @idcancion", conexion))
            {
                com.Connection.Open();
                com.Parameters.Add(new MySqlParameter("@idcancion", idCancion));
                MySqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    cancion = new Canciones();
                    cancion.ID_Cancion = Convert.ToInt32(reader["ID_Cancion"]);
                    cancion.ID_Album = Convert.ToInt32(reader["ID_Album"]);
                    cancion.Nombre_Cancion = Convert.ToString(reader["Cancion"]);
                    cancion.ID_Genero = Convert.ToInt32(reader["ID_Genero"]);
                    cancion.ID_Artista = Convert.ToInt32(reader["ID_Artista"]);
                }
            }

            return cancion;
        }

        public bool EditarCancion(int idCancion, Canciones cancion)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("UPDATE canciones SET ID_Artista = @idArtista, Cancion = @cancion, ID_Genero = @idGenero WHERE ID_Cancion = @idcancion", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idAlbum", idCancion));
                        com.Parameters.Add(new MySqlParameter("@idArtista", cancion.ID_Artista));
                        com.Parameters.Add(new MySqlParameter("@cancion", cancion.Nombre_Cancion));
                        com.Parameters.Add(new MySqlParameter("@idGenero", cancion.ID_Genero));
                        com.Parameters.Add(new MySqlParameter("@idcancion", cancion.ID_Cancion));

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
