using Conection;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Administrador;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Realizado por Alfredo Delgado

namespace Sistema_de_Prácticas_Profesionales.DAO
{
        public class AdministradorDAO : IAdministradorDAO
        {
        private AddResult CheckObjectAdministrador(Administrador administrador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (administrador.UsuarioAdministrador == String.Empty ||
                administrador.ContraseñaAdministrador == String.Empty ||
                administrador.NombresAdministrador == String.Empty ||
                administrador.ApellidoPaternoAdministrador == String.Empty ||
                administrador.ApellidoPaternoAdministrador == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarUsuario(administrador.UsuarioAdministrador) == CheckFields.ResultadosValidación.UsuarioInvalido)
                {
                    throw new FormatException("Usuario inválido " + administrador.UsuarioAdministrador);
                }
                else
                if (validarCampos.ValidarNombres(administrador.NombresAdministrador) == CheckFields.ResultadosValidación.NombresInvalidos)
                {
                    throw new FormatException("Nombre inválido " + administrador.NombresAdministrador);
                }
                else
                {
                    result = AddResult.Success;
                }
                return result;
            }






            public AddResult AddAdministrador(Administrador administrador)
            {
                AddResult resultado = AddResult.UnknowFail;
                DbConnection dbConnection = new DbConnection();
                AddResult checkForEmpty = AddResult.UnknowFail;
                try
                {
                    checkForEmpty = CheckObjectAdministrador(administrador);
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
                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Administrador VALUES(@Nombres, @ApellidoPaterno, @ApellidoMaterno, @Usuario, @Contraseña)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Nombres", administrador.NombresAdministrador));
                        command.Parameters.Add(new SqlParameter("@ApellidoPaterno", administrador.ApellidoPaternoAdministrador));
                        command.Parameters.Add(new SqlParameter("@ApellidoMaterno", administrador.ApellidoMaternoAdministrador));
                        command.Parameters.Add(new SqlParameter("@Usuario", administrador.UsuarioAdministrador));
                        command.Parameters.Add(new SqlParameter("@Contraseña", administrador.ContraseñaAdministrador));
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

            public List<Administrador> GetAdministrador()
            {

                List<Administrador> listaAdministrador = new List<Administrador>();
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
                    using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Administrador", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Administrador administrador = new Administrador();

                            administrador.NombresAdministrador = reader["Nombres"].ToString();
                            administrador.ApellidoPaternoAdministrador = reader["ApellidoPaterno"].ToString();
                            administrador.ApellidoMaternoAdministrador = reader["ApellidoMaterno"].ToString();
                            administrador.UsuarioAdministrador = reader["UsuarioAdministrador"].ToString();
                            administrador.ContraseñaAdministrador = reader["Contraseña"].ToString();
                            listaAdministrador.Add(administrador);
                        }
                    }
                    connection.Close();
                }
                return listaAdministrador;
            }



            public Administrador GetIdAdministrador(String toSearchInBD)
            {
                Administrador administrador = new Administrador();
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
                    using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Administrador WHERE idAdministrador = @idToSearch", connection))
                    {
                        command.Parameters.Add(new SqlParameter("idToSearch", toSearchInBD));
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            administrador.NombresAdministrador = reader["Nombres"].ToString();
                            administrador.ApellidoPaternoAdministrador = reader["ApellidoPaterno"].ToString();
                            administrador.ApellidoMaternoAdministrador = reader["ApellidoMaterno"].ToString();
                            administrador.UsuarioAdministrador = reader["Usuario"].ToString();
                            administrador.ContraseñaAdministrador = reader["Contraseña"].ToString();
                        }
                    }
                    connection.Close();
                }
                return administrador;
            }

        }
}
