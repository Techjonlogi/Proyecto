using Sistema_de_Prácticas_Profesionales.Pojos.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IAdministradorDAO
    {
        List<Administrador> GetAdministrador();
        Administrador GetIdAdministrador(String idToSearch);
        AddResult AddAdministrador(Administrador administrador);
    }
}
