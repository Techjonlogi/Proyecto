using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.ResponsableDeProyecto
{
    public class ResponsableDeProyecto
    {
        private String cargoResponsable;
        private String correoElectronicoResponsable;
        private String nombreResponsable;
        private String apellidoPaternoResponsable;
        private String apellidoMaternoResponsable;

        public string CargoResponsable { get => cargoResponsable; set => cargoResponsable = value; }
        public string CorreoElectronicoResponsable { get => correoElectronicoResponsable; set => correoElectronicoResponsable = value; }
        public string NombreResponsable { get => nombreResponsable; set => nombreResponsable = value; }
        public string ApellidoPaternoResponsable { get => ApellidoPaternoResponsable; set => ApellidoPaternoResponsable = value; }
        public string ApellidoMaternoResponsable { get => ApellidoMaternoResponsable; set => ApellidoMaternoResponsable = value; }

        public ResponsableDeProyecto(String cargoResponsable, String correoElectronicoResponsable, String nombreResponsable, 
            String apellidoPaternoResponsable, String apellidoMaternoResponsable)
        {
            this.cargoResponsable = cargoResponsable;
            this.correoElectronicoResponsable = correoElectronicoResponsable;
            this.nombreResponsable = nombreResponsable;
            this.apellidoPaternoResponsable = apellidoPaternoResponsable;
            this.apellidoMaternoResponsable = apellidoMaternoResponsable;
        }
        public ResponsableDeProyecto() { }
    }
}
