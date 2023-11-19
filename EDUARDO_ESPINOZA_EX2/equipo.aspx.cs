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

namespace EDUARDO_ESPINOZA_EX2
{
    public partial class equipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarEquipos();
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridViewEquipo.DataSource = dt;
                            GridViewEquipo.DataBind(); 
                        }
                    }
                }
            }
        }
        protected void LlenarEquipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(" SELECT id, nombre from usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DDIDU.DataSource = dt;

                            DDIDU.DataTextField = dt.Columns["nombre"].ToString();
                            DDIDU.DataValueField = dt.Columns["id"].ToString();
                            DDIDU.DataBind();
                        }
                    }
                }
            }
        }
        protected void BtnAgregarEquipo_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsEquipo.AgregarEquipo(TxtTE.Text, TxtME.Text, int.Parse(DDIDU.SelectedValue));

            if (resultado > 0)
            {
                alertas("Equipo ha sido ingresado con exito");
                TxtCE.Text = string.Empty;
                TxtTE.Text = string.Empty;
                TxtME.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar equipo");

            }
        }

        protected void BtnBorrarEquipo_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsEquipo.BorrarEquipo(int.Parse(TxtCE.Text));

            if (resultado > 0)
            {
                alertas("Equipo ha sido borrado con exito");
                TxtCE.Text = string.Empty;
                TxtTE.Text = string.Empty;
                TxtME.Text = string.Empty;

                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar equipo");

            }
        }

        protected void BtnModificarEquipo_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsEquipo.ModificarEquipo(int.Parse(TxtCE.Text), TxtTE.Text, TxtME.Text, int.Parse(DDIDU.SelectedValue));

            if (resultado > 0)
            {
                alertas("Equipo ha sido modificado con exito");
                TxtCE.Text = string.Empty;
                TxtTE.Text = string.Empty;
                TxtME.Text = string.Empty;

                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar equipo");

            }
        }

        protected void BtnConsultarEquipo_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCE.Text);
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT* FROM equipos WHERE id ='" + id + "'")) 


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridViewEquipo.DataSource = dt;
                        GridViewEquipo.DataBind(); 
                    }
                }
            }
        }
    }
}