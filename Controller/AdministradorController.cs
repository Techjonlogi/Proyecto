//alfredo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Administrador;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
    class AdministradorController
    {
        /// <summary>Crea objeto responsable de proyecto para comunicarlo con el DAO</summary>
        /// <param name="nombresAdministrador"> cargo del resonsable.</param>
        /// <param name="apellidoPaternoAdministrador"> Correo electronico del responsable.</param>
        /// <param name="apellidoMaternoAdministrador"> nombre del responsable.</param>
        /// <param name="apellidoPaternoResponsable"> apellido paterno del responsable.</param>
        /// <param name="apellidoMaternoResponsable"> apellido materno del responsable.</param>
        /// <returns>Resultado de la operación</returns>
        public AddResult AddAdministrador(string nombresAdministrador, string apellidoPaternoAdministrador, string apellidoMaternoAdministrador,
            string usuarioAdministrador, string contraseñaAdministrador)
        {
            AdministradorDAO administradorDAO = new AdministradorDAO();
            Administrador administrador = new Administrador(nombresAdministrador, apellidoPaternoAdministrador, 
                 apellidoMaternoAdministrador, usuarioAdministrador, contraseñaAdministrador);
            if (administradorDAO.AddAdministrador(administrador) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;

        }


    }
}
