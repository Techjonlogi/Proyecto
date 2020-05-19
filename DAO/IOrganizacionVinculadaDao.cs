//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Pojos.OrganizacionVinculada;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IOrganizacionVinculadaDAO
    {
        List<OrganizacionVinculada> GetOrganizacion();
        OrganizacionVinculada GetOrganizacionforID(String idToSearch);
        AddResult AddOrganizacion(OrganizacionVinculada Organizacion);

    }
}
