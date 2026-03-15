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
                // Llamada inicial: Tipo "Nacional", Valor "25" (o "Todos")
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

        // CORRECCIÓN: Ahora recibe dos parámetros para coincidir con la Lógica y Datos
        private void ActualizarDatos(string tipo, string valor)
        {
            var lista = objLogica.ListarParticipacion(tipo, valor);

            if (lista != null && lista.Count > 0)
            {
                var resumen = lista[0];

                // Asignación de etiquetas principales
                lblHabilesTotal.Text = resumen.EH.ToString("N0");
                lblParticipacionTotal.Text = resumen.TV.ToString("N0");
                lblAusentismoTotal.Text = resumen.TA.ToString("N0");

                // Limpiamos el símbolo % para que el gráfico de Google lo lea como número
                lblParticipacionPorc.Text = resumen.PTV.Replace(" %", "").Trim();
                lblAusentismoPorc.Text = resumen.PTA.Replace(" %", "").Trim();

                // Refrescar la tabla
                rpParticipacion.DataSource = lista;
                rpParticipacion.DataBind();
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartamento.SelectedValue != "0")
            {
                string idDep = ddlDepartamento.SelectedValue;
                string nombreDep = ddlDepartamento.SelectedItem.Text;
                lblAmbito.Text = nombreDep;

                // Cargar Provincias
                ddlProvincia.DataSource = objLogica.ListarProvincias(int.Parse(idDep));
                ddlProvincia.DataTextField = "Detalle";
                ddlProvincia.DataValueField = "idProvincia";
                ddlProvincia.DataBind();
                ddlProvincia.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));

                ddlDistrito.Items.Clear();

                // LLAMADA CORREGIDA: Tipo "Departamento", Valor el nombre
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

                // Cargar Distritos
                ddlDistrito.DataSource = objLogica.ListarDistritos(int.Parse(idProv));
                ddlDistrito.DataTextField = "Detalle";
                ddlDistrito.DataValueField = "idDistrito";
                ddlDistrito.DataBind();
                ddlDistrito.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));

                // LLAMADA CORREGIDA: Tipo "Provincia", Valor el nombre
                ActualizarDatos("Provincia", nombreProv);
            }
        }

        protected void ddlDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrito.SelectedValue != "0")
            {
                string nombreDist = ddlDistrito.SelectedItem.Text;
                lblAmbito.Text = nombreDist;

                // LLAMADA CORREGIDA: Ajustado a lo que pida tu SP de distritos
                ActualizarDatos("Distrito", nombreDist);
            }
        }
    }
}