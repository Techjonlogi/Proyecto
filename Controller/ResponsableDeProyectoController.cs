//alfredo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.ResponsableDeProyecto;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
    class ResponsableDeProyectoController
    {
        /// <summary>Crea objeto responsable de proyecto para comunicarlo con el DAO</summary>
        /// <param name="cargoResponsable"> cargo del resonsable.</param>
        /// <param name="correoElectronicoResponsable"> Correo electronico del responsable.</param>
        /// <param name="nombreResponsable"> nombre del responsable.</param>
        /// <param name="apellidoPaternoResponsable"> apellido paterno del responsable.</param>
        /// <param name="apellidoMaternoResponsable"> apellido materno del responsable.</param>
        /// <returns>Resultado de la operación</returns>
        public AddResult AddResponsableDeProyecto(string cargoResponsable, string correoElectronicoResponsable,
            string nombreResponsable, string apellidoPaternoResponsable, string apellidoMaternoResponsable)
        {
            ResponsableDeProyectoDAO responsableDeProyectoDAO = new ResponsableDeProyectoDAO();
            ResponsableDeProyecto responsableDeProyecto = new ResponsableDeProyecto(cargoResponsable, correoElectronicoResponsable,
                nombreResponsable, apellidoPaternoResponsable, apellidoMaternoResponsable);
            if (responsableDeProyectoDAO.AddResponsableDeProyecto(responsableDeProyecto) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;
        }


        }


    }

