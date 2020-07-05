using Conection;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    public class CoordinadorDAO : ICoordinadorDAO
    {
        private AddResult CheckObjectCoordinador(Coordinador coordinador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (coordinador.NoPersonal == String.Empty ||
                coordinador.NombresCoordinador == String.Empty ||
                coordinador.ApellidoPaternoCoordinador == String.Empty ||
                coordinador.ApellidoMaternoCoordinador == String.Empty ||
                coordinador.UsuarioCoordinador == String.Empty ||
                coordinador.ContraseñaCoordinador == String.Empty ||
                coordinador.CubiculoCoordinador == String.Empty ||
                coordinador.FechaDeBajaCoordinador == String.Empty ||
                coordinador.FechaDeRegistroCoordinador == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarUsuario(coordinador.UsuarioCoordinador) == CheckFields.ResultadosValidación.UsuarioInvalido)
            {
                throw new FormatException("Usuario inválido " + coordinador.UsuarioCoordinador);
            }
            else
                if (validarCampos.ValidarNombres(coordinador.NombresCoordinador) == CheckFields.ResultadosValidación.NombresInvalidos)
            {
                throw new FormatException("Nombre inválido " + coordinador.NombresCoordinador);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }






        public AddResult AddCoordinador(Coordinador coordinador)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectCoordinador(coordinador);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO serviciosocial.coordinador VALUES (@NumdePersonal ,@contraseña ,@FechDeRegistroCoordinador ,null ,@NombresCoordinador ,@ApellidoPaternoCoordinador ,@ApellidoMaternoCoordinador ,@UsuarioCoordinador ,@CubiculoCoordinador)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@NumdePersonal", coordinador.NoPersonal));
                    command.Parameters.Add(new SqlParameter("@NombresCoordinador", coordinador.NombresCoordinador));
                    command.Parameters.Add(new SqlParameter("@ApellidoPaternoCoordinador", coordinador.ApellidoPaternoCoordinador));
                    command.Parameters.Add(new SqlParameter("@ApellidoMaternoCoordinador", coordinador.ApellidoMaternoCoordinador));
                    command.Parameters.Add(new SqlParameter("@UsuarioCoordinador", coordinador.UsuarioCoordinador));
                    command.Parameters.Add(new SqlParameter("@contraseña", coordinador.ContraseñaCoordinador));
                    command.Parameters.Add(new SqlParameter("@CubiculoCoordinador", coordinador.CubiculoCoordinador));
                    
                    command.Parameters.Add(new SqlParameter("@FechDeRegistroCoordinador", coordinador.FechaDeRegistroCoordinador));
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException )
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

        public List<Coordinador> GetCoordinador()
        {

            List<Coordinador> listaCoordinador = new List<Coordinador>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.coordinador", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Coordinador coordinador = new Coordinador();

                        coordinador.NoPersonal = reader["NumdePersonal"].ToString();
                        coordinador.ContraseñaCoordinador = reader["contraseña"].ToString();
                        coordinador.FechaDeRegistroCoordinador = reader["fechaderegistro"].ToString();
                        coordinador.FechaDeBajaCoordinador = reader["fechadebaja"].ToString();
                        coordinador.NombresCoordinador = reader["Nombres"].ToString();
                        coordinador.ApellidoPaternoCoordinador = reader["apellidoPaterno"].ToString();
                        coordinador.ApellidoMaternoCoordinador = reader["apellidoMaterno"].ToString();
                        coordinador.UsuarioCoordinador = reader["usuario"].ToString();
                        coordinador.CubiculoCoordinador = reader["cubiculo"].ToString();
                        
                        
                        listaCoordinador.Add(coordinador);
                    }
                }
                connection.Close();
            }
            return listaCoordinador;
        }



        public Coordinador GetNoPersonalCoordinador(String toSearchInBD)
        {
            Coordinador coordinador = new Coordinador();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.coordinador WHERE NumdePersonal = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        coordinador.NoPersonal = reader["NumdePersonal"].ToString();
                        coordinador.ContraseñaCoordinador = reader["contraseña"].ToString();
                        coordinador.FechaDeRegistroCoordinador = reader["fechaderegistro"].ToString();
                        coordinador.FechaDeBajaCoordinador = reader["fechadebaja"].ToString();
                        coordinador.NombresCoordinador = reader["Nombres"].ToString();
                        coordinador.ApellidoPaternoCoordinador = reader["apellidoPaterno"].ToString();
                        coordinador.ApellidoMaternoCoordinador = reader["apellidoMaterno"].ToString();
                        coordinador.UsuarioCoordinador = reader["usuario"].ToString();
                        coordinador.CubiculoCoordinador = reader["cubiculo"].ToString();
                    }
                }
                connection.Close();
            }
            return coordinador;
        }

        public AddResult DeleteCoordiandorpornumerodePersonal(String toSearchInBD)
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
                using (SqlCommand command = new SqlCommand("DELETE FROM serviciosocial.coordinador WHERE NumdePersonal = @Numeroabuscar", connection))
                {
                    command.Parameters.Add(new SqlParameter("Numeroabuscar", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }

    }
}
