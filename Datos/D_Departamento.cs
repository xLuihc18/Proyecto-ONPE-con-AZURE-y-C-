using ProyectoONPE.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoONPE.Datos
{
    //Gestiona las operaciones del CRUD y Consultas SQL
    public class D_Departamento : Conexion
    {
        //Lista de Depatamentos
        public List<Departamento> ListarDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();
            using (SqlConnection cn = Conectar())
            {
                SqlCommand cmd = new SqlCommand("usp_getDepartamentos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Departamento
                        {
                            idDepartamento = (int)dr["idDepartamento"],
                            Detalle = dr["Detalle"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
        //Lista de Provincias
        public List<Provincia> ListarProvincias(int idDep)
        {
            List<Provincia> lista = new List<Provincia>();
            using (SqlConnection cn = Conectar())
            {
                SqlCommand cmd = new SqlCommand("usp_getProvincias", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDepartamento", idDep);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Provincia
                        {
                            idProvincia = (int)dr["idProvincia"],
                            Detalle = dr["Detalle"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
        //Lista de Distritos
        public List<Distrito> ListarDistritos(int idProv)
        {
            List<Distrito> lista = new List<Distrito>();
            using (SqlConnection cn = Conectar())
            {
                SqlCommand cmd = new SqlCommand("usp_getDistritos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProvincia", idProv);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Distrito
                        {
                            idDistrito = (int)dr["idDistrito"],
                            Detalle = dr["Detalle"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        //Lista de Votacion
        public List<LocalVotacion> ListarLocales(int idDistrito)
        {
            List<LocalVotacion> lista = new List<LocalVotacion>();
            using (SqlConnection cn = Conectar())
            {
                SqlCommand cmd = new SqlCommand("usp_getLocalesVotacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDistrito", idDistrito);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new LocalVotacion()
                        {
                            idLocalVotacion = (int)dr["idLocalVotacion"],
                            RazonSocial = dr["RazonSocial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        //Lista de Grupos
        public List<GrupoVotacion> ListarGrupos(int idLocal)
        {
            List<GrupoVotacion> lista = new List<GrupoVotacion>();
            using (SqlConnection cn = Conectar())
            {
                SqlCommand cmd = new SqlCommand("usp_getGruposVotacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLocalVotacion", idLocal);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new GrupoVotacion
                        {
                            idGrupoVotacion = dr["idGrupoVotacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        //Resultados de mesa detallado
        public ResultadoMesa ObtenerResultado(string idMesa)
        {
            ResultadoMesa r = null;
            using (SqlConnection cn = Conectar())
            {
                SqlCommand cmd = new SqlCommand("usp_getGrupoVotacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idGrupoVotacion", idMesa);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        r = new ResultadoMesa
                        {
                            idGrupoVotacion = dr["idGrupoVotacion"].ToString(),
                            Provincia = dr["Provincia"].ToString(),
                            Distrito = dr["Distrito"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            ElectoresHabiles = (int)dr["ElectoresHabiles"],
                            TotalVotantes = (int)dr["TotalVotantes"],
                            P1 = (int)dr["P1"], //PPK :v
                            P2 = (int)dr["P2"], //Keiko
                            VotosBlancos = (int)dr["VotosBlancos"],
                            VotosNulos = (int)dr["VotosNulos"],
                            VotosImpugnados = (int)dr["VotosImpugnados"]
                        };
                    }
                }
            }
            return r;
        }

        //Lista de Departamentos por ambito 
        public List<Departamento> ListarDepartamentosPorAmbito(int inicio, int fin)
        {
            List<Departamento> lista = new List<Departamento>();
            using (SqlConnection cn = Conectar())
            {
              
                SqlCommand cmd = new SqlCommand("usp_getDepartamentos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = (int)dr["idDepartamento"];
                        if (id >= inicio && id <= fin)
                        {
                            lista.Add(new Departamento
                            {
                                idDepartamento = id,
                                Detalle = dr["Detalle"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        //Estadicticas de participacion por ambito
        public List<Participacion> GetParticipacion(string tipo, string valor)
        {
            List<Participacion> lista = new List<Participacion>();
            using (SqlConnection cn = Conectar())
            {
                string sp = "";
                if (tipo == "Nacional") sp = "usp_getVotos";
                else if (tipo == "Departamento") sp = "usp_getVotosDepartamento";
                else if (tipo == "Provincia") sp = "usp_getVotosProvincia";
                else if (tipo == "Distrito") sp = "usp_getVotosProvincia"; 

                SqlCommand cmd = new SqlCommand(sp, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (tipo == "Nacional")
                {
                    cmd.Parameters.AddWithValue("@inicio", 1);
                    cmd.Parameters.AddWithValue("@fin", 25);
                }
                else if (tipo == "Departamento")
                {
                    cmd.Parameters.AddWithValue("@Departamento", valor);
                }
                else if (tipo == "Provincia" || tipo == "Distrito")
                {
                    cmd.Parameters.AddWithValue("@Provincia", valor);
                }
                

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Participacion
                        {
                            DPD = dr["DPD"].ToString().Trim(),
                            TV = Convert.ToInt64(dr["TV"]),
                            PTV = dr["PTV"].ToString(),
                            TA = Convert.ToInt64(dr["TA"]),
                            PTA = dr["PTA"].ToString(),
                            EH = Convert.ToInt64(dr["EH"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}