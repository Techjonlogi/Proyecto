using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Profesor
{
    public class Profesor
    {
        private String idProfesor;
        private String diasEnServicioProfesor;
        private String nombresProfesor;
        private String apellidoPaternoProfesor;
        private String apellidoMaternoProfesor;
        private String usuarioProfesor;
        private String contraseñaProfesor;
        private String fechaRegistroProfesor;
        private String fechaBajaProfesor;



        public String IdProfesor { get => idProfesor; set => idProfesor = value; }

        public String DiasEnServicioProfesor { get => diasEnServicioProfesor; set => diasEnServicioProfesor = value; }

        public String NombresProfesor { get => nombresProfesor; set => nombresProfesor = value; }

        public String ApellidoPaternoProfesor { get => apellidoPaternoProfesor; set => apellidoPaternoProfesor = value; }

        public String ApellidoMaternoProfesor { get => apellidoMaternoProfesor; set => apellidoMaternoProfesor = value; }

        public String UsuarioProfesor { get => usuarioProfesor; set => usuarioProfesor = value; }

        public String ContraseñaProfesor { get => contraseñaProfesor; set => contraseñaProfesor = value; }

        public String FechaRegistroProfesor { get => fechaRegistroProfesor; set => fechaRegistroProfesor = value; }

        public String FechaBajaProfesor { get => fechaBajaProfesor; set => fechaBajaProfesor = value; }

        public Profesor(string idprofesor, string diasenservicio, string nombresprofesor, string apellidopaterno, string apellidomaterno, string usuario, string contraseña, string fechaderegistro, string fechadebaja) {
            this.idProfesor = idprofesor;
            this.diasEnServicioProfesor = diasenservicio;
            this.nombresProfesor = nombresprofesor;
            this.apellidoMaternoProfesor = apellidomaterno;
            this.apellidoPaternoProfesor = apellidopaterno;
            this.usuarioProfesor = usuario;
            this.contraseñaProfesor = contraseña;
            this.fechaRegistroProfesor = fechaderegistro;
            this.fechaBajaProfesor = fechadebaja;
        
        }
        public Profesor() { }
    }
}
