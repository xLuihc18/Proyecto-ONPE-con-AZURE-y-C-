using ProyectoONPE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoONPE
{
    public partial class participacion : System.Web.UI.Page
    {
        L_Departamento objLogica = new L_Departamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResumenGeneral();
            }
        }

        private void CargarResumenGeneral()
        {
            double habiles = 22901954;
            double votantes = 18342896;
            double ausentes = habiles - votantes;

            double porcParticipacion = (votantes / habiles) * 100;
            double porcAusentismo = (ausentes / habiles) * 100;

            lblHabiles.Text = habiles.ToString("N0");
            lblParticipacionTotal.Text = votantes.ToString("N0");
            lblAusentismoTotal.Text = ausentes.ToString("N0");

            lblParticipacionPorcentaje.Text = porcParticipacion.ToString("F3");
            lblAusentismoPorcentaje.Text = porcAusentismo.ToString("F3");
        }
    }
}