using Sistema_de_Prácticas_Profesionales.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Sistema_de_Prácticas_Profesionales.Logica.CheckFields;


namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarProfesor.xaml
    /// </summary>
    public partial class RegistrarProfesor : Window
    {
        public RegistrarProfesor()
        {
            InitializeComponent();
        }

        private enum CheckResults {
        Passed,Failed
        
        }

        public enum OperationResult
        {
            Success,
            NullOrganization,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }

        private CheckResults CheckEmptyFields() {
            CheckResults chec = CheckResults.Failed;
            if (btnNdePersonal.Text == String.Empty || btnNombre.Text == String.Empty || btnApellidoPaterno.Text == String.Empty || btnApellidoMaterno.Text == String.Empty || btnCorreo.Text == String.Empty || btnUsuario.Text == String.Empty || passwordProfesor.Password == String.Empty || repiteContraseñaProfesor.Password == String.Empty)
            {
                chec = CheckResults.Failed;
            }
            else
            {
                chec = CheckResults.Passed;
            }
            return chec;
        
        }

        private CheckResults CheckFields()
        {
            CheckResults check = CheckResults.Failed;
            Logica.CheckFields validarCampos = new Logica.CheckFields();
            if (CheckEmptyFields() == CheckResults.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = CheckResults.Failed;
            }
            else if (validarCampos.ValidarNúmero(btnNdePersonal.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("numero de Personal invalido");
                check = CheckResults.Failed;
            }
            else if (validarCampos.ValidarContraseña(passwordProfesor.Password) == Logica.CheckFields.ResultadosValidación.ContraseñaInvalida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
                check = CheckResults.Failed;
            }
            else if (validarCampos.ValidarUsuario(btnUsuario.Text) == Logica.CheckFields.ResultadosValidación.UsuarioInvalido)
            {
                MessageBox.Show("El usuario ingresado no es valido");
                check = CheckResults.Failed;


            }
            else if (validarCampos.ValidarCorreo(btnCorreo.Text) == Logica.CheckFields.ResultadosValidación.Correoinválido) {
                MessageBox.Show("correo no valido, por favbor ingrese un correo valido");
                check = CheckResults.Failed;
            }
            else
            {
                check = CheckResults.Passed;
            }
            return check;
        }

        /// <summary>Comprueba el resultado de la operacion.</summary>
        /// <param name="result">El resultado.</param>
        private void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("Añadido con exito");
                this.Close();
            }
            else if (result == OperationResult.UnknowFail)
            {
                MessageBox.Show("Error desconocido");
            }
            else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }
            else if (result == OperationResult.ExistingRecord)
            {
                MessageBox.Show("El alumno ya existe en el sistema");
            }
        }


        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            DateTime Fecha = DateTime.Today;
            if (passwordProfesor.Password == repiteContraseñaProfesor.Password)
            {
                if (CheckFields() == CheckResults.Passed)
                {
                    ProfesorController profesorcontroller = new ProfesorController();
                    ComprobarResultado((OperationResult)profesorcontroller.AñadirCoordinador(btnNdePersonal.Text,textBoxDias.Text, btnNombre.Text, btnApellidoPaterno.Text, btnApellidoMaterno.Text, btnUsuario.Text, passwordProfesor.Password, Fecha.ToString(),Fecha.ToString(), btnCorreo.Text));
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                passwordProfesor.Password = String.Empty;
                repiteContraseñaProfesor.Password = String.Empty;
            }




        }



        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
