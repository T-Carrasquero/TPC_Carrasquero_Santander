using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar(string dni)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select t.*, m.Apellidos, m.Nombres, te.Descripcion as estado, es.Descripcion as especialidad from Turnos t left join EspecialidadesPorMedico epm on t.DniMedico = epm.DniMedico left join Especialidades es on es.Id = epm.IdEspecialidad  left join Turnos_Estados te on te.Id = t.Estado left join Medicos m on t.DniMedico = m.Dni where dniPaciente = '" + dni+ "' order by t.Fecha ASC ");

                datos.EjecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Turno aux = new Turno();
                        aux.Especialidad = (string)datos.Lector["especialidad"];
                        aux.id = int.Parse(datos.Lector["id"].ToString());
                        aux.Paciente = (string)datos.Lector["dniPaciente"].ToString();
                        aux.Medico = (string)datos.Lector["Apellidos"] + " " + (string)datos.Lector["Nombres"];
                        aux.Fecha = (DateTime)datos.Lector["Fecha"];
                        aux.Hora = float.Parse(datos.Lector["Hora"].ToString());
                        aux.Estado = (string)datos.Lector["estado"];

                        lista.Add(aux);
                    }

                    return lista;
           
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Turno> getHistoriaClinica(string dni)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select t.*, m.Apellidos as apellidoMedico, m.Nombres as nombreMedico, p.Nombres as nombrePaciente, p.Apellidos as apellidoPaciente, te.Descripcion as estado, es.Descripcion as especialidad from Turnos t left join EspecialidadesPorMedico epm on t.DniMedico = epm.DniMedico left join Especialidades es on es.Id = epm.IdEspecialidad  left join Turnos_Estados te on te.Id = t.Estado left join Pacientes p on t.dniPaciente = p.Dni left join Medicos m on t.DniMedico = m.Dni where t.dniPaciente = '" + dni + "' and t.Estado=5 order by t.Fecha ASC ");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.dniPaciente = (string)datos.Lector["dniPaciente"].ToString();
                    aux.Especialidad = (string)datos.Lector["especialidad"];
                    aux.id = int.Parse(datos.Lector["id"].ToString());
                    aux.Paciente = (string)datos.Lector["apellidoPaciente"] + ", " + (string)datos.Lector["nombrePaciente"];
                    aux.Medico = (string)datos.Lector["apellidoMedico"] + " " + (string)datos.Lector["nombreMedico"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Hora = float.Parse(datos.Lector["Hora"].ToString());
                    aux.Estado = (string)datos.Lector["estado"];
                    aux.Indicaciones = (string)datos.Lector["Indicaciones"];
                    aux.Informe = (string)datos.Lector["Informe"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Turno buscarPorId(string id)
        {
            Turno aux = new Turno();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select t.*, m.Apellidos as apellidoMedico, m.Nombres as nombreMedico, p.Nombres as nombrePaciente, p.Apellidos as apellidoPaciente, te.Descripcion as estado, es.Descripcion as especialidad from Turnos t left join EspecialidadesPorMedico epm on t.DniMedico = epm.DniMedico left join Especialidades es on es.Id = epm.IdEspecialidad  left join Turnos_Estados te on te.Id = t.Estado left join Pacientes p on t.dniPaciente = p.Dni left join Medicos m on t.DniMedico = m.Dni where t.Id = '" + id + "' order by t.Fecha ASC ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.dniPaciente = (string)datos.Lector["dniPaciente"].ToString();
                    aux.Especialidad = (string)datos.Lector["especialidad"];
                    aux.id = int.Parse(datos.Lector["id"].ToString());
                    aux.Paciente = (string)datos.Lector["apellidoPaciente"] + ", " + (string)datos.Lector["nombrePaciente"];
                    aux.Medico = (string)datos.Lector["apellidoMedico"] + " " + (string)datos.Lector["nombreMedico"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Hora = float.Parse(datos.Lector["Hora"].ToString());
                    aux.Estado = (string)datos.Lector["estado"];
                }

                return aux;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Turno> listarPorMedico(string dni)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select t.*, m.Apellidos, m.Nombres, te.Descripcion as estado, es.Descripcion as especialidad from Turnos t left join EspecialidadesPorMedico epm on t.DniMedico = epm.DniMedico left join Especialidades es on es.Id = epm.IdEspecialidad  left join Turnos_Estados te on te.Id = t.Estado left join Medicos m on t.DniMedico = m.Dni where t.DniMedico = '" + dni + "' order by t.Fecha ASC ");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Especialidad = (string)datos.Lector["especialidad"];
                    aux.id = int.Parse(datos.Lector["id"].ToString());
                    aux.Paciente = (string)datos.Lector["dniPaciente"].ToString();
                    aux.Medico = (string)datos.Lector["Apellidos"] + " " + (string)datos.Lector["Nombres"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Hora = float.Parse(datos.Lector["Hora"].ToString());
                    aux.Estado = (string)datos.Lector["estado"];
                   

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Turno> listarTodos()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select t.*, m.Apellidos, m.Nombres, te.Descripcion as estado, es.Descripcion as especialidad from Turnos t left join EspecialidadesPorMedico epm on t.DniMedico = epm.DniMedico left join Especialidades es on es.Id = epm.IdEspecialidad  left join Turnos_Estados te on te.Id = t.Estado left join Medicos m on t.DniMedico = m.Dni order by t.Fecha ASC");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Especialidad= (string)datos.Lector["especialidad"];
                    aux.Paciente = (string)datos.Lector["dniPaciente"].ToString();
                    aux.id = int.Parse(datos.Lector["id"].ToString());
                    aux.Medico = (string)datos.Lector["Apellidos"] + " " + (string)datos.Lector["Nombres"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Hora = float.Parse(datos.Lector["Hora"].ToString());
                    aux.Estado = (string)datos.Lector["estado"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Turno> horariosOcupadosPorMedico(string dni, string fecha)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select t.Hora, m.Apellidos, m.Nombres, te.Descripcion as estado from Turnos t left join Turnos_Estados te on te.Id = t.Estado left join Medicos m on t.DniMedico = m.Dni where t.DniMedico = '"+dni+"' and t.Fecha='"+fecha+"'");
                datos.EjecutarLectura();
                if (datos.Lector != null)
                {

                    while (datos.Lector.Read())
                    {
                        Turno aux = new Turno();
                        aux.Medico = (string)datos.Lector["Apellidos"] + " " + (string)datos.Lector["Nombres"];
                        aux.Hora = float.Parse(datos.Lector["Hora"].ToString());
                        aux.Estado = (string)datos.Lector["estado"];

                        lista.Add(aux);
                    }

                    return lista;
                }
                else
                {
                    return lista;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool crear(Turno nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("insert into Turnos(DniMedico,dniPaciente,Fecha,Hora,Estado) values (@medico,@paciente,@Fecha,@hora,@estado)");

                conexion.agregarParametro("@paciente", nuevo.Paciente);
                conexion.agregarParametro("@medico", nuevo.Medico);
                conexion.agregarParametro("@estado", int.Parse(nuevo.Estado));
                conexion.agregarParametro("@Fecha", nuevo.Fecha.ToString("yyyy-MM-dd"));
                conexion.agregarParametro("@hora", nuevo.Hora);


                conexion.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool confirmar(int id)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Turnos set Estado = 1 where Id = @id ");

                conexion.agregarParametro("@id", id);
     

                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool cancelar(int id)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Turnos set Estado = 3 where Id = @id ");

                conexion.agregarParametro("@id", id);


                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ausente(int id)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Turnos set Estado = 6 where Id = @id ");

                conexion.agregarParametro("@id", id);


                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool guardarParteMedico(int id, string informe, string indicaciones)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Turnos set Estado = 5, Informe = @informe, Indicaciones = @indicaciones where Id = @id ");

                conexion.agregarParametro("@id", id);
                conexion.agregarParametro("@informe", informe);
                conexion.agregarParametro("@indicaciones", indicaciones);


                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
