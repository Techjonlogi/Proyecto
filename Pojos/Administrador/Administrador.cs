using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Administrador
{
    public class Administrador
    {
        private int idAdministrador;
        private String nombresAdministrador;
        private String apellidoPaternoAdministrador;
        private String apellidoMaternoAdministrador;
        private String usuarioAdministrador;
        private String contraseñaAdministrador;

        public int IdAdministrador { get => idAdministrador; set => idAdministrador = value; }

        public string NombresAdministrador { get => nombresAdministrador; set => nombresAdministrador = value; }

        public string ApellidoPaternoAdministrador { get => apellidoPaternoAdministrador; set => apellidoPaternoAdministrador = value; }

        public string ApellidoMaternoAdministrador { get => apellidoMaternoAdministrador; set => apellidoMaternoAdministrador = value; }

        public string UsuarioAdministrador { get => usuarioAdministrador; set => usuarioAdministrador = value; }

        public string ContraseñaAdministrador { get => contraseñaAdministrador; set => contraseñaAdministrador = value; }

        public Administrador(String nombresAdministrador, String apellidoPaternoAdministrador, String apellidoMaternoAdministrador,
            String usuarioAdministrador, String contraseñaAdministrador)
        {
            this.nombresAdministrador = nombresAdministrador;
            this.apellidoPaternoAdministrador = apellidoPaternoAdministrador;
            this.apellidoMaternoAdministrador = apellidoMaternoAdministrador;
            this.usuarioAdministrador = usuarioAdministrador;
            this.contraseñaAdministrador = contraseñaAdministrador;
        }
        public Administrador() { }
    }
}
