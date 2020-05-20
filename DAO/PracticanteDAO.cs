using Conection;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Practicante;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class PracticanteDAO : IPracticanteDAO
    {
        private AddResult CheckObjectPracticante(Practicante practicante)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (practicante.MatriculaPracticante == String.Empty ||
                practicante.NombresPracticante == String.Empty ||
                practicante.ApellidoPaternoPracticante == String.Empty ||
                practicante.ApellidoMaternoPracticante == String.Empty ||
                practicante.PeriodoPracticante == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarMatricula(practicante.MatriculaPracticante) == CheckFields.ResultadosValidación.MatriculaInvalida)
            {
                throw new FormatException("Matricula inválida " + practicante.MatriculaPracticante);
            }
            else
            if (validarCampos.ValidarNombres(practicante.NombresPracticante) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + practicante.NombresPracticante);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }






        public AddResult AddPracticante(Practicante practicante)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectPracticante(practicante);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Practicante VALUES(@Nombr@Matricula, es, @ApellidoPaterno, @ApellidoMaterno, @Periodo)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Matricula", practicante.MatriculaPracticante));
                    command.Parameters.Add(new SqlParameter("@Nombres", practicante.NombresPracticante));
                    command.Parameters.Add(new SqlParameter("@ApellidoPaterno", practicante.ApellidoPaternoPracticante));
                    command.Parameters.Add(new SqlParameter("@ApellidoMaterno", practicante.ApellidoMaternoPracticante));
                    command.Parameters.Add(new SqlParameter("@Periodo", practicante.PeriodoPracticante));
                    
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

        public List<Practicante> GetPracticante()
        {

            List<Practicante> listaPracticante = new List<Practicante>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Practicante", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Practicante practicante = new Practicante();

                        practicante.MatriculaPracticante = reader["Matricula"].ToString();
                        practicante.NombresPracticante = reader["Nombres"].ToString();
                        practicante.ApellidoPaternoPracticante = reader["ApellidoPaterno"].ToString();
                        practicante.ApellidoMaternoPracticante = reader["ApellidoMaterno"].ToString();
                        practicante.PeriodoPracticante = reader["Periodo"].ToString();
                        
                        listaPracticante.Add(practicante);
                    }
                }
                connection.Close();
            }
            return listaPracticante;
        }



        public Practicante GetPracticanteMatricula(String toSearchInBD)
        {
            Practicante practicante = new Practicante();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Practicante WHERE Matricula = @MatriculaToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("MatriculaToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        practicante.MatriculaPracticante = reader["Matricula"].ToString();
                        practicante.NombresPracticante = reader["Nombres"].ToString();
                        practicante.ApellidoPaternoPracticante = reader["ApellidoPaterno"].ToString();
                        practicante.ApellidoMaternoPracticante = reader["ApellidoMaterno"].ToString();
                        practicante.PeriodoPracticante = reader["Periodo"].ToString();
                        
                    }
                }
                connection.Close();
            }
            return practicante;
        }

        public AddResult DeletePracticanteByMatricula(String toSearchInBD)
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
                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Practicante WHERE Matricula = @MatriculaToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("MatriculaToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }
    }
}
