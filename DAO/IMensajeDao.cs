using Sistema_de_Prácticas_Profesionales.Pojos.Mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public interface IMensajeDao
    {
        List <Mensaje> GetMensajesbyReceptor(String toSearchInBD);
        AddResult addMensaje(Mensaje mensaje);


    }
}
