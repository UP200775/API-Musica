using APIMusica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace APIMusica.Services
{
    public class ArtistaService : Controller
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

        public bool GuardarArtista(Artistas artista)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("INSERT INTO artistas (ID_Artista, Nombre_Artista, Nacionalidad_Artista, ID_Genero) VALUES (@idArtista, @nombreArtista, @nacionalidadArtista, @idGenero)", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idArtista", artista.IdArtista));
                        com.Parameters.Add(new MySqlParameter("@nombreArtista", artista.NombreArtista));
                        com.Parameters.Add(new MySqlParameter("@nacionalidadArtista", artista.NacionalidadArtista));
                        com.Parameters.Add(new MySqlParameter("@idGenero", artista.IdGenero));

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

        public bool EliminarArtista(int idArtista)
        {
            try
            {
                using (MySqlCommand com = new MySqlCommand("DELETE FROM artistas WHERE ID_Artista = @idArtista", new MySqlConnection(BuildConnection())))
                {
                    com.Connection.Open();

                    com.Parameters.Add(new MySqlParameter("@idArtista", idArtista));

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

        public List<Artistas> LeerArtistas()
        {
            List<Artistas> artistas = new List<Artistas>();

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM artistas", conexion))
            {
                com.Connection.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var artista = new Artistas();
                    artista.IdArtista = Convert.ToInt32(reader["ID_Artista"]);
                    artista.NombreArtista = reader["Nombre_Artista"].ToString();
                    artista.NacionalidadArtista = reader["Nacionalidad_Artista"].ToString();
                    artista.IdGenero = Convert.ToInt32(reader["ID_Genero"]);

                    artistas.Add(artista);
                }
            }

            return artistas;
        }

        public Artistas BuscarArtista(int idArtista)
        {
            Artistas artista = null;

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM artistas WHERE ID_Artista = @idArtista", conexion))
            {
                com.Connection.Open();
                com.Parameters.Add(new MySqlParameter("@idArtista", idArtista));
                MySqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    artista = new Artistas();
                    artista.IdArtista = Convert.ToInt32(reader["ID_Artista"]);
                    artista.NombreArtista = reader["Nombre_Artista"].ToString();
                    artista.NacionalidadArtista = reader["Nacionalidad_Artista"].ToString();
                    artista.IdGenero = Convert.ToInt32(reader["ID_Genero"]);
                }
            }

            return artista;
        }

        public bool EditarArtista(int idArtista, Artistas artista)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("UPDATE artistas SET ID_Artista = @idArtista, Nombre_Artista = @nombreArtista, Nacionalidad_Artista = @nacionalidadArtista, ID_Genero = @idGenero WHERE ID_Artista = @idArtistaToUpdate", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idArtistaToUpdate", idArtista));
                        com.Parameters.Add(new MySqlParameter("@idArtista", artista.IdArtista));
                        com.Parameters.Add(new MySqlParameter("@nombreArtista", artista.NombreArtista));
                        com.Parameters.Add(new MySqlParameter("@nacionalidadArtista", artista.NacionalidadArtista));
                        com.Parameters.Add(new MySqlParameter("@idGenero", artista.IdGenero));

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
