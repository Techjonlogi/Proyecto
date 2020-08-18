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

                OrganizacionVinculada organizacion = new OrganizacionVinculada();
                organizacion.CorreoElectronico = Correo;
                organizacion.Direccion = Direccion;
                organizacion.NombreEmpresa = Nombre;
                organizacion.IdOrganizacion = id;
                organizacion.Sector = Sector;
                organizacion.Telefono = Telefono;
                organizacion.UsuarioDirecto = usuarioDirecto;
                organizacion.UsuarioIndirecto = usuarioIndirecto;
                organizacion.Estado = estado;
                organizacion.Ciudad = ciudad;
                OrganizacionVinculadaDAO organizacionDAO = new OrganizacionVinculadaDAO();

                operation = (OperationResult)organizacionDAO.AddOrganizacion(organizacion);
            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }
            return operation;

        }
        public List<OrganizacionVinculada> GetOrganizacion()
        {
            OrganizacionVinculadaDAO organizacionDAO = new OrganizacionVinculadaDAO();
            List<OrganizacionVinculada> list = organizacionDAO.GetOrganizacion();
            return list;
        }

        public OrganizacionVinculada GetOrganizacionVinculadaById(String id)
        {
            OrganizacionVinculadaDAO eorganizacionDAO = new OrganizacionVinculadaDAO();
            return eorganizacionDAO.GetOrganizacionforID(id);
        }
        public OperationResult DeleteOrganizacionVinculadaById(String id)
        {
            OrganizacionVinculadaDAO organizacionDAO = new OrganizacionVinculadaDAO();
            return (OperationResult)organizacionDAO.DeleteOrganizacionByID(id);
        }
       
    }
}
    

