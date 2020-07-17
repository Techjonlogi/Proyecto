using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Documento;
using System.Data.SqlClient;
using Conection;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    class DocumentoDao:IDocumentoDao
    {



        private AddResult CheckObjectDocumento(DocumentoPracticas documento)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (documento.RutaDocumento==String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }












        public AddResult AddDocumento(DocumentoPracticas documento)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectDocumento(documento);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Documentos VALUES (@ruta)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ruta", documento.RutaDocumento));
                   ;
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











    }
}
