using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoONPE.Modelos
{
    public class Departamento
    {
        public int idDepartamento { get; set; }
        public string Detalle { get; set; }
    }

    public class Provincia
    {
        public int idProvincia { get; set; }
        public int idDepartamento { get; set; }
        public string Detalle { get; set; }
    }

    public class Distrito
    {
        public int idDistrito { get; set; }
        public int idProvincia { get; set; }
        public string Detalle { get; set; }
    }

    public class LocalVotacion
    {
        public int idLocalVotacion { get; set; }
        public int idDistrito { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
    }

    public class GrupoVotacion
    {
        public string idGrupoVotacion { get; set; }
        public string nCopia { get; set; }
        public int idEstadoActa { get; set; }
        public int ElectoresHabiles { get; set; }
        public int TotalVotantes { get; set; }
    }

    public class ResultadoMesa
    {
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string idGrupoVotacion { get; set; }
        public string nCopia { get; set; }
        public int idEstadoActa { get; set; }
        public int ElectoresHabiles { get; set; }
        public int TotalVotantes { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int VotosBlancos { get; set; }
        public int VotosNulos { get; set; }
        public int VotosImpugnados { get; set; }
    }

    public class Participacion
    {
        public string DPD { get; set; } //Departamento, Provincia, Distrito
        public long TV { get; set; }    //Total votantes (Asistentes)
        public string PTV { get; set; } //Porcentaje Total votantes
        public long TA { get; set; }    //Total ausentes
        public string PTA { get; set; } //Porcentaje total ausentes
        public long EH { get; set; }    //Electores Habiles
    }
}