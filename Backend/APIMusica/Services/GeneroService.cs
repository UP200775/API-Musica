using APIMusica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace APIMusica.Services
{
    public class GeneroService : Controller
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

        public List<Generos> LeerGeneros()
        {
            List<Generos> generos = new List<Generos>();

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM generos", conexion))
            {
                com.Connection.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var genero= new Generos();
                    genero.ID_Genero = Convert.ToInt32(reader["ID_Genero"]);
                    genero.Nombre_Genero = reader["Nombre_Genero"].ToString();
                    generos.Add(genero);
                }
            }

            return generos;
        }

        public bool GuardarGenero(Generos generos)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("INSERT INTO generos (ID_Genero, Nombre_Genero) VALUES (@idGenero, @nombre_genero)", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idGenero", generos.ID_Genero));
                        com.Parameters.Add(new MySqlParameter("@nombre_genero", generos.Nombre_Genero));

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

        public bool EliminarGenero(int idGenero)
        {
            try
            {
                using (MySqlCommand com = new MySqlCommand("DELETE FROM generos WHERE ID_Genero = @idGenero", new MySqlConnection(BuildConnection())))
                {
                    com.Connection.Open();

                    com.Parameters.Add(new MySqlParameter("@idGenero", idGenero));

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

        

        public Generos BuscarGenero(int idGenero)
        {
            Generos genero = null;

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM generos WHERE ID_Genero = @idGenero", conexion))
            {
                com.Connection.Open();
                com.Parameters.Add(new MySqlParameter("@idGenero", idGenero));
                MySqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    genero = new Generos();
                    genero.ID_Genero = Convert.ToInt32(reader["ID_Genero"]);
                    genero.Nombre_Genero = reader["Nombre_Genero"].ToString();
                }
            }

            return genero;
        }

        public bool EditarGenero(int idGenero, Generos generos)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("UPDATE generos SET ID_Genero = @idGenero, Nombre_Genero = @nombre_genero WHERE ID_Genero = @idGenero", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@idGenero", idGenero));
                        com.Parameters.Add(new MySqlParameter("@nombre_genero", generos.Nombre_Genero));
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
