using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDUARDO_ESPINOZA_EX2.Clases;
using System.Diagnostics;

namespace EDUARDO_ESPINOZA_EX2
{
    public partial class usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridViewUsuario.DataSource = dt;
                            GridViewUsuario.DataBind();
                        }
                    }
                }
            }
        }

        protected void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsUsuario.AgregarUsuario(TxtIDU.Text, TxtCU.Text,TxtNU.Text);

            if (resultado > 0)
            {
                alertas("Usuario ha sido ingresado con exito");
                TxtIDU.Text = string.Empty;
                TxtCU.Text = string.Empty;
                TxtNU.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar usuario");

            }
        }

        protected void BtnBorrarUsuario_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsUsuario.BorrarUsuario(int.Parse(TxtCodU.Text));

            if (resultado > 0)
            {
                alertas("Usuario ha sido borrado con exito");
                TxtCodU.Text = string.Empty;
                TxtIDU.Text = string.Empty;
                TxtCU.Text = string.Empty;
                TxtNU.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar usuario");

            }
        }

        protected void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsUsuario.ModificarUsuario(int.Parse(TxtCodU.Text),TxtIDU.Text, TxtCU.Text, TxtNU.Text);

            if (resultado > 0)
            {
                alertas("Usuario ha sido modificado con exito");
                TxtCodU.Text = string.Empty;
                TxtIDU.Text = string.Empty;
                TxtCU.Text = string.Empty;
                TxtNU.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar usuario");

            }
        }

        protected void BtnConsultarUsuario_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCodU.Text);
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT* FROM usuarios WHERE id ='" + id + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridViewUsuario.DataSource = dt;
                        GridViewUsuario.DataBind();
                    }
                }
            }
        }
    }
}