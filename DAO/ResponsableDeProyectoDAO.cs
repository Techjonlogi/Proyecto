using Conection;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.ResponsableDeProyecto;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class ResponsableDeProyectoDAO : IResponsableDeProyectoDao
    {
        private AddResult CheckObjectResponsableDeProyecto(ResponsableDeProyecto responsableDeProyecto)
        {
           CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (responsableDeProyecto.CargoResponsable == String.Empty ||
                responsableDeProyecto.CorreoElectronicoResponsable == String.Empty ||
                responsableDeProyecto.NombreResponsable == String.Empty ||
                responsableDeProyecto.ApellidoPaternoResponsable == String.Empty ||
                responsableDeProyecto.ApellidoMaternoResponsable == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarUsuario(responsableDeProyecto.NombreResponsable) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + responsableDeProyecto.NombreResponsable);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }






        public AddResult AddResponsableDeProyecto(ResponsableDeProyecto responsableDeProyecto)
        { 
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectResponsableDeProyecto(responsableDeProyecto);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.ResponsableDeProyecto VALUES(@Cargo, @CorreoElectronico, @Nombres," +
                    " @ApellidoPaterno, @ApellidoMaterno)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Cargo", responsableDeProyecto.CargoResponsable));
                    command.Parameters.Add(new SqlParameter("@CorreoElectronico", responsableDeProyecto.CorreoElectronicoResponsable));
                    command.Parameters.Add(new SqlParameter("@Nombres", responsableDeProyecto.NombreResponsable));
                    command.Parameters.Add(new SqlParameter("@ApellidoPaterno", responsableDeProyecto.ApellidoPaternoResponsable));
                    command.Parameters.Add(new SqlParameter("@ApellidoMaterno", responsableDeProyecto.ApellidoMaternoResponsable));
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

        public List<ResponsableDeProyecto> GetResponsableDeProyecto()
        {

            List<ResponsableDeProyecto> listaResponsable = new List<ResponsableDeProyecto>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.ResponsableDeProyecto", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ResponsableDeProyecto responsableDeProyecto = new ResponsableDeProyecto();

                        responsableDeProyecto.CargoResponsable = reader["Cargo"].ToString();
                        responsableDeProyecto.CorreoElectronicoResponsable = reader["CorreoElectronico"].ToString();
                        responsableDeProyecto.NombreResponsable = reader["Nombres"].ToString();
                        responsableDeProyecto.ApellidoPaternoResponsable = reader["ApellidoPaterno"].ToString();
                        responsableDeProyecto.ApellidoMaternoResponsable = reader["ApellidoMaterno"].ToString();
                        listaResponsable.Add(responsableDeProyecto);
                    }
                }
                connection.Close();
            }
            return listaResponsable;
        }

    }
}
