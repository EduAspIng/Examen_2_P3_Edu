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
    public partial class tecnico : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridViewTecnico.DataSource = dt;
                            GridViewTecnico.DataBind();
                        }
                    }
                }
            }
        }

        protected void BtnAgregarTecnico_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsTecnico.AgregarTecnico(TxtNT.Text, TxtET.Text);

            if (resultado > 0)
            {
                alertas("Tecnico ha sido ingresado con exito");
                TxtNT.Text = string.Empty;
                TxtET.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Tecnico");

            }

        }

        protected void BtnBorrarTecnico_Click(object sender, EventArgs e)
        {
             int resultado = Clases.ClsTecnico.BorrarTecnico(int.Parse(TxtCT.Text));

            if (resultado > 0)
            {
                alertas("Tecnico ha sido borrado con exito");
                TxtCT.Text = string.Empty;
                TxtNT.Text = string.Empty;
                TxtET.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Tecnico");

            }
        }

        protected void BtnModificarTecnico_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsTecnico.ModificarTecnico(int.Parse(TxtCT.Text), TxtNT.Text, TxtET.Text);

            if (resultado > 0)
            {
                alertas("Tecnico ha sido modificado con exito");
                TxtCT.Text = string.Empty;
                TxtNT.Text = string.Empty;
                TxtET.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Tecnico");

            }
        }

        protected void BtnConsultarTecnico_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCT.Text);
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT* FROM tecnicos WHERE id ='" + id + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridViewTecnico.DataSource = dt;
                        GridViewTecnico.DataBind();
                    }
                }
            }
        }
    }
}