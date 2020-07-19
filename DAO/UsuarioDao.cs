using Conection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Pojos.Usuario;
using System.Linq.Expressions;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    class UsuarioDao
    {
        public String PassHash(String data)
        {
            SHA1 sha = SHA1.Create();
            byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder stringBuilderValue = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                stringBuilderValue.Append(hashData[i].ToString());
            }
            return stringBuilderValue.ToString();
        }




        public AddResult doLoging(String username,String password) {

            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    resultado = AddResult.SQLFail;
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE Usuario = @usuario AND contraseña = @contraseña", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", username));
                    command.Parameters.Add(new SqlParameter("@contraseña", password));

                    try
                    {
                        
                        SqlDataReader reader = command.ExecuteReader();
                        Usuario usuario = new Usuario();
                        while (reader.Read()) {
                            
                            usuario.Password = reader["contraseña"].ToString();
                            usuario.UserName = reader["Usuario"].ToString();
                            resultado = AddResult.Success;
                            Properties.Settings.Default.tipoUsuario = reader["Tipo_Usuario"].ToString();
                        }

                        if (usuario.UserName == null) {
                            resultado = AddResult.InvalidOrganization;
                        
                        }

                    }
                    catch (SqlException) {

                        resultado = AddResult.NullObject;
                    
                    }
                    catch (Exception e)
                    {

                        resultado = AddResult.SQLFail;
                    }

                    
                }
                connection.Close();
            }
            return resultado;


        }
        
        
        
        public AddResult AddUsuario(Usuario usuario)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    resultado = AddResult.SQLFail;
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Usuarios VALUES(@nombre, @correo, @registro, @tipo, @estatus, @usuario, @contraseña)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@nombre", usuario.Name));
                    command.Parameters.Add(new SqlParameter("@correo", usuario.Email));
                    command.Parameters.Add(new SqlParameter("@registro", usuario.RegisterDate));
                    command.Parameters.Add(new SqlParameter("@tipo", usuario.UserType));
                    command.Parameters.Add(new SqlParameter("@estatus", ""));
                    command.Parameters.Add(new SqlParameter("@usuario", usuario.UserName));
                    command.Parameters.Add(new SqlParameter("@contraseña", PassHash(usuario.Password)));
                    try
                    {
                        command.ExecuteNonQuery();



                    }catch(Exception ){

                        resultado = AddResult.SQLFail;
                    }
                    
                    
                    
                   
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }
        public Usuario GetUsuarioByUsername(String username)
        {
            Usuario usuario = new Usuario();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE Usuario = @usernameToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("usernameToSearch", username));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usuario.Name = reader["Nombre"].ToString();
                        usuario.Email = reader["Correo"].ToString();
                        usuario.UserType = reader["Tipo_Usuario"].ToString();
                        usuario.UserName = reader["Usuario"].ToString();
                    }
                }
                connection.Close();
            }
            return usuario;
        }
    }
}
