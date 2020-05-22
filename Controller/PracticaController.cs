using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Practica;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
    class PracticaController
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

        public OperationResult AddPractica(String nombre, String nombreOrgVinc, int numEspacios, String periodo)
        {
            try
            {
                if (GetPracticaNombre(nombre).NombrePractica == null)
                {
                    Practica practica = new Practica();

                    practica.NombrePractica = nombre;
                    practica.NombreOrgVincPractica = nombreOrgVinc;
                    practica.NumEspaciosPractica = numEspacios;
                    practica.PeriodoPractica = periodo;

                    PracticaDAO practicaDAO = new PracticaDAO();
                    return (OperationResult)practicaDAO.AddPractica(practica);
                }
                else
                {
                    return OperationResult.ExistingRecord;
                }
            }
            catch
            {
                return OperationResult.UnknowFail;
            }
        }

        public List<Practica> GetPractica()
        {
            PracticaDAO practicaDAO = new PracticaDAO();
            List<Practica> list = practicaDAO.GetPractica();
            return list;
        }

        public Practica GetPracticaNombre(String nombre)
        {
            PracticaDAO practicaDAO = new PracticaDAO();
            return practicaDAO.GetPracticaNombre(nombre);
        }

        public OperationResult DeletePracticaNombre(String nombre)
        {
            PracticaDAO practicaDAO = new PracticaDAO();
            return (OperationResult)practicaDAO.DeletePracticaNombre(nombre);
        }

    }
}
