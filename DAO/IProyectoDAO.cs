//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Pojos.Proyecto;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IProyectoDAO
    {
        List<Proyecto> GetProyecto();
        Proyecto GetProyectoforID(String idToSearch);
        AddResult AddProyecto(Proyecto instanceproyecto);
    }
}
