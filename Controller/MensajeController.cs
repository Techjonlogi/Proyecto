using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;


namespace Sistema_de_Prácticas_Profesionales.Controller
{
    public class MensajeController
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



        public List<Mensaje> GetMensajes(String receptor)
        {
            MensajeDao mensaje = new MensajeDao();
            List<Mensaje> list = mensaje.GetMensajesbyReceptor(receptor);
            return list;
        }





        public OperationResult AddMensaje(String receptor,String emisor,String texto)
        {
            OperationResult operation = OperationResult.UnknowFail;
            

                Mensaje coordinador = new Mensaje();
                coordinador.Receptor= receptor;
                coordinador.Emisor = emisor;
                coordinador.Texto = texto;
               
                MensajeDao mensajedao = new MensajeDao();
                operation = (OperationResult)mensajedao.addMensaje(coordinador);
           
                
            

            return operation;
        }










    }



    









}
