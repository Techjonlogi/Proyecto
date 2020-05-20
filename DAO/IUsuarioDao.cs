using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Pojos.Usuario;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IUsuarioDao

    {
        AddResult AddUsuario(Usuario organizacion);
    }
}
