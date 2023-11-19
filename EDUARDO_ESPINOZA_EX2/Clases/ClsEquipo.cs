using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EDUARDO_ESPINOZA_EX2.Clases
{
    public class ClsEquipo
    {
        public int idusuario { get; set; }
        public string tipo { get; set; }

        public string modelo { get; set; }

        public ClsEquipo(int Idusuario, string Tipo, string Modelo)
        {
            idusuario = Idusuario;
            tipo = Tipo;
            modelo = Modelo;
        }
        public ClsEquipo() { }

        public static int AgregarEquipo(string tipo, string modelo, int idusuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregar_equipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@idusuario", idusuario));

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
        public static int BorrarEquipo(int idE)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrar_equipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@serie", idE));


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

        public static int ModificarEquipo(int idE, string tipo, string modelo, int idusuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificar_equipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@serie", idE));
                    cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@idusuario", idusuario));


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
        public static List<ClsEquipo> ConsultaFiltroEquipos(int idE)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<ClsEquipo> equipos = new List<ClsEquipo>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAR_FILTROTIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@serie", idE));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClsEquipo equipo = new ClsEquipo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            equipos.Add(equipo);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return equipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return equipos;
        }
    }
}