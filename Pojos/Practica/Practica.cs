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
        private String nombreOrgVincPractica;
        private int numEspaciosPractica;
        private String periodoPractica;


        public string NombrePractica { get => nombrePractica; set => nombrePractica = value; }

        public string NombreOrgVincPractica { get => nombreOrgVincPractica; set => nombreOrgVincPractica = value; }

        public int NumEspaciosPractica { get => numEspaciosPractica; set => numEspaciosPractica = value; }

        public string PeriodoPractica { get => periodoPractica; set => periodoPractica = value; }

       
    }
}
