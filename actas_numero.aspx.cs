using ProyectoONPE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoONPE
{
    public partial class actas_numero : System.Web.UI.Page
    {
        L_Departamento objLogica = new L_Departamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nroMesa = txtNroMesa.Text.Trim();

            if (string.IsNullOrEmpty(nroMesa)) return;

            var res = objLogica.ObtenerResultado(nroMesa);

            if (res != null)
            {
                pnlError.Visible = false;
                divDetalleMesa.Visible = true;

                //Información General
                lblMesaNumero.Text = res.idGrupoVotacion;
                lblCopia.Text = "96A";

                lblDepInfo.Text = res.Departamento;
                lblProvInfo.Text = res.Provincia;
                lblDistInfo.Text = res.Distrito;
                lblLocalInfo.Text = res.RazonSocial;
                lblDireccionInfo.Text = res.Direccion;

                //Mesa 
                lblElectoresHabiles.Text = res.ElectoresHabiles.ToString();
                lblTotalVotantes.Text = res.TotalVotantes.ToString();
                lblEstadoActa.Text = "ACTA ELECTORAL NORMAL";

                //Votos detallados
                lblVotosPPK.Text = res.P1.ToString();
                lblVotosKeiko.Text = res.P2.ToString();
                lblVotosBlanco.Text = res.VotosBlancos.ToString();
                lblVotosNulos.Text = res.VotosNulos.ToString();
                lblVotosImpugnados.Text = res.VotosImpugnados.ToString();

                int total = res.P1 + res.P2 + res.VotosBlancos + res.VotosNulos + res.VotosImpugnados;
                lblTotalEmitidos.Text = total.ToString();
            }
            else
            {
                divDetalleMesa.Visible = false;
                pnlError.Visible = true;
            }
        }
    }
}