using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Pojos.Documento;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    interface IDocumentoDao
    {

        AddResult AddDocumento(DocumentoPracticas documento);
    }
}
