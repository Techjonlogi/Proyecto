//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Pojos.Proyecto;
using Sistema_de_Prácticas_Profesionales.DAO;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;
using Sistema_de_Prácticas_Profesionales.Pojos.OrganizacionVinculada;

namespace Controller
{
    /// <summary>Clase para comunicar la capa de UI con la de BusinessLogic</summary>
    public class ControladorProyecto
    {

        /// <summary>  Comunica los datos obtenidos en la interfaz gráfica con el DAO de añadir proyecto</summary>
        /// <param name="nombreProyecto">nombre proyecto.</param>
        /// <param name="numAlumnos">number alumnos.</param>
        /// <param name="lugar">lugar.</param>
        /// <param name="horario">horario.</param>
        /// <param name="actividades"> actividades.</param>
        /// <param name="requisitos">requisitos.</param>
        /// <param name="responsable">responsable.</param>
        /// <param name="IdCoordinador">identifier coordinador.</param>
        /// <returns>El resultado de la operación</returns>
        public AddResult AddProyecto(string idproyecto,string responsabilidades,string nombreProyecto, string duracion, string descripcion, string objetivogeneral, string objetivomediato, string cargoencargado, string emailencargado,
            string nombreencargado, string metodologia, string recursos, string IdCoordinador, string actividades)
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            Coordinador instanceCoordinador = new Coordinador(IdCoordinador);
            OrganizacionVinculada instanceOrganizacion = new OrganizacionVinculada();
            Proyecto proyecto = new Proyecto(idproyecto,responsabilidades,actividades, duracion,nombreProyecto, descripcion, objetivogeneral, objetivomediato,cargoencargado,emailencargado, nombreencargado, metodologia, recursos, instanceOrganizacion, instanceCoordinador);
            return proyectoDAO.AddProyecto(proyecto);
        }

        /// <summary>  Obtiene una lista de proyectos para la interfaz de usuario</summary>
        /// <returns>una lista de proyectos</returns>
        public List<Proyecto> ObtenerProyectos()
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            List<Proyecto> proyectos = proyectoDAO.GetProyecto();
            return proyectos;
        }
    }




}
