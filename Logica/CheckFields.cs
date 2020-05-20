using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Prácticas_Profesionales.Logica
{
    public class CheckFields
    {
        public enum ResultadosValidación
        {
            ContraseñaInvalida,
            ContraseñaValida,

            MatriculaValida,
            MatriculaInvalida,

            NombresValidos,
            NombresInvalidos,

            NúmeroInválido,
            NúmeroVálido,

            RfcInválido,
            RfcVálido,

            UsuarioValido,
            UsuarioInvalido

        }

        public ResultadosValidación ValidarContraseña(string contraseña)
        {
            string ValidChar = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,50}$";

            if (Regex.IsMatch(contraseña, ValidChar))
            {

                return ResultadosValidación.ContraseñaValida;

            }

            return ResultadosValidación.ContraseñaInvalida;

        }


        public ResultadosValidación ValidarMatricula(string matricula)
        {
            string ValidChar = @"^[a-z][A-Z][0-9]+$"; ;
            if (Regex.IsMatch(matricula, ValidChar))
            {
                return ResultadosValidación.MatriculaValida;
            }
            return ResultadosValidación.MatriculaInvalida;
        }

        public ResultadosValidación ValidarNombres(string nombres)
        {
            string ValidChar = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\s).{3,35}$";
            if (Regex.IsMatch(nombres, ValidChar))
            {
                return ResultadosValidación.NombresValidos;
            }
            return ResultadosValidación.NombresInvalidos;
        }

        public ResultadosValidación ValidarNúmero(string númeroInt)
        {
            string patrón = @"^[0-9]*$";
            if (Regex.IsMatch(númeroInt, patrón))
            {
                return ResultadosValidación.NúmeroVálido;
            }
            return ResultadosValidación.NúmeroInválido;
        }

        public ResultadosValidación ValidarRFC(string rfc)
        {
            string patrón = @"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$";
            if (Regex.IsMatch(rfc, patrón))
            {
                return ResultadosValidación.RfcVálido;
            }
            return ResultadosValidación.RfcInválido;
        }



        public ResultadosValidación ValidarUsuario(string usuario)
        {
            string ValidChar = @"^[0-9](?=.*[a-z])(?=.*[A-Z])(?=.*\s).{3,35}$";
            if (Regex.IsMatch(usuario, ValidChar))
            {
                return ResultadosValidación.UsuarioValido;
            }
            return ResultadosValidación.UsuarioInvalido;





        }
    }
}