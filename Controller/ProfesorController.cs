//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Profesor;
using Sistema_de_Prácticas_Profesionales.Pojos.Usuario;



namespace Sistema_de_Prácticas_Profesionales.Controller
{
    public class ProfesorController
    {
        /// <summary>Crea objetos coordinador y usuario para comunicarlos con los dao</summary>
        /// <param name="nombre"> Nombre.</param>
        /// <param name="númeroPersonal">número personal.</param>
        /// <param name="carrera"> carrera.</param>
        /// <param name="correo">correo.</param>
        /// <param name="contraseña"> contraseña.</param>
        /// <returns>Resultado de la operación</returns>
        public AddResult AñadirCoordinador(string idprofesor, string diasenservicio, string nombresprofesor, String apellidopaterno, string apellidomaterno, string usuario, string contraseña, string fechaderegistro, string fechadebaja,string correo)
        {
            ProfesorDAO instanceProfesorDAO = new ProfesorDAO();
            UsuarioDao usuarioDAO = new UsuarioDao();
            Profesor instanceProfesor = new Profesor(idprofesor,diasenservicio,nombresprofesor, apellidopaterno, apellidomaterno, usuario, contraseña, fechaderegistro, fechadebaja);
            DateTime dateTime = DateTime.Now;
            Usuario instanceUsuario = new Usuario(idprofesor, contraseña, "Coordinador", dateTime, nombresprofesor,correo);
            if (instanceProfesorDAO.AddProfesor(instanceProfesor) == AddResult.Success && usuarioDAO.AddUsuario(instanceUsuario) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;

        }


    }
}
