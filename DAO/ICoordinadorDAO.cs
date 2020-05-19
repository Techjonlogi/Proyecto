using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface ICoordinadorDAO
    {
        List<Coordinador> GetCoordinador();
        Coordinador GetNoPersonalCoordinador(String idToSearch);
        AddResult AddCoordinador(Coordinador coordinador);
    }
}
