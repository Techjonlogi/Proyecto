using Sistema_de_Prácticas_Profesionales.Pojos.Actividad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IActividadDAO
    {
        List<Actividad> GetActividad();
        Actividad GetActividadID(String idToSearch);
        AddResult AddActividad(Actividad instanceActividad);

    }
}