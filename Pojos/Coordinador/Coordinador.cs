using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Coordinador
{
    public class Coordinador
    {
        private String noPersonal;
        private String nombresCoordinador;
        private String apellidoPaternoCoordinador;
        private String apellidoMaternoCoordinador;
        private String usuarioCoordinador;
        private String contraseñaCoordinador;
        private String cubiculoCoordinador;
        private String fechaDeBajaCoordinador;
        private String fechaDeRegistroCoordinador;

        public string NoPersonal { get => noPersonal; set => noPersonal = value; }

        public string NombresCoordinador { get => nombresCoordinador; set => nombresCoordinador = value; }

        public string ApellidoPaternoCoordinador { get => apellidoPaternoCoordinador; set => apellidoPaternoCoordinador = value; }

        public string ApellidoMaternoCoordinador { get => apellidoMaternoCoordinador; set => apellidoMaternoCoordinador = value; }

        public string UsuarioCoordinador { get => usuarioCoordinador; set => usuarioCoordinador = value; }

        public string ContraseñaCoordinador { get => contraseñaCoordinador; set => contraseñaCoordinador = value; }

        public string CubiculoCoordinador { get => cubiculoCoordinador; set => cubiculoCoordinador = value; }

        public string FechaDeBajaCoordinador { get => fechaDeBajaCoordinador; set => fechaDeBajaCoordinador = value; }

        public string FechaDeRegistroCoordinador { get => fechaDeRegistroCoordinador; set => fechaDeRegistroCoordinador = value; }

        public Coordinador(String noPersonal) {
            this.noPersonal = noPersonal;
        }
        public Coordinador() { }
    }

}
