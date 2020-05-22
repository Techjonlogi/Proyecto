using Conection;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Practica;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class PracticaDAO : IPracticaDAO
    {
        private AddResult CheckObjectPractica(Practica practica)
        {
            CheckFields checkFields = new CheckFields();
            AddResult addResult = AddResult.UnknowFail;

            if (practica.NombrePractica == String.Empty ||
                practica.NombreOrgVincPractica == String.Empty ||
                practica.NumEspaciosPractica == 0 ||
                practica.PeriodoPractica == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            if (checkFields.ValidarNombres(practica.NombrePractica) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + practica.NombrePractica);
            }
            else
            {
                addResult = AddResult.Success;
            }
            return addResult;
        }






        public AddResult AddPractica(Practica practica)
        {
            AddResult addResult = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectPractica(practica);
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
            using (SqlConnection sqlConnection = dbConnection.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.Practica VALUES(@Nombre, " +
                                                "@NumOrgVincPractica, @NumPracticantes, @Periodo)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@Nombre", practica.NombrePractica));
                    sqlCommand.Parameters.Add(new SqlParameter("@NombreOrgVinc", practica.NombreOrgVincPractica));
                    sqlCommand.Parameters.Add(new SqlParameter("@NumEspacios", practica.NumEspaciosPractica));
                    sqlCommand.Parameters.Add(new SqlParameter("@Periodo", practica.PeriodoPractica));
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
                sqlConnection.Close();
            }
            return addResult;
        }

        public List<Practica> GetPractica()
        {

            List<Practica> listPractica = new List<Practica>();
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
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.Practica", sqlConnection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Practica practica = new Practica();

                        practica.NombrePractica = sqlDataReader["Nombre"].ToString();
                        practica.NombreOrgVincPractica = sqlDataReader["NombreOrgVinc"].ToString();
                        practica.NumEspaciosPractica = Convert.ToInt32(sqlDataReader["NumEspacios"].ToString());
                        practica.PeriodoPractica = sqlDataReader["Periodo"].ToString();

                        listPractica.Add(practica);
                    }
                }
                sqlConnection.Close();
            }
            return listPractica;
        }



        public Practica GetPracticaNombre(String toSearchInBD)
        {
            Practica practica = new Practica();
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
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.Practica WHERE Nombre = @NombreToSearch", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("NombreToSearch", toSearchInBD));
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        practica.NombrePractica = sqlDataReader["Nombre"].ToString();
                        practica.NombreOrgVincPractica = sqlDataReader["NombreOrgVinc"].ToString();
                        practica.NumEspaciosPractica = Convert.ToInt16(sqlDataReader["NumEspacios"].ToString());
                        practica.PeriodoPractica = sqlDataReader["Periodo"].ToString();
                    }
                }
                sqlConnection.Close();
            }
            return practica;
        }

        public AddResult DeletePracticaNombre(String toSearchInBD)
        {
            AddResult addResult = AddResult.UnknowFail;
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
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM dbo.Practica WHERE Nombre = @IdToSearch", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("NombrePracticaToSearch", toSearchInBD));
                    sqlCommand.ExecuteNonQuery();
                    addResult = AddResult.Success;
                }
                sqlConnection.Close();
            }
            return addResult;
        }

    }
}
