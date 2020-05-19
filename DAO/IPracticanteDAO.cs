using Sistema_de_Prácticas_Profesionales.Pojos.Practicante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IPracticanteDAO
    {
        List<Practicante> GetPracticante();
        Practicante GetPracticanteMatricula(String idToSearch);
        AddResult AddPracticante(Practicante practicante);

    }
}