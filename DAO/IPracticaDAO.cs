﻿using Sistema_de_Prácticas_Profesionales.Pojos.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IPracticaDAO
    {
        List<Practica> GetPractica();
        Practica GetPracticaNombre(String idToSearch);
        AddResult AddPractica(Practica practica);
        AddResult DeletePracticaNombre(String toSearchInBD);
    }
}