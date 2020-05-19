//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Proyecto
{
    public class Proyecto

    {
        private String idProyecto;
        private String responsabilidades;
        private String actividad;
        private String duracion;
        private String nombreProyecto;
        private String descripcion;
        private String objetivoGeneral;
        private String objetivoMediato;
        private String cargoEncargado;
        private String emailEncargado;
        private String nombreEncargado;
        private String metodologia;
        private String recursos;
        private object organizacionVinculada;
        private object coordinador;

        public String IdProyecto { get => idProyecto; set => idProyecto = value; }
        public String Responsabilidades { get => responsabilidades; set => responsabilidades = value; }

        public String Actividad { get => actividad; set => actividad = value; }

        public String Duracion { get => duracion; set => duracion = value; }

        public String NombreProyecto { get => nombreProyecto; set => nombreProyecto = value; }

        public String Descripcion { get => descripcion; set => descripcion = value; }

        public String Objetivogeneral { get => objetivoGeneral; set => objetivoGeneral = value; }

        public String ObjetivoMediato { get => objetivoMediato; set => objetivoMediato = value; }

        public String CargoEncargado { get => cargoEncargado; set => cargoEncargado = value; }

        public String EmailEncargado { get => emailEncargado; set => emailEncargado = value; }

        public String NombreEncargado { get => nombreEncargado; set => nombreEncargado = value; }

        public String Metodologia { get => metodologia; set => metodologia = value; }

        public String Recursos { get => recursos; set => recursos = value; }

        public object OrganizacionVinculada { get => organizacionVinculada; set => organizacionVinculada = value; }

        public object Coordinador { get => coordinador; set => coordinador = value; }

        public Proyecto(String idproyecto, String responsabilidades, String actividad, String duracion, String nombreproyecto, String descripcion, String objetivogeneral, String objetivomediato, String cargoencargado, String emailencargado, String nombreencargado, String metodologia, String recursos, object organizacion, object coordinador) { 
            this.idProyecto = idproyecto;
            this.responsabilidades = responsabilidades;
            this.actividad = actividad;
            this.duracion = duracion;
            this.nombreProyecto = nombreproyecto;
            this.descripcion = descripcion;
            this.objetivoGeneral = objetivogeneral;
            this.objetivoMediato = objetivomediato;
            this.cargoEncargado = cargoencargado;
            this.emailEncargado = emailencargado;
            this.nombreEncargado = nombreencargado;
            this.metodologia = metodologia;
            this.recursos = recursos;
            this.organizacionVinculada = organizacion;
            this.coordinador = coordinador;
        }
        public Proyecto() { }
    }
}
