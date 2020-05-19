using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Practica
{
    public class Practica
    {

        private String nombrePractica;
        private int numOrgVincPractica;
        private int numPracticantesPractica;
        private int numProfesoresPractica;
        private int numProyectosPractica;
        private String periodoPractica;


        public string NombrePractica { get => nombrePractica; set => nombrePractica = value; }

        public int NumOrgVincPractica { get => numOrgVincPractica; set => numOrgVincPractica = value; }

        public int NumPracticantes { get => numPracticantesPractica; set => numPracticantesPractica = value; }

        public int NumProfesores { get => numProfesoresPractica; set => numProfesoresPractica = value; }

        public int NumProyectos { get => numProyectosPractica; set => numProyectosPractica = value; }

        public string PeriodoPractica { get => periodoPractica; set => periodoPractica = value; }

       
    }
}
