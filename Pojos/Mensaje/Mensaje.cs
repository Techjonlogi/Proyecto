using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Pojos.Mensaje
{
    public class Mensaje
    {
        String receptor;
        String emisor;
        String texto;

        public string Receptor{ get => receptor; set => receptor = value; }
        public string Emisor { get => emisor; set => emisor = value; }
        public string  Texto { get => texto; set => texto = value; }




    }
}
