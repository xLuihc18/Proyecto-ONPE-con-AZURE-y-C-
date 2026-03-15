using System;
using System.Web.UI.WebControls;
using ProyectoONPE.Logica;

namespace ProyectoONPE
{
    public partial class actas_ubigeo : System.Web.UI.Page
    {
        L_Departamento objLogica = new L_Departamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDepartamentos();
            }
        }

        private void CargarDepartamentos()
        {
            ddlDepartamento.DataSource = objLogica.Listar();
            ddlDepartamento.DataTextField = "Detalle";
            ddlDepartamento.DataValueField = "idDepartamento";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("-- SELECCIONE DEP --", "0"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDep = int.Parse(ddlDepartamento.SelectedValue);
            ddlProvincia.Items.Clear();
            if (idDep > 0)
            {
                ddlProvincia.DataSource = objLogica.ListarProvincias(idDep);
                ddlProvincia.DataTextField = "Detalle";
                ddlProvincia.DataValueField = "idProvincia";
                ddlProvincia.DataBind();
            }
            ddlProvincia.Items.Insert(0, new ListItem("-- SELECCIONE PROVINCIA --", "0"));
            ddlDistrito.Items.Clear();
            ddlDistrito.Items.Insert(0, new ListItem("-- SELECCIONE DISTRITO --", "0"));
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProv = int.Parse(ddlProvincia.SelectedValue);
            ddlDistrito.Items.Clear();
            if (idProv > 0)
            {
                ddlDistrito.DataSource = objLogica.ListarDistritos(idProv);
                ddlDistrito.DataTextField = "Detalle";
                ddlDistrito.DataValueField = "idDistrito";
                ddlDistrito.DataBind();
            }
            ddlDistrito.Items.Insert(0, new ListItem("-- SELECCIONE DISTRITO --", "0"));
        }

        protected void ddlDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDist = int.Parse(ddlDistrito.SelectedValue);
            ddlLocal.Items.Clear();
            if (idDist > 0)
            {
                ddlLocal.DataSource = objLogica.ListarLocales(idDist);
                ddlLocal.DataTextField = "RazonSocial";
                ddlLocal.DataValueField = "idLocalVotacion";
                ddlLocal.DataBind();
            }
            ddlLocal.Items.Insert(0, new ListItem("-- SELECCIONE LOCAL --", "0"));
        }

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLocal = int.Parse(ddlLocal.SelectedValue);
            if (idLocal > 0)
            {
                rpMesas.DataSource = objLogica.ListarGrupos(idLocal);
                rpMesas.DataBind();
            }
        }

        private void CargarResultadoMesa(string idMesa)
        {
            
            var res = objLogica.ObtenerResultado(idMesa);

            if (res != null)
            {
                lblMesaNumero.Text = res.idGrupoVotacion;
                lblElectoresHabiles.Text = res.ElectoresHabiles.ToString();
                lblTotalVotantes.Text = res.TotalVotantes.ToString();
                lblEstadoActa.Text = "ACTA ELECTORAL NORMAL"; 

                lblDepInfo.Text = res.Departamento;
                lblProvInfo.Text = res.Provincia;
                lblDistInfo.Text = res.Distrito;
                lblLocalInfo.Text = res.RazonSocial;
                lblDireccionInfo.Text = res.Direccion;

                lblVotosPPK.Text = res.P1.ToString();
                lblVotosKeiko.Text = res.P2.ToString();
                lblVotosBlanco.Text = res.VotosBlancos.ToString();
                lblVotosNulos.Text = res.VotosNulos.ToString();
                lblVotosImpugnados.Text = res.VotosImpugnados.ToString();

                divDetalleMesa.Visible = true;
            }
        }

        protected void btnVerMesa_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idMesa = btn.CommandArgument;

            CargarResultadoMesa(idMesa);
        }

        protected void ddlAmbito_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ddlDepartamento.Items.Clear();
            ddlProvincia.Items.Clear();
            ddlDistrito.Items.Clear();
            ddlLocal.Items.Clear();
            rpMesas.DataSource = null;
            rpMesas.DataBind();

            if (ddlAmbito.SelectedValue == "1") 
            {
                CargarDepartamentosFiltrados(1, 25);
            }
            else 
            {
                CargarDepartamentosFiltrados(26, 100);
            }
        }

        private void CargarDepartamentosFiltrados(int inicio, int fin)
        {
            ddlDepartamento.DataSource = objLogica.ListarDepartamentosPorAmbito(inicio, fin);
            ddlDepartamento.DataTextField = "Detalle";
            ddlDepartamento.DataValueField = "idDepartamento";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        }


    }
}