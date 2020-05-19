using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Actividad
{
    public class Actividad
    {
        private String idActividad;
        private String nombreActividad;
        private int diaEntregaActividad;
        private int mesEntregaActividad;
        private String añoEntregaActividad;
        private double valorActividad;


        public string IdActividad { get => idActividad; set => idActividad = value; }

        public string NombreActividad { get => nombreActividad; set => nombreActividad = value; }

        public int DiaEntregaActividad { get => diaEntregaActividad; set => diaEntregaActividad = value; }
        
        public int MesEntregaActividad { get => mesEntregaActividad; set => mesEntregaActividad = value; }

        public string AñoEntregaActividad { get => añoEntregaActividad; set => añoEntregaActividad = value; }

        public double ValorActividad { get => valorActividad; set => valorActividad = value; }
    }
}
