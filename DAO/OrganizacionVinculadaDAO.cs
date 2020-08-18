//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.OrganizacionVinculada;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Conection;
using System.Data.SqlClient;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class OrganizacionVinculadaDAO : IOrganizacionVinculadaDAO
    {
        private AddResult CheckObjectOrganizacion(OrganizacionVinculada organizacion)
        {
            CheckFields instancevalidarCampos = new CheckFields();
            AddResult instanceresult = AddResult.UnknowFail;
            if (organizacion.IdOrganizacion == String.Empty ||
                organizacion.NombreEmpresa == String.Empty ||
                organizacion.Sector == String.Empty ||
                organizacion.UsuarioDirecto == String.Empty ||
                organizacion.UsuarioIndirecto == String.Empty ||
                organizacion.CorreoElectronico == String.Empty ||
                organizacion.Telefono == String.Empty ||
                organizacion.Estado == String.Empty ||
                organizacion.Ciudad == String.Empty ||
                organizacion.Direccion == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (instancevalidarCampos.ValidarMatricula(organizacion.IdOrganizacion) == CheckFields.ResultadosValidación.MatriculaInvalida)
            {
                throw new FormatException("ID invalida " + organizacion.IdOrganizacion);
            }
            else
            if (instancevalidarCampos.ValidarNombres(organizacion.NombreEmpresa) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + organizacion.NombreEmpresa);
            }
            else
            {
                instanceresult = AddResult.Success;
            }
            return instanceresult;
        }



        public AddResult AddOrganizacion(OrganizacionVinculada instanceorganizacion)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectOrganizacion(instanceorganizacion);
            }
            catch (ArgumentNullException)
            {
                resultado = AddResult.NullObject;
                return resultado;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO serviciosocial.OrganizacionVinculada VALUES(@IdOrganizacion, @NombreEmpresa, @Sector, @UsuarioDirecto, @UsuarioIndirecto, @CorreoElectronico, @Telefono, @Estado, @Ciudad, @Direccion)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdOrganizacion", instanceorganizacion.IdOrganizacion));
                    command.Parameters.Add(new SqlParameter("@NombreEmpresa", instanceorganizacion.NombreEmpresa));
                    command.Parameters.Add(new SqlParameter("@Sector", instanceorganizacion.Sector));
                    command.Parameters.Add(new SqlParameter("@UsuarioDirecto", instanceorganizacion.UsuarioDirecto));
                    command.Parameters.Add(new SqlParameter("@UsuarioIndirecto", instanceorganizacion.UsuarioIndirecto));
                    command.Parameters.Add(new SqlParameter("@CorreoElectronico", instanceorganizacion.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("@Telefono", instanceorganizacion.Telefono));
                    command.Parameters.Add(new SqlParameter("@Estado", instanceorganizacion.Estado));
                    command.Parameters.Add(new SqlParameter("@Ciudad", instanceorganizacion.Ciudad));
                    command.Parameters.Add(new SqlParameter("@Direccion", instanceorganizacion.Direccion));
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        resultado = AddResult.SQLFail;
                        return resultado;
                    }
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }


        public List<OrganizacionVinculada> GetOrganizacion()
        {

            List<OrganizacionVinculada> listaOrganizacion = new List<OrganizacionVinculada>();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.OrganizacionVinculada", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrganizacionVinculada organizacion = new OrganizacionVinculada();

                        organizacion.IdOrganizacion = reader["idOrganizacion"].ToString();
                        organizacion.NombreEmpresa = reader["NombreEmpresa"].ToString();
                        organizacion.Sector = reader["sector"].ToString();
                        organizacion.UsuarioDirecto = reader["UsuarioDirecto"].ToString();
                        organizacion.UsuarioIndirecto = reader["UsuarioIndirecto"].ToString();
                        organizacion.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        organizacion.Telefono = reader["Telefono"].ToString();
                        organizacion.Estado = reader["Estado"].ToString();
                        organizacion.Ciudad = reader["Ciudad"].ToString();
                        organizacion.Direccion = reader["Direccion"].ToString();
                        listaOrganizacion.Add(organizacion);
                    }
                }
                connection.Close();
            }
            return listaOrganizacion;
        }

        public OrganizacionVinculada GetOrganizacionforID(String toSearchInBD)
        {
            OrganizacionVinculada organizacion = new OrganizacionVinculada();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.OrganizacionVinculada WHERE idOrganiazcion = @IdOrganizacionToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("IdOrganizacionToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        organizacion.IdOrganizacion = reader["idOrganizacion"].ToString();
                        organizacion.NombreEmpresa = reader["NombreEmpresa"].ToString();
                        organizacion.Sector = reader["Sector"].ToString();
                        organizacion.UsuarioDirecto = reader["UsuarioDirecto"].ToString();
                        organizacion.UsuarioIndirecto = reader["UsuarioIndirecto"].ToString();
                        organizacion.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        organizacion.Telefono = reader["Telefono"].ToString();
                        organizacion.Estado = reader["Estado"].ToString();
                        organizacion.Ciudad = reader["Ciudad"].ToString();
                        organizacion.Direccion = reader["Direccion"].ToString();

                    }
                }
                connection.Close();
            }
            return organizacion;
        }

        public AddResult DeleteOrganizacionByID(String toSearchInBD)
        {
            AddResult result = AddResult.UnknowFail;
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("DELETE FROM serviciosocial.OrganizacionVinculada WHERE  idOrganizacion = @IdOrganizacionToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("IdOrganizacionToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }



    }
}
