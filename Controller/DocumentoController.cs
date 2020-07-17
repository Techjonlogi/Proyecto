using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Documento;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
   public class DocumentoController
    {


        public enum OperationResult
        {
            Success,
            NullOrganization,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }






        public OperationResult AddCoordinador(String ruta)
        {
            OperationResult operation = OperationResult.Success;
            
            
                DocumentoPracticas documento = new DocumentoPracticas();
                documento.RutaDocumento = ruta;
                DocumentoDao documentoDao = new DocumentoDao();
                operation = (OperationResult)documentoDao.AddDocumento(documento);
           

            return operation;
        }






    }
}
