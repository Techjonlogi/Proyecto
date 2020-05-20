//realizado por Jonathan de jesus moreno martinez 30/04/2020

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Practicante;


namespace Sistema_de_Prácticas_Profesionales.Controller
{
    public class PracticanteController
    {

        public enum OperationResult
        {
            Success,
            NullAlumno,
            InvalidAlumno,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }
        public OperationResult AddAlumno(String Matricula, String Nombre, String Carrera, String Contraseña, String apellidoPaterno, String apellidoMaterno, String periodo)
        {
            OperationResult operation = OperationResult.UnknowFail;
            if (GetAlumnoByMatricula(Matricula).MatriculaPracticante == null)
            {
                Practicante instancePracticante = new Practicante();
                instancePracticante.MatriculaPracticante = Matricula;
                instancePracticante.NombresPracticante = Nombre;
                instancePracticante.ApellidoPaternoPracticante = apellidoPaterno;
                instancePracticante.ApellidoMaternoPracticante = apellidoMaterno;
                instancePracticante.PeriodoPracticante = periodo;
                
                
                PracticanteDAO instancePracticanteDAO = new PracticanteDAO();
                if ((OperationResult)instancePracticanteDAO.AddPracticante(instancePracticante) == OperationResult.Success)
                {
                    if (CreateUserForAlumno(Matricula, Contraseña, Nombre) == OperationResult.Success)
                    {
                        operation = OperationResult.Success;
                    }
                    else
                    {
                        DeleteAlumno(Matricula);
                        operation = OperationResult.UnknowFail;
                    }
                }
                else
                {
                    operation = OperationResult.UnknowFail;
                }

            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }
            return operation;

        }

        private OperationResult CreateUserForAlumno(String Matricula, String Password, String Nombre) {
            OperationResult op = OperationResult.Success;
            return op;
        
        }
        /*private OperationResult CreateUserForAlumno(String Matricula, String Password, String Nombre)
        {
            OperationResult operation = OperationResult.UnknowFail;
            Usuario user = new Usuario();
            user.Name = Nombre;
            user.Email = Matricula + "@estudiantes.uv.mx";
            user.UserType = "Alumno";
            user.UserName = Matricula;
            user.Password = Password;
            user.RegisterDate = DateTime.Today;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            operation = (OperationResult)usuarioDAO.AddUsuario(user);
            return operation;
        }*/
        public List<Practicante> GetAlumno()
        {
            PracticanteDAO instancePracticanteDAO = new PracticanteDAO();
            List<Practicante> list = instancePracticanteDAO.GetPracticante();
            return list;
        }

        public Practicante GetAlumnoByMatricula(String Matricula)
        {
            PracticanteDAO instancePracticanteDAO = new PracticanteDAO();
            return instancePracticanteDAO.GetPracticanteMatricula(Matricula);
        }
        public OperationResult DeleteAlumno(String Matricula)
        {
            PracticanteDAO instancePracticanteDAO = new PracticanteDAO();
            return (OperationResult)instancePracticanteDAO.DeletePracticanteByMatricula(Matricula);
        }

    }
}
