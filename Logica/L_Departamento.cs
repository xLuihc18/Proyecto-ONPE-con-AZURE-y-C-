//Mi puente de datos
using System.Collections.Generic;
using ProyectoONPE.Datos;
using ProyectoONPE.Modelos;

namespace ProyectoONPE.Logica
{
    public class L_Departamento
    {
        D_Departamento objDatos = new D_Departamento();

        public List<Departamento> Listar() => objDatos.ListarDepartamentos();

        public List<Provincia> ListarProvincias(int idDep) => objDatos.ListarProvincias(idDep);

        public List<Distrito> ListarDistritos(int idProv) => objDatos.ListarDistritos(idProv);

        public List<LocalVotacion> ListarLocales(int idDistrito) => objDatos.ListarLocales(idDistrito);

        public List<GrupoVotacion> ListarGrupos(int idLocal) => objDatos.ListarGrupos(idLocal);

        public ResultadoMesa ObtenerResultado(string idMesa)
        {
            return objDatos.ObtenerResultado(idMesa);
        }

        public List<Departamento> ListarDepartamentosPorAmbito(int inicio, int fin)
        {
            return objDatos.ListarDepartamentosPorAmbito(inicio, fin);
        }

        public List<Participacion> ListarParticipacion(string tipo, string valor)
        {
            return objDatos.GetParticipacion(tipo, valor);
        }

    }
}