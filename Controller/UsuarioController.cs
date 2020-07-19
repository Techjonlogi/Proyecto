using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Logica;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
    public class UsuarioController
    {

        



        public AddResult doLoging(String username,String password)
        {
            UsuarioDao dao = new UsuarioDao();
            AddResult resultado = new AddResult();
            resultado = dao.doLoging(username, password);

            return resultado;




        }
        








    }
}
