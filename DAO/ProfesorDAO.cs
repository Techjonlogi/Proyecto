//realizado por Jonathan de jesus moreno martinez 30/04/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Pojos.Profesor;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Conection;
using System.Data.SqlClient;

namespace Sistema_de_Prácticas_Profesionales.DAO
{
    class ProfesorDAO : IProfesorDAO
    {

        private AddResult CheckObjectProfesor(Profesor profesor)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (profesor.IdProfesor == String.Empty ||
                
                profesor.NombresProfesor == String.Empty ||
                profesor.ApellidoPaternoProfesor == String.Empty ||
                profesor.ApellidoMaternoProfesor == String.Empty ||
                profesor.UsuarioProfesor == String.Empty ||
                profesor.ContraseñaProfesor == String.Empty ||
                profesor.FechaRegistroProfesor == String.Empty ||
                profesor.FechaBajaProfesor == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarNumeropersonal(profesor.IdProfesor) == CheckFields.ResultadosValidación.NúmeroInválido)
            {
                throw new FormatException("Numero invalido " + profesor.IdProfesor);
            }
            if (validarCampos.ValidarNombres(profesor.NombresProfesor) == CheckFields.ResultadosValidación.NombresInvalidos) {

                throw new FormatException("Nombre Invalido " + profesor.NombresProfesor);
            }
            else

            {
                result = AddResult.Success;
            }
            return result;
        }

        public AddResult AddProfesor(Profesor profesor)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectProfesor(profesor);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO serviciosocial.profesor VALUES(@numdePersonal, @nombres, @apellidoPaterno, @apellidoMaterno, @contraseña, @turno, null, @fechadeRegistro, null, null )", connection))
                {
                    command.Parameters.Add(new SqlParameter("@numdePersonal", profesor.IdProfesor));
                    command.Parameters.Add(new SqlParameter("@nombres", profesor.NombresProfesor));
                    command.Parameters.Add(new SqlParameter("@apellidoPaterno", profesor.ApellidoPaternoProfesor));
                    command.Parameters.Add(new SqlParameter("@apellidoMaterno", profesor.ApellidoMaternoProfesor));
                    command.Parameters.Add(new SqlParameter("@usuario", profesor.UsuarioProfesor));
                    command.Parameters.Add(new SqlParameter("@contraseña", profesor.ContraseñaProfesor));
                    command.Parameters.Add(new SqlParameter("@fechadeRegistro", profesor.FechaRegistroProfesor));
                    command.Parameters.Add(new SqlParameter("@turno", profesor.Turno));
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


        public List<Profesor> GetProfesor()
        {

            List<Profesor> listaProfesor = new List<Profesor>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.profesor", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Profesor profesor = new Profesor();

                        profesor.IdProfesor = reader["NumdePersonal"].ToString();

                       
                        profesor.NombresProfesor = reader["Nombres"].ToString();
                        profesor.ApellidoPaternoProfesor = reader["apellidoPaterno"].ToString();
                        profesor.ApellidoMaternoProfesor = reader["apellidoMaterno"].ToString();
                        profesor.Turno = reader["turno"].ToString();
                        profesor.FechaRegistroProfesor = reader["FechadeRegistro"].ToString();
                        profesor.FechaBajaProfesor = reader["FechadeBaja"].ToString();
                        listaProfesor.Add(profesor);
                    }
                }
                connection.Close();
            }
            return listaProfesor;
        }

        public Profesor GetProfesorforID(String toSearchInBD)
        {
            Profesor profesor = new Profesor();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM serviciosocial.profesor WHERE NumdePersonal = @NumdePersonalToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("NumdePersonalToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        profesor.IdProfesor = reader["NumdePersonal"].ToString();
                        
                        profesor.NombresProfesor = reader["Nombres"].ToString();
                        profesor.ApellidoPaternoProfesor = reader["apellidoPaterno"].ToString();
                        profesor.ApellidoMaternoProfesor = reader["apellidoMaterno"].ToString();
                        profesor.UsuarioProfesor = reader["usuario"].ToString();
                        profesor.FechaRegistroProfesor = reader["FechaRegistro"].ToString();
                        profesor.FechaBajaProfesor = reader["FechaBaja"].ToString();

                    }
                }
                connection.Close();
            }
            return profesor;
        }

        public AddResult DeleteProfesorByID(String toSearchInBD)
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
                using (SqlCommand command = new SqlCommand("DELETE FROM serviciosocial.profesor WHERE NumdePersonal = @NumdePersonalToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("NumdePersonalToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }






    }
}
