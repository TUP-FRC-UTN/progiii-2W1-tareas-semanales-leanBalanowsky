using EjemploPersona.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace EjemploPersona.AccesoDatos
{
    public class Ad_Reporte
    {
        public static List<SexoItemVM> obtenerCantidadPorSexoa()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConeccion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = @"SELECT Sexo.Nombre AS sexo, Count(*) AS cantidad
                                   FROM Sexo INNER JOIN Persona ON Sexo.Id = Persona.idSexo
                                   GROUP BY Sexo.Nombre; ";
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
                        aux.Nombre = dr["sexo"].ToString();
                        aux.Cantidad = int.Parse(dr["cantidad"].ToString());

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
        public static List<PersonaItemVM> obtenerListaPersona()
        {
            List<PersonaItemVM> resultado = new List<PersonaItemVM>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
            OleDbConnection conexion = new OleDbConnection(cadenaConeccion);

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string consulta = @"SELECT Persona.Id, Persona.Nombre, Persona.Apellido, Persona.dni, Persona.Edad, Sexo.Nombre AS sexo
                                   FROM Sexo INNER JOIN Persona ON Sexo.Id = Persona.idSexo; ";
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
                        PersonaItemVM aux = new PersonaItemVM();
                        aux.Id = int.Parse(dr["id"].ToString());
                        aux.Nombre = dr["nombre"].ToString();
                        aux.Apellido = dr["apellido"].ToString();
                        aux.Dni = int.Parse(dr["dni"].ToString());
                        aux.Edad = int.Parse(dr["edad"].ToString());
                        aux.NombreSexo = dr["sexo"].ToString();

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