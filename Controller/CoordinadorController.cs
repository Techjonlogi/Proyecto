//alfredo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
    public class CoordinadorController
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
        public OperationResult AddCoordinador(String noPersonal, String nombresCoordinador, String apellidoPaternoCoordinador,
            String apellidoMaternoCoordinador, String usuarioCoordinador, String contraseñaCoordinador, String CubiculoCoordinador,
            String fechaBajaCoordinador, String fechaRegistroCoordinador)
        {
            OperationResult operation = OperationResult.UnknowFail;
            if (GetNoPersonalCoordinador(noPersonal).NoPersonal == null)
            {
                Coordinador coordinador = new Coordinador();
                coordinador.NoPersonal = noPersonal;
                coordinador.NombresCoordinador = nombresCoordinador;
                coordinador.ApellidoPaternoCoordinador = apellidoMaternoCoordinador;
                coordinador.ApellidoMaternoCoordinador = apellidoMaternoCoordinador;
                coordinador.UsuarioCoordinador = usuarioCoordinador;
                coordinador.ContraseñaCoordinador = contraseñaCoordinador;
                coordinador.CubiculoCoordinador = CubiculoCoordinador;
                coordinador.FechaDeRegistroCoordinador = fechaRegistroCoordinador;
                CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
                operation = (OperationResult)coordinadorDAO.AddCoordinador(coordinador);
            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }

            return operation;
        }
        public Coordinador GetNoPersonalCoordinador(String noPersonal)
        {
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
            return coordinadorDAO.GetNoPersonalCoordinador(noPersonal);
        }

    }
}
