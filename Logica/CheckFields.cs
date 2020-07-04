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

            NombreArtefactoValido,
            NombreArtefactoInvalido,

            NúmeroInválido,
            NúmeroVálido,

            RfcInvalido,
            RfcVálido,

            UsuarioValido,
            UsuarioInvalido,

            CorreoVálido,
            Correoinválido

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

        public ResultadosValidación ValidarNombreArtefacto(string nombre)
        {
            string ValidChar = @"^(?=.*[a-z])(?=.*[A-Z]).{3,35}$";
            if (Regex.IsMatch(nombre, ValidChar))
            {
                return ResultadosValidación.NombreArtefactoValido;
            }
            return ResultadosValidación.NombreArtefactoInvalido;
        }


        public ResultadosValidación ValidarNumeropersonal(string númeroInt)
        {
            string patrón = @"^[100-10000]*$";
            if (Regex.IsMatch(númeroInt, patrón))
            {
                return ResultadosValidación.NúmeroVálido;
            }
            return ResultadosValidación.NúmeroInválido;
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
            return ResultadosValidación.RfcInvalido;
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

        public ResultadosValidación ValidarCorreo(string correo)
        {
            string patrón = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (Regex.IsMatch(correo, patrón))
            {
                return ResultadosValidación.CorreoVálido;
            }
            return ResultadosValidación.Correoinválido;
        }
    }
}