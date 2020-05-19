using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.OrganizacionVinculada
{
    public class OrganizacionVinculada
    {
        private String idOrganizacion;
        private String nombreEmpresa;
        private String sector;
        private String usuarioDirecto;
        private String usuarioIndirecto;
        private String correoElectronico;
        private String telefono;
        private String estado;
        private String ciudad;
        private String direccion;

        public String IdOrganizacion { get => idOrganizacion; set => idOrganizacion = value; }

        public String NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }

        public String Sector { get => sector; set => sector = value; }

        public String UsuarioDirecto { get => usuarioDirecto; set => usuarioDirecto = value; }

        public String UsuarioIndirecto { get => usuarioIndirecto; set => usuarioIndirecto = value; }

        public String CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }

        public String Telefono { get => telefono; set => telefono = value; }

        public String Estado { get => estado; set => estado = value; }

        public String Ciudad { get => ciudad; set => ciudad = value; }

        public String Direccion { get => direccion; set => direccion = value; }


    }
}