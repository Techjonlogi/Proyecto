//realizado por Jonathan de jesus moreno martinez 30/04/2020
using Sistema_de_Prácticas_Profesionales.Pojos.Profesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IProfesorDAO
    {
        List<Profesor> GetProfesor();
        Profesor GetProfesorforID(String idToSearch);
        AddResult AddProfesor(Profesor profesor);

    }
}