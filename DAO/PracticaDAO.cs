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
        private AddResult CheckObjectPractica(Practica instancePractica)
        {
            CheckFields instanceCheckFields = new CheckFields();
            AddResult instanceAddResult = AddResult.UnknowFail;

            if (instancePractica.NombrePractica == String.Empty ||
                instancePractica.NumOrgVincPractica == 0 ||
                instancePractica.NumPracticantes == 0 ||
                instancePractica.NumProfesores == 0 ||
                instancePractica.NumProyectos == 0 ||
                instancePractica.PeriodoPractica == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            if (instanceCheckFields.ValidarNombres(instancePractica.NombrePractica) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + instancePractica.NombrePractica);
            }
            else
            {
                instanceAddResult = AddResult.Success;
            }
            return instanceAddResult;
        }






        public AddResult AddPractica(Practica instancePractica)
        {
            AddResult instanceAddResult = AddResult.UnknowFail;
            DbConnection instanceDbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectPractica(instancePractica);
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
                using (SqlCommand instanceSqlCommand = new SqlCommand("INSERT INTO dbo.Practica VALUES(@Nombre, @NumOrgVincPractica, @NumPracticantes, @NumProfesores, @NumProyectos, @Periodo)", instanceSqlConnection))
                {
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@Id", instancePractica.NombrePractica));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@Nombre", instancePractica.NumOrgVincPractica));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@DiaEntrega", instancePractica.NumPracticantes));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@MesEntrega", instancePractica.NumProfesores));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@AñoEntrega", instancePractica.NumProyectos));
                    instanceSqlCommand.Parameters.Add(new SqlParameter("@Valor", instancePractica.PeriodoPractica));
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

        public List<Practica> GetPractica()
        {

            List<Practica> instanceListaPractica = new List<Practica>();
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
                using (SqlCommand instanceSqlCommand = new SqlCommand("SELECT * FROM dbo.Practica", instanceSqlConnection))
                {
                    SqlDataReader reader = instanceSqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Practica instancePractica = new Practica();

                        instancePractica.NombrePractica = reader["Id"].ToString();
                        instancePractica.NumOrgVincPractica = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instancePractica.NumPracticantes = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instancePractica.NumProfesores = Convert.ToInt16(reader["DiaEntrega"].ToString());
                        instancePractica.NumProyectos = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instancePractica.PeriodoPractica = reader["Valor"].ToString();

                        instanceListaPractica.Add (instancePractica);
                    }
                }
                instanceSqlConnection.Close();
            }
            return instanceListaPractica;
        }



        public Practica GetPracticaNombre(String toSearchInBD)
        {
            Practica instancePractica = new Practica();
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
                using (SqlCommand instanceSqlCommand = new SqlCommand("SELECT * FROM dbo.Practica WHERE Nombre = @NombreToSearch", instanceSqlConnection))
                {
                    instanceSqlCommand.Parameters.Add(new SqlParameter("NombreToSearch", toSearchInBD));
                    SqlDataReader reader = instanceSqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        instancePractica.NombrePractica = reader["Id"].ToString();
                        instancePractica.NumOrgVincPractica = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instancePractica.NumPracticantes = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instancePractica.NumProfesores = Convert.ToInt16(reader["DiaEntrega"].ToString());
                        instancePractica.NumProyectos = Convert.ToInt32(reader["DiaEntrega"].ToString());
                        instancePractica.PeriodoPractica = reader["Valor"].ToString();
                    }
                }
                instanceSqlConnection.Close();
            }
            return instancePractica;
        }

    }
}
