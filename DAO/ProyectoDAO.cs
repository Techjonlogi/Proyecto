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
        private AddResult CheckObjectProyecto(Proyecto proyecto)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult instanceresult = AddResult.UnknowFail;
            if (proyecto.IdProyecto == String.Empty ||
                proyecto.Responsabilidades == String.Empty ||
                proyecto.Actividad == String.Empty ||
                proyecto.Duracion == String.Empty ||
                proyecto.NombreProyecto == String.Empty ||
                proyecto.Descripcion == String.Empty ||
                proyecto.Objetivogeneral == String.Empty ||
                proyecto.ObjetivoMediato == String.Empty ||
                proyecto.CargoEncargado == String.Empty ||
                proyecto.EmailEncargado == String.Empty ||
                proyecto.NombreEncargado == String.Empty ||
                proyecto.Metodologia == String.Empty ||
                proyecto.Recursos == String.Empty ||
                proyecto.OrganizacionVinculada == null ||
                proyecto.Coordinador == null)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarMatricula(proyecto.IdProyecto) == CheckFields.ResultadosValidación.MatriculaInvalida)
            {
                throw new FormatException("id de proyecto invalido " + proyecto.IdProyecto);
            }
            else
            if (validarCampos.ValidarNombres(proyecto.NombreProyecto) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + proyecto.NombreProyecto);
            }
            else
            {
                instanceresult = AddResult.Success;
            }
            return instanceresult;
        }

        public AddResult AddProyecto(Proyecto proyecto)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectProyecto(proyecto);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Profesor VALUES(@IdProyecto, @Responsabilidades, @Actividad, @Duracion, @NombreProyecto, @Descripcion, @ObjetivoGeneral, @ObjetivoMediato, @CargoEncargado, @EmailEncargado, @NombreEncargado, @Metodologia, @Recursos, @IdOrganizacionVinculada, @NumPersonalCoordinador)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdProyecto", proyecto.IdProyecto));
                    command.Parameters.Add(new SqlParameter("@Responsabilidades",proyecto.Responsabilidades));
                    command.Parameters.Add(new SqlParameter("@Actividad", proyecto.Actividad));
                    command.Parameters.Add(new SqlParameter("@Duracion", proyecto.Duracion));
                    command.Parameters.Add(new SqlParameter("@NombreProyecto", proyecto.NombreProyecto));
                    command.Parameters.Add(new SqlParameter("@Descripcion", proyecto.Descripcion));
                    command.Parameters.Add(new SqlParameter("@ObjetivoGeneral", proyecto.Objetivogeneral));
                    command.Parameters.Add(new SqlParameter("@ObjetivoMediato", proyecto.ObjetivoMediato));
                    command.Parameters.Add(new SqlParameter("@CargoEncargado", proyecto.CargoEncargado));
                    command.Parameters.Add(new SqlParameter("@EmailEncargado", proyecto.EmailEncargado));
                    command.Parameters.Add(new SqlParameter("@NombreEncargado", proyecto.NombreEncargado));
                    command.Parameters.Add(new SqlParameter("@Metodologia", proyecto.Metodologia));
                    command.Parameters.Add(new SqlParameter("@Recursos", proyecto.Recursos));
                    command.Parameters.Add(new SqlParameter("@IdOrganizacionVinculada", proyecto.OrganizacionVinculada));
                    command.Parameters.Add(new SqlParameter("@NumPersonalCoordinador", proyecto.Coordinador));
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.proyecto", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();

                        proyecto.IdProyecto = reader["IdProyecto"].ToString();
                        proyecto.Responsabilidades = reader["Responsabilidades"].ToString();
                        proyecto.Actividad = reader["Actividades"].ToString();
                        proyecto.Duracion = reader["Duracion"].ToString();
                        proyecto.NombreProyecto = reader["NombreProyecto"].ToString();
                        proyecto.Descripcion = reader["Descripcion"].ToString();
                        proyecto.Objetivogeneral = reader["objetivoGeneral"].ToString();
                        proyecto.ObjetivoMediato = reader["objetivoMediato"].ToString();
                        proyecto.CargoEncargado = reader["cargoEncargado"].ToString();
                        proyecto.EmailEncargado = reader["emailEncargado"].ToString();
                        proyecto.NombreEncargado = reader["NombreEncargado"].ToString();
                        proyecto.Metodologia = reader["Metodologia"].ToString();
                        proyecto.Recursos = reader["Recursos"].ToString();
                        
                        listaProyecto.Add(proyecto);
                    }
                }
                connection.Close();
            }
            return listaProyecto;
        }

        public Proyecto GetProyectoforID(String toSearchInBD)
        {
            Proyecto proyecto = new Proyecto();
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
                using (SqlCommand instancecommand = new SqlCommand("SELECT * FROM serviciosocial.proyecto WHERE idProyecto = @IdProyectoToSearch", connection))
                {
                    instancecommand.Parameters.Add(new SqlParameter("IdProyectoToSearch", toSearchInBD));
                    SqlDataReader reader = instancecommand.ExecuteReader();
                    while (reader.Read())
                    {
                        proyecto.IdProyecto = reader["idProyecto"].ToString();
                        proyecto.Responsabilidades = reader["Responsabilidades"].ToString();
                        proyecto.Actividad = reader["Actividades"].ToString();
                        proyecto.Duracion = reader["Duracion"].ToString();
                        proyecto.NombreProyecto = reader["NombreProyecto"].ToString();
                        proyecto.Descripcion = reader["Descripcion"].ToString();
                        proyecto.Objetivogeneral = reader["objetivoGeneral"].ToString();
                        proyecto.ObjetivoMediato = reader["objetivoMediato"].ToString();
                        proyecto.CargoEncargado = reader["cargoEncargado"].ToString();
                        proyecto.EmailEncargado = reader["emailEncargado"].ToString();
                        proyecto.NombreEncargado = reader["NombreEncargado"].ToString();
                        proyecto.Metodologia = reader["Metodologia"].ToString();
                        proyecto.Recursos = reader["Recursos"].ToString();
                        proyecto.OrganizacionVinculada = null;
                        proyecto.Coordinador = null;
                        

                    }
                }
                connection.Close();
            }
            return proyecto;
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
