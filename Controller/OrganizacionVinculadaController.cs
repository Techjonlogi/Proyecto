//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.OrganizacionVinculada;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.Controller
{


    public class OrganizacionVinculadaController
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
        public OperationResult AddOrganizacion(String id, String Nombre, String Direccion, String Sector, String Telefono, String Correo, String usuarioDirecto, String usuarioIndirecto,String estado, String ciudad)
        {
            OperationResult operation = OperationResult.UnknowFail;
            if (GetOrganizacionVinculadaById(id).IdOrganizacion == null)
            {

                OrganizacionVinculada instanceorganizacion = new OrganizacionVinculada();
                instanceorganizacion.CorreoElectronico = Correo;
                instanceorganizacion.Direccion = Direccion;
                instanceorganizacion.NombreEmpresa = Nombre;
                instanceorganizacion.IdOrganizacion = id;
                instanceorganizacion.Sector = Sector;
                instanceorganizacion.Telefono = Telefono;
                instanceorganizacion.UsuarioDirecto = usuarioDirecto;
                instanceorganizacion.UsuarioIndirecto = usuarioIndirecto;
                instanceorganizacion.Estado = estado;
                instanceorganizacion.Ciudad = ciudad;
                OrganizacionVinculadaDAO instanceorganizacionDAO = new OrganizacionVinculadaDAO();

                operation = (OperationResult)instanceorganizacionDAO.AddOrganizacion(instanceorganizacion);
            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }
            return operation;

        }
        public List<OrganizacionVinculada> GetOrganizacion()
        {
            OrganizacionVinculadaDAO instanceorganizacionDAO = new OrganizacionVinculadaDAO();
            List<OrganizacionVinculada> list = instanceorganizacionDAO.GetOrganizacion();
            return list;
        }

        public OrganizacionVinculada GetOrganizacionVinculadaById(String id)
        {
            OrganizacionVinculadaDAO instanceorganizacionDAO = new OrganizacionVinculadaDAO();
            return instanceorganizacionDAO.GetOrganizacionforID(id);
        }
        public OperationResult DeleteOrganizacionVinculadaById(String id)
        {
            OrganizacionVinculadaDAO instanceorganizacionDAO = new OrganizacionVinculadaDAO();
            return (OperationResult)instanceorganizacionDAO.DeleteOrganizacionByID(id);
        }

    }
}
    

