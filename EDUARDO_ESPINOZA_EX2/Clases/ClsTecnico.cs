using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EDUARDO_ESPINOZA_EX2.Clases
{
    public class ClsTecnico
    {
        public string nombre { get; set; }

        public string especialidad { get; set; }

        public ClsTecnico(string Nombre, string Especialidad)
        {
            nombre = Nombre;
            especialidad = Especialidad;
        }
        public ClsTecnico() { }

        public static int AgregarTecnico(string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregar_tecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@especialidad", especialidad));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int BorrarTecnico(int idT)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrar_tecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@cedula", idT));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int ModificarTecnico(int idT, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificar_tecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@cedula", idT));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@especialidad", especialidad));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static List<ClsTecnico> ConsultaFiltroTecnicos(int idT)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<ClsTecnico> tecnicos = new List<ClsTecnico>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar_filtro_tecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@cedula", idT));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClsTecnico tecnico = new ClsTecnico(reader.GetString(0), reader.GetString(1));
                            tecnicos.Add(tecnico);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return tecnicos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return tecnicos;
        }
    }
}