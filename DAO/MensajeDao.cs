using Sistema_de_Prácticas_Profesionales.Pojos.Mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Logica;
using Conection;
using System.Data.SqlClient;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
     class MensajeDao : IMensajeDao
    {
        private AddResult CheckObjectMensaje(Mensaje mensaje)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (mensaje.Receptor == String.Empty ||

                mensaje.Emisor == String.Empty ||
                mensaje.Texto == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarNumeropersonal(mensaje.Receptor) == CheckFields.ResultadosValidación.NúmeroVálido || validarCampos.ValidarMatricula(mensaje.Receptor) == CheckFields.ResultadosValidación.MatriculaValida)
            {
                result = AddResult.Success;
            } else 
            { 
                throw new FormatException("Receptor Invalido " + mensaje.Receptor); 
            }
            if (validarCampos.ValidarNumeropersonal(mensaje.Emisor) == CheckFields.ResultadosValidación.NúmeroVálido || validarCampos.ValidarNumeropersonal(mensaje.Emisor) == CheckFields.ResultadosValidación.MatriculaValida)
            {
                result = AddResult.Success;
                
            }
            else {

                throw new FormatException("Emisor Invalido " + mensaje.Emisor);
            }

            
                result = AddResult.Success;
            
            return result;

        }

        public AddResult addMensaje(Mensaje mensaje)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectMensaje(mensaje);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.mensajes VALUES(@receptor, @emisor, @mensaje)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@receptor", mensaje.Receptor));
                    command.Parameters.Add(new SqlParameter("@emisor", mensaje.Emisor));
                    command.Parameters.Add(new SqlParameter("@mensaje", mensaje.Texto));

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

        public List<Mensaje> GetMensajesbyReceptor(String toSearchInBD)
        {
            List<Mensaje> listaMensaje = new List<Mensaje>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.mensajes WHERE receptor = @receptorParaBuscar", connection))
                {
                    command.Parameters.Add(new SqlParameter("receptorParaBuscar", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Mensaje mensaje = new Mensaje();
                        mensaje.Receptor = reader["receptor"].ToString();

                        mensaje.Emisor = reader["emisor"].ToString();
                        mensaje.Texto = reader["mensje"].ToString();
                        listaMensaje.Add(mensaje);


                    }
                }
                connection.Close();
            }
            return listaMensaje;
        } 


      }






    }

