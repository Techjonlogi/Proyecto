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
            AddResult instanceAddResult = AddResult.UnknowFail;
            DbConnection instanceDbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectActividad(instanceActividad);
            }
            catch (ArgumentNullException)
            {
                instanceAddResult = AddResult.NullObject;
                return instanceAddResult;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection instanceSqlConnection = instanceDbConnection.GetConnection())
            {
                instanceSqlConnection.Open();
                using (SqlCommand instanceSqlCommand = new SqlCommand("INSERT INTO serviciosocial.actividad VALUES(@Id, @Nombre, @DiaEntrega, @MesEntrega, @AñoEntrega, @Valor)", instanceSqlConnection))
                {
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@Id", instanceActividad.IdActividad));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@Nombre", instanceActividad.NombreActividad));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@DiaEntrega", instanceActividad.DiaEntregaActividad));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@MesEntrega", instanceActividad.MesEntregaActividad));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@AñoEntrega", instanceActividad.AñoEntregaActividad));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@Valor", instanceActividad.ValorActividad));
                    try
                    {
                        instanceSqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        instanceAddResult = AddResult.SQLFail;
                        return instanceAddResult;
                    }
                    instanceAddResult = AddResult.Success;
                }
                instanceSqlConnection.Close();
            }
            return instanceAddResult;
        }

        public List<Actividad> GetActividad()
        {

            List<Actividad> instanceListaActividad = new List<Actividad>();
            DbConnection instanceDbConnection = new DbConnection();
            using (SqlConnection instanceSqlConnection = instanceDbConnection.GetConnection())
            {
                try
                {
                    instanceSqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand instanceSqlCommand = new SqlCommand("SELECT * FROM serviciosocial.actividad", instanceSqlConnection))
                {
                    SqlDataReader reader = instanceSqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Actividad actividad = new Actividad();

                        actividad.IdActividad = reader["Id"].ToString();
                        actividad.NombreActividad = reader["Nombre"].ToString();
                        actividad.DiaEntregaActividad = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        actividad.MesEntregaActividad = Convert.ToInt32(reader["MesEntrega"].ToString());
                        actividad.AñoEntregaActividad = reader["AñoEntrega"].ToString();
                        actividad.ValorActividad = Convert.ToDouble(reader["Valor"].ToString());

                        instanceListaActividad.Add(actividad);
                    }
                }
                instanceSqlConnection.Close();
            }
            return instanceListaActividad;
        }



        public Actividad GetActividadID(String toSearchInBD)
        {
            Actividad instanceActividad = new Actividad();
            DbConnection instanceDbConnection = new DbConnection();
            using (SqlConnection instanceSqlConnection = instanceDbConnection.GetConnection())
            {
                try
                {
                    instanceSqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand instanceSqlCommand = new SqlCommand("SELECT * FROM serviciosocial.actividad WHERE idActividad = @IdToSearch", instanceSqlConnection))
                {
                    instanceSqlCommand.Parameters.Add(new SqlParameter("IdToSearch", toSearchInBD));
                    SqlDataReader reader = instanceSqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        instanceActividad.IdActividad = reader["Id"].ToString();
                        instanceActividad.NombreActividad = reader["Nombre"].ToString();
                        instanceActividad.DiaEntregaActividad = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instanceActividad.MesEntregaActividad = Convert.ToInt32(reader["MesEntrega"].ToString());
                        instanceActividad.AñoEntregaActividad = reader["AñoEntrega"].ToString();
                        instanceActividad.ValorActividad = Convert.ToDouble(reader["SectorSocial"].ToString());
                    }
                }
                instanceSqlConnection.Close();
            }
            return instanceActividad;
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
                using (SqlCommand instancecommand = new SqlCommand("DELETE FROM serviciosocial.actividad WHERE  idActividad = @IdToSearch", connection))
                {
                    instancecommand.Parameters.Add(new SqlParameter("IdActividadToSearch", toSearchInBD));
                    instancecommand.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }

    }
}