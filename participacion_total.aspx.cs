using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoONPE.Logica;
using ProyectoONPE.Modelos;
namespace ProyectoONPE
{
    public partial class participacion_total : System.Web.UI.Page
    {
        L_Departamento objLogica = new L_Departamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDepartamentos();
                ActualizarDatos("Nacional", "25");
            }
        }

        private void CargarDepartamentos()
        {
            ddlDepartamento.DataSource = objLogica.Listar();
            ddlDepartamento.DataTextField = "Detalle";
            ddlDepartamento.DataValueField = "idDepartamento";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        }


        private void ActualizarDatos(string tipo, string valor)
        {
            Participacion resumen = null;
            List<Participacion> lista = null;

            if (tipo == "Distrito")
            {
                lista = objLogica.ListarParticipacion("Distrito", ddlProvincia.SelectedItem.Text);

                if (lista != null)
                {
                    resumen = lista.FirstOrDefault(x => x.DPD.Trim().Equals(valor.Trim(), StringComparison.OrdinalIgnoreCase));
                }
            }
            else
            {
                lista = objLogica.ListarParticipacion(tipo, valor);
            }

            if (lista != null && lista.Count > 0)
            {
                if (tipo != "Distrito")
                {
                    resumen = new Participacion
                    {
                        EH = lista.Sum(x => x.EH),
                        TV = lista.Sum(x => x.TV),
                        TA = lista.Sum(x => x.TA)
                    };

                    if (resumen.EH > 0)
                    {
                        lblParticipacionPorc.Text = ((double)resumen.TV / resumen.EH * 100).ToString("N3");
                        lblAusentismoPorc.Text = ((double)resumen.TA / resumen.EH * 100).ToString("N3");
                    }
                }
                else if (resumen != null)
                {
                    lblParticipacionPorc.Text = resumen.PTV.Replace("%", "").Trim();
                    lblAusentismoPorc.Text = resumen.PTA.Replace("%", "").Trim();
                }

                if (resumen != null)
                {
                    lblHabilesTotal.Text = resumen.EH.ToString("N0");
                    lblParticipacionTotal.Text = resumen.TV.ToString("N0");
                    lblAusentismoTotal.Text = resumen.TA.ToString("N0");
                }

                lblAmbito.Text = valor;

                rpParticipacion.DataSource = lista;
                rpParticipacion.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "graph", "drawChart();", true);
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartamento.SelectedValue != "0")
            {
                string idDep = ddlDepartamento.SelectedValue;
                string nombreDep = ddlDepartamento.SelectedItem.Text;
                lblAmbito.Text = nombreDep;

                ddlProvincia.DataSource = objLogica.ListarProvincias(int.Parse(idDep));
                ddlProvincia.DataTextField = "Detalle";
                ddlProvincia.DataValueField = "idProvincia";
                ddlProvincia.DataBind();
                ddlProvincia.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));

                ddlDistrito.Items.Clear();

                ActualizarDatos("Departamento", nombreDep);
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvincia.SelectedValue != "0")
            {
                string idProv = ddlProvincia.SelectedValue;
                string nombreProv = ddlProvincia.SelectedItem.Text;
                lblAmbito.Text = nombreProv;

                ddlDistrito.DataSource = objLogica.ListarDistritos(int.Parse(idProv));
                ddlDistrito.DataTextField = "Detalle";
                ddlDistrito.DataValueField = "idDistrito";
                ddlDistrito.DataBind();
                ddlDistrito.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));

                ActualizarDatos("Provincia", nombreProv);
            }
        }

        protected void ddlDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrito.SelectedValue != "0")
            {
                string nombreProvincia = ddlProvincia.SelectedItem.Text;
                string nombreDistrito = ddlDistrito.SelectedItem.Text;

                ActualizarDatos("Distrito", nombreDistrito);
            }
        }
    }
}