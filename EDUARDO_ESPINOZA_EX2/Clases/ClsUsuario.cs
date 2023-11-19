using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EDUARDO_ESPINOZA_EX2.Clases
{
    public class ClsUsuario
    {
        public string nombre { get; set; }

        public string correo { get; set; }

        public string numero { get; set; }

        public ClsUsuario(string Nombre, string Correo, string Numero)
        {
            nombre = Nombre;
            numero = Numero;
            correo = Correo;
        }
        public ClsUsuario() { }

        public static int AgregarUsuario(string nombre, string correo, string numero)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregar_usuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@numero", numero));

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
        public static int BorrarUsuario(int idU)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrar_usuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@cedula", idU));


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

        public static int ModificarUsuario(int idU, string nombre, string correo, string numero)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificar_usuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@cedula", idU));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@numero", numero));


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
        public static List<ClsUsuario> ConsultaFiltroUsuarios(int idU)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<ClsUsuario> usuarios = new List<ClsUsuario>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar_filtro_usuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@cedula", idU));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClsUsuario usuario = new ClsUsuario(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            usuarios.Add(usuario);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return usuarios;
        }
    }
}