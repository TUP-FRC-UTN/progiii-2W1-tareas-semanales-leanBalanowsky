using EjemploPersona.Models;
using EjemploPersona.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
                string consulta = "INSERT INTO Persona (nombre, apellido, dni, edad, idSexo) VALUES (@nombre , @apellido, @dni, @edad, @idSexo)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", p.Nombre);
                comando.Parameters.AddWithValue("@apellido", p.Apellido);
                comando.Parameters.AddWithValue("@dni", p.Dni);
                comando.Parameters.AddWithValue("@edad", p.Edad);
                comando.Parameters.AddWithValue("@idSexo", p.IdSexo);

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
        public static Persona ObtenerPersona(int id)
        {
            Persona resultado = new Persona();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConeccion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = "SELECT * FROM Persona WHERE Id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Id", id);
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                OleDbDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.Id = int.Parse(dr["id"].ToString());
                        resultado.Nombre = dr["nombre"].ToString();
                        resultado.Apellido = dr["apellido"].ToString();
                        resultado.Dni = int.Parse(dr["dni"].ToString());
                        resultado.Edad = int.Parse(dr["edad"].ToString());
                        resultado.IdSexo = int.Parse(dr["idSexo"].ToString());
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
        public static bool Actualizar(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConexion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = "UPDATE Persona SET nombre = @nombre, apellido = @apellido, dni = @dni, edad = @edad, idSexo = @idSexo WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", p.Nombre);
                comando.Parameters.AddWithValue("@apellido", p.Apellido);
                comando.Parameters.AddWithValue("@dni", p.Dni);
                comando.Parameters.AddWithValue("@edad", p.Edad);
                comando.Parameters.AddWithValue("@idSexo", p.IdSexo);
                comando.Parameters.AddWithValue("@id", p.Id);
                

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
        public static bool Eliminar(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConexion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = "DELETE FROM Persona WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", p.Id);

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
        public static List<SexoItemVM> obtenerListaSexos()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConeccion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = "SELECT * FROM Sexo";
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                OleDbDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        SexoItemVM aux = new SexoItemVM();
                        aux.IdSexo = int.Parse(dr["id"].ToString());
                        aux.Nombre = dr["nombre"].ToString();
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
