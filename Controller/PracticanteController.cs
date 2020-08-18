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
                Practicante practicante = new Practicante();
                practicante.MatriculaPracticante = Matricula;
                practicante.NombresPracticante = Nombre;
                practicante.ApellidoPaternoPracticante = apellidoPaterno;
                practicante.ApellidoMaternoPracticante = apellidoMaterno;
                practicante.PeriodoPracticante = periodo;
                
                
                PracticanteDAO practicanteDAO = new PracticanteDAO();
                if ((OperationResult)practicanteDAO.AddPracticante(practicante) == OperationResult.Success)
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
            PracticanteDAO practicanteDAO = new PracticanteDAO();
            List<Practicante> list = practicanteDAO.GetPracticante();
            return list;
        }

        public Practicante GetAlumnoByMatricula(String Matricula)
        {
            PracticanteDAO practicanteDAO = new PracticanteDAO();
            return practicanteDAO.GetPracticanteMatricula(Matricula);
        }
        public OperationResult DeleteAlumno(String Matricula)
        {
            PracticanteDAO practicanteDAO = new PracticanteDAO();
            return (OperationResult)practicanteDAO.DeletePracticanteByMatricula(Matricula);
        }

    }
}
