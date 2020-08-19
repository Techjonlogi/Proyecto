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



        public enum OperationResult
        {
            Success,
            NullCoordinador,
            InvaliCoordinador,
            UnknowFail,
            SQLFail,
            ExistingRecord

        }
        /// <summary>Crea objetos coordinador y usuario para comunicarlos con los dao</summary>
        /// <param name="nombre"> Nombre.</param>
        /// <param name="númeroPersonal">número personal.</param>
        /// <param name="carrera"> carrera.</param>
        /// <param name="correo">correo.</param>
        /// <param name="contraseña"> contraseña.</param>
        /// <returns>Resultado de la operación</returns>
        public OperationResult AñadirProfesor(string idprofesor, string nombresprofesor, string apellidopaterno, string apellidomaterno, string usuario, string contraseña, string fechaderegistro, string fechadebaja,string turno, string correo)
        {
            OperationResult operation = OperationResult.UnknowFail;
            
            

            if (GetNoPersonalProfesor(idprofesor).IdProfesor == null)
            {
                Profesor profesor = new Profesor(idprofesor, nombresprofesor, apellidopaterno, apellidomaterno, usuario, contraseña, fechaderegistro, fechadebaja, turno);
                DateTime dateTime = DateTime.Now;
                Usuario instanceusuario = new Usuario(usuario, contraseña, "Profesor", dateTime, nombresprofesor, correo);
                ProfesorDAO profesordao  = new ProfesorDAO();
                operation = (OperationResult)profesordao.AddProfesor(profesor);
            }
            else {

                operation = OperationResult.ExistingRecord;
            }

            return operation;


        }

       



        public Profesor GetNoPersonalProfesor(String noPersonal)
        {
            ProfesorDAO profesordao = new ProfesorDAO ();
            return profesordao.GetProfesorforID(noPersonal);
        }

        public List<Profesor> GetProfesor()
        {
            ProfesorDAO profesordao = new ProfesorDAO();
            List<Profesor> list = profesordao.GetProfesor();
            return list;
        }
        public OperationResult DeleteProfesor(String noProfesor)
        {
           ProfesorDAO profesordao = new ProfesorDAO();
            return (OperationResult)profesordao.DeleteProfesorByID(noProfesor);
        }

    }
}
