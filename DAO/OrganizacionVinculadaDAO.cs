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
        private AddResult CheckObjectOrganizacion(OrganizacionVinculada instanceorganizacion)
        {
            CheckFields instancevalidarCampos = new CheckFields();
            AddResult instanceresult = AddResult.UnknowFail;
            if (instanceorganizacion.IdOrganizacion == String.Empty ||
                instanceorganizacion.NombreEmpresa == String.Empty ||
                instanceorganizacion.Sector == String.Empty ||
                instanceorganizacion.UsuarioDirecto == String.Empty ||
                instanceorganizacion.UsuarioIndirecto == String.Empty ||
                instanceorganizacion.CorreoElectronico == String.Empty ||
                instanceorganizacion.Telefono == String.Empty ||
                instanceorganizacion.Estado == String.Empty ||
                instanceorganizacion.Ciudad == String.Empty ||
                instanceorganizacion.Direccion == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (instancevalidarCampos.ValidarMatricula(instanceorganizacion.IdOrganizacion) == CheckFields.ResultadosValidación.MatriculaInvalida)
            {
                throw new FormatException("ID invalida " + instanceorganizacion.IdOrganizacion);
            }
            else
            if (instancevalidarCampos.ValidarNombres(instanceorganizacion.NombreEmpresa) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + instanceorganizacion.NombreEmpresa);
            }
            else
            {
                instanceresult = AddResult.Success;
            }
            return instanceresult;
        }



        public AddResult AddOrganizacion(OrganizacionVinculada instanceorganizacion)
        {
            AddResult instanceresultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectOrganizacion(instanceorganizacion);
            }
            catch (ArgumentNullException)
            {
                instanceresultado = AddResult.NullObject;
                return instanceresultado;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand instancecommand = new SqlCommand("INSERT INTO dbo.OrganizacionVinculada VALUES(@IdOrganizacion, @NombreEmpresa, @Sector, @UsuarioDirecto, @UsuarioIndirecto, @CorreoElectronico, @Telefono, @Estado, @Ciudad, @Direccion)", connection))
                {
                    instancecommand.Parameters.Add(new SqlParameter("@IdOrganizacion", instanceorganizacion.IdOrganizacion));
                    instancecommand.Parameters.Add(new SqlParameter("@NombreEmpresa", instanceorganizacion.NombreEmpresa));
                    instancecommand.Parameters.Add(new SqlParameter("@Sector", instanceorganizacion.Sector));
                    instancecommand.Parameters.Add(new SqlParameter("@UsuarioDirecto", instanceorganizacion.UsuarioDirecto));
                    instancecommand.Parameters.Add(new SqlParameter("@UsuarioIndirecto", instanceorganizacion.UsuarioIndirecto));
                    instancecommand.Parameters.Add(new SqlParameter("@CorreoElectronico", instanceorganizacion.CorreoElectronico));
                    instancecommand.Parameters.Add(new SqlParameter("@Telefono", instanceorganizacion.Telefono));
                    instancecommand.Parameters.Add(new SqlParameter("@Estado", instanceorganizacion.Estado));
                    instancecommand.Parameters.Add(new SqlParameter("@Ciudad", instanceorganizacion.Ciudad));
                    instancecommand.Parameters.Add(new SqlParameter("@Direccion", instanceorganizacion.Direccion));
                    try
                    {
                        instancecommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        instanceresultado = AddResult.SQLFail;
                        return instanceresultado;
                    }
                    instanceresultado = AddResult.Success;
                }
                connection.Close();
            }
            return instanceresultado;
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.OrganizacionVinculada", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrganizacionVinculada instanceorganizacion = new OrganizacionVinculada();

                        instanceorganizacion.IdOrganizacion = reader["IdOrganizacion"].ToString();
                        instanceorganizacion.NombreEmpresa = reader["NombreEmpresa"].ToString();
                        instanceorganizacion.Sector = reader["sector"].ToString();
                        instanceorganizacion.UsuarioDirecto = reader["UsuarioDirecto"].ToString();
                        instanceorganizacion.UsuarioIndirecto = reader["UsuarioIndirecto"].ToString();
                        instanceorganizacion.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        instanceorganizacion.Telefono = reader["Telefono"].ToString();
                        instanceorganizacion.Estado = reader["Estado"].ToString();
                        instanceorganizacion.Ciudad = reader["FechadeBaja"].ToString();
                        instanceorganizacion.Direccion = reader["Direccion"].ToString();
                        listaOrganizacion.Add(instanceorganizacion);
                    }
                }
                connection.Close();
            }
            return listaOrganizacion;
        }

        public OrganizacionVinculada GetOrganizacionforID(String toSearchInBD)
        {
            OrganizacionVinculada instanceorganizacion = new OrganizacionVinculada();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.OrganizacionVinculada WHERE IdOrganiazcion = @IdOrganizacionToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("IdOrganizacionToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        instanceorganizacion.IdOrganizacion = reader["IdOrganizacion"].ToString();
                        instanceorganizacion.NombreEmpresa = reader["NombreEmpresa"].ToString();
                        instanceorganizacion.Sector = reader["Sector"].ToString();
                        instanceorganizacion.UsuarioDirecto = reader["UsuarioDirecto"].ToString();
                        instanceorganizacion.UsuarioIndirecto = reader["UsuarioIndirecto"].ToString();
                        instanceorganizacion.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        instanceorganizacion.Telefono = reader["Telefono"].ToString();
                        instanceorganizacion.Estado = reader["Estado"].ToString();
                        instanceorganizacion.Ciudad = reader["Ciudad"].ToString();
                        instanceorganizacion.Direccion = reader["Direccion"].ToString();

                    }
                }
                connection.Close();
            }
            return instanceorganizacion;
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
                using (SqlCommand instancecommand = new SqlCommand("DELETE FROM dbo.OrganizacionVinculada WHERE  IdOrganizacion = @IdOrganizacionToSearch", connection))
                {
                    instancecommand.Parameters.Add(new SqlParameter("IdOrganizacionToSearch", toSearchInBD));
                    instancecommand.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }



    }
}
