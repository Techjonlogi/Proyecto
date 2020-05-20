//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Proyecto;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Conection;
using System.Data.SqlClient;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class ProyectoDAO
    {
        private AddResult CheckObjectProyecto(Proyecto instanceproyecto)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult instanceresult = AddResult.UnknowFail;
            if (instanceproyecto.IdProyecto == String.Empty ||
                instanceproyecto.Responsabilidades == String.Empty ||
                instanceproyecto.Actividad == String.Empty ||
                instanceproyecto.Duracion == String.Empty ||
                instanceproyecto.NombreProyecto == String.Empty ||
                instanceproyecto.Descripcion == String.Empty ||
                instanceproyecto.Objetivogeneral == String.Empty ||
                instanceproyecto.ObjetivoMediato == String.Empty ||
                instanceproyecto.CargoEncargado == String.Empty ||
                instanceproyecto.EmailEncargado == String.Empty ||
                instanceproyecto.NombreEncargado == String.Empty ||
                instanceproyecto.Metodologia == String.Empty ||
                instanceproyecto.Recursos == String.Empty ||
                instanceproyecto.OrganizacionVinculada == null ||
                instanceproyecto.Coordinador == null)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarMatricula(instanceproyecto.IdProyecto) == CheckFields.ResultadosValidación.MatriculaInvalida)
            {
                throw new FormatException("id de proyecto invalido " + instanceproyecto.IdProyecto);
            }
            else
            if (validarCampos.ValidarNombres(instanceproyecto.NombreProyecto) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + instanceproyecto.NombreProyecto);
            }
            else
            {
                instanceresult = AddResult.Success;
            }
            return instanceresult;
        }

        public AddResult AddProyecto(Proyecto instanceproyecto)
        {
            AddResult instanceresultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult instancecheckForEmpty = AddResult.UnknowFail;
            try
            {
                instancecheckForEmpty = CheckObjectProyecto(instanceproyecto);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Profesor VALUES(@IdProyecto, @Responsabilidades, @Actividad, @Duracion, @NombreProyecto, @Descripcion, @ObjetivoGeneral, @ObjetivoMediato, @CargoEncargado, @EmailEncargado, @NombreEncargado, @Metodologia, @Recursos, @IdOrganizacionVinculada, @NumPersonalCoordinador)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdProyecto", instanceproyecto.IdProyecto));
                    command.Parameters.Add(new SqlParameter("@Responsabilidades", instanceproyecto.Responsabilidades));
                    command.Parameters.Add(new SqlParameter("@Actividad", instanceproyecto.Actividad));
                    command.Parameters.Add(new SqlParameter("@Duracion", instanceproyecto.Duracion));
                    command.Parameters.Add(new SqlParameter("@NombreProyecto", instanceproyecto.NombreProyecto));
                    command.Parameters.Add(new SqlParameter("@Descripcion", instanceproyecto.Descripcion));
                    command.Parameters.Add(new SqlParameter("@ObjetivoGeneral", instanceproyecto.Objetivogeneral));
                    command.Parameters.Add(new SqlParameter("@ObjetivoMediato", instanceproyecto.ObjetivoMediato));
                    command.Parameters.Add(new SqlParameter("@CargoEncargado", instanceproyecto.CargoEncargado));
                    command.Parameters.Add(new SqlParameter("@EmailEncargado", instanceproyecto.EmailEncargado));
                    command.Parameters.Add(new SqlParameter("@NombreEncargado", instanceproyecto.NombreEncargado));
                    command.Parameters.Add(new SqlParameter("@Metodologia", instanceproyecto.Metodologia));
                    command.Parameters.Add(new SqlParameter("@Recursos", instanceproyecto.Recursos));
                    command.Parameters.Add(new SqlParameter("@IdOrganizacionVinculada", instanceproyecto.OrganizacionVinculada));
                    command.Parameters.Add(new SqlParameter("@NumPersonalCoordinador", instanceproyecto.Coordinador));
                    try
                    {
                        command.ExecuteNonQuery();
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



        public List<Proyecto> GetProyecto()
        {

            List<Proyecto> listaProyecto = new List<Proyecto>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Proyecto", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Proyecto instanceproyecto = new Proyecto();

                        instanceproyecto.IdProyecto = reader["IdProyecto"].ToString();
                        instanceproyecto.Responsabilidades = reader["Responsabilidades"].ToString();
                        instanceproyecto.Actividad = reader["Actividad"].ToString();
                        instanceproyecto.Duracion = reader["Duracion"].ToString();
                        instanceproyecto.NombreProyecto = reader["NombreProyecto"].ToString();
                        instanceproyecto.Descripcion = reader["Descripcion"].ToString();
                        instanceproyecto.Objetivogeneral = reader["ObjetivoGeneral"].ToString();
                        instanceproyecto.ObjetivoMediato = reader["ObjetivoMediato"].ToString();
                        instanceproyecto.CargoEncargado = reader["CargoEncargado"].ToString();
                        instanceproyecto.EmailEncargado = reader["EmailEncargado"].ToString();
                        instanceproyecto.NombreEncargado = reader["NombreEncargado"].ToString();
                        instanceproyecto.Metodologia = reader["Metodologia"].ToString();
                        instanceproyecto.Recursos = reader["Recursos"].ToString();
                        instanceproyecto.OrganizacionVinculada = reader["IdOrganizacionVinculada"].ToString();
                        instanceproyecto.Coordinador = reader["numPersonalCoordinador"].ToString();
                        listaProyecto.Add(instanceproyecto);
                    }
                }
                connection.Close();
            }
            return listaProyecto;
        }

        public Proyecto GetProyectoforID(String toSearchInBD)
        {
            Proyecto instanceproyecto = new Proyecto();
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
                using (SqlCommand instancecommand = new SqlCommand("SELECT * FROM dbo.Profesor WHERE IdProyecto = @IdProyectoToSearch", connection))
                {
                    instancecommand.Parameters.Add(new SqlParameter("IdProyectoToSearch", toSearchInBD));
                    SqlDataReader reader = instancecommand.ExecuteReader();
                    while (reader.Read())
                    {
                        instanceproyecto.IdProyecto = reader["NumdePersonal"].ToString();
                        instanceproyecto.Responsabilidades = reader["Responsabilidades"].ToString();
                        instanceproyecto.Actividad = reader["Actividad"].ToString();
                        instanceproyecto.Duracion = reader["Duracion"].ToString();
                        instanceproyecto.NombreProyecto = reader["NombreProyecto"].ToString();
                        instanceproyecto.Descripcion = reader["Descripcion"].ToString();
                        instanceproyecto.Objetivogeneral = reader["ObjetivoGeneral"].ToString();
                        instanceproyecto.ObjetivoMediato = reader["ObjetivoMediato"].ToString();
                        instanceproyecto.CargoEncargado = reader["CargoEncargo"].ToString();
                        instanceproyecto.EmailEncargado = reader["EmailEncargado"].ToString();
                        instanceproyecto.NombreEncargado = reader["NombreEncargado"].ToString();
                        instanceproyecto.Metodologia = reader["Metodologia"].ToString();
                        instanceproyecto.Recursos = reader["Recursos"].ToString();
                        instanceproyecto.OrganizacionVinculada = reader["OrganizacionVinculada"].ToString();
                        instanceproyecto.Coordinador = reader["Coordinador"].ToString();

                    }
                }
                connection.Close();
            }
            return instanceproyecto;
        }


        public AddResult DeleteProyectoByID(String toSearchInBD)
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
                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Proyecto WHERE IdProyecto = @IdProyectoToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("IdProyectoToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }


    }
}
