using EjemploPersona.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EjemploPersona.AccesoDatos
{
    public class AD_Persona
    {
        public static bool Insertar(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConexion); 

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = "INSERT INTO Persona (nombre, apellido, dni, edad) VALUES (@nombre , @apellido, @dni, @edad)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", p.Nombre);
                comando.Parameters.AddWithValue("@apellido", p.Apellido);
                comando.Parameters.AddWithValue("@dni", p.Dni);
                comando.Parameters.AddWithValue("@edad", p.Edad);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
        public static List<Persona> obtenerListaPersona()
        {
            List<Persona> resultado = new List<Persona>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConeccion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = "SELECT * FROM Persona";
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                OleDbDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    while(dr.Read())
                    {
                        Persona aux = new Persona();
                        aux.Id = int.Parse(dr["id"].ToString());
                        aux.Nombre = dr["nombre"].ToString();
                        aux.Apellido = dr["apellido"].ToString();
                        aux.Dni = int.Parse(dr["dni"].ToString());
                        aux.Edad = int.Parse(dr["edad"].ToString());

                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
    }
}