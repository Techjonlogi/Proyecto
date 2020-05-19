using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Practicante
{
    public class Practicante
    {


        private double calificacionPracticante;
        private String matriculaPracticante;
        private String nombresPracticante;
        private String apellidoPaternoPracticante;
        private String apellidoMaternoPracticante;
        private String contraseñaPracticante;
        private String periodoPracticante;
        private String sectorSocialPracticante;

        public double CalificacionPracticante { get => calificacionPracticante; set => calificacionPracticante = value; }

        public String MatriculaPracticante { get => matriculaPracticante; set => matriculaPracticante = value; }

        public String NombresPracticante { get => nombresPracticante; set => nombresPracticante = value; }

        public String ApellidoPaternoPracticante { get => apellidoPaternoPracticante; set => apellidoPaternoPracticante = value; }

        public String ApellidoMaternoPracticante { get => apellidoMaternoPracticante; set => apellidoMaternoPracticante = value; }

        public String ContraseñaPracticante { get => contraseñaPracticante; set => contraseñaPracticante = value; }

        public String PeriodoPracticante { get => periodoPracticante; set => periodoPracticante = value; }

        public String SectorSocialPracticante { get => sectorSocialPracticante; set => sectorSocialPracticante = value; }
    }
}
