using Conection;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Actividad;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class ActividadDAO : IActividadDAO
    {
        private AddResult CheckObjectActividad(Actividad instanceActividad)
        {
            CheckFields instanceCheckFields = new CheckFields();
            AddResult instanceAddResult = AddResult.UnknowFail;

            if (instanceActividad.IdActividad == String.Empty ||
                instanceActividad.NombreActividad == String.Empty ||
                instanceActividad.DiaEntregaActividad == 0 ||
                instanceActividad.MesEntregaActividad == 0 ||
                instanceActividad.AñoEntregaActividad == String.Empty ||
                instanceActividad.ValorActividad == 0)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            if (instanceCheckFields.ValidarNombreArtefacto(instanceActividad.NombreActividad) == CheckFields.ResultadosValidación.NombreArtefactoInvalido)
            {
                throw new FormatException("Nombre inválido " + instanceActividad.NombreActividad);
            }
            else
            {
                instanceAddResult = AddResult.Success;
            }
            return instanceAddResult;
        }






        public AddResult AddActividad(Actividad instanceActividad)
        {
            
            AddResult addResult = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectActividad(instanceActividad);
            }
            catch (ArgumentNullException)
            {
                addResult = AddResult.NullObject;
                return addResult;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection instanceSqlConnection = dbConnection.GetConnection())
            {
                instanceSqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO serviciosocial.actividad VALUES(@Id, @Nombre, @DiaEntrega, @MesEntrega, @AñoEntrega, @Valor)", instanceSqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@Id", instanceActividad.IdActividad));
                    sqlCommand.Parameters.Add(new SqlParameter("@Nombre", instanceActividad.NombreActividad));
                    sqlCommand.Parameters.Add(new SqlParameter("@DiaEntrega", instanceActividad.DiaEntregaActividad));
                    sqlCommand.Parameters.Add(new SqlParameter("@MesEntrega", instanceActividad.MesEntregaActividad));
                    sqlCommand.Parameters.Add(new SqlParameter("@AñoEntrega", instanceActividad.AñoEntregaActividad));
                    sqlCommand.Parameters.Add(new SqlParameter("@Valor", instanceActividad.ValorActividad));
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        addResult = AddResult.SQLFail;
                        return addResult;
                    }
                    addResult = AddResult.Success;
                }
                instanceSqlConnection.Close();
            }
            return addResult;
        }

        public List<Actividad> GetActividad()
        {

            List<Actividad> listaActividad = new List<Actividad>();
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection sqlConnection = dbConnection.GetConnection())
            {
                try
                {
                   sqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM serviciosocial.actividad", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Actividad actividad = new Actividad();

                        actividad.IdActividad = reader["Id"].ToString();
                        actividad.NombreActividad = reader["Nombre"].ToString();
                        actividad.DiaEntregaActividad = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        actividad.MesEntregaActividad = Convert.ToInt32(reader["MesEntrega"].ToString());
                        actividad.AñoEntregaActividad = reader["AñoEntrega"].ToString();
                        actividad.ValorActividad = Convert.ToDouble(reader["Valor"].ToString());

                        listaActividad.Add(actividad);
                    }
                }
                sqlConnection.Close();
            }
            return listaActividad;
        }



        public Actividad GetActividadID(String toSearchInBD)
        {
            Actividad actividad = new Actividad();
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection sqlConnection = dbConnection.GetConnection())
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM serviciosocial.actividad WHERE idActividad = @IdToSearch", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("IdToSearch", toSearchInBD));
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        actividad.IdActividad = reader["Id"].ToString();
                        actividad.NombreActividad = reader["Nombre"].ToString();
                        actividad.DiaEntregaActividad = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        actividad.MesEntregaActividad = Convert.ToInt32(reader["MesEntrega"].ToString());
                        actividad.AñoEntregaActividad = reader["AñoEntrega"].ToString();
                        actividad.ValorActividad = Convert.ToDouble(reader["SectorSocial"].ToString());
                    }
                }
                sqlConnection.Close();
            }
            return actividad;
        }

        public AddResult DeleteActividadID(String toSearchInBD)
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
                using (SqlCommand command = new SqlCommand("DELETE FROM serviciosocial.actividad WHERE  idActividad = @IdToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("IdActividadToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }

    }
}