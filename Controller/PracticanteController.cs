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
        public OperationResult AddAlumno(String matricula, String nombre, String carrera, String contraseña, String apellidoPaterno, String apellidoMaterno, String periodo)
        {
            OperationResult operation = OperationResult.UnknowFail;
            if (GetAlumnoByMatricula(matricula).MatriculaPracticante == null)
            {
                Practicante practicante = new Practicante();
                practicante.MatriculaPracticante = matricula;
                practicante.NombresPracticante = nombre;
                practicante.ApellidoPaternoPracticante = apellidoPaterno;
                practicante.ApellidoMaternoPracticante = apellidoMaterno;
                practicante.PeriodoPracticante = periodo;
                
                
                PracticanteDAO practicanteDAO = new PracticanteDAO();
                if ((OperationResult)practicanteDAO.AddPracticante(practicante) == OperationResult.Success)
                {
                    if (CreateUserForAlumno(matricula, contraseña, nombre) == OperationResult.Success)
                    {
                        operation = OperationResult.Success;
                    }
                    else
                    {
                        DeleteAlumno(matricula);
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
