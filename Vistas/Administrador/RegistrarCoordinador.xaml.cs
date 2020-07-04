using Sistema_de_Prácticas_Profesionales.Controller;
using System;
using System.Collections.Generic;
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

namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarCoordinador.xaml
    /// </summary>
    public partial class RegistrarCoordinador : Window
    {
        public RegistrarCoordinador()
        {
            InitializeComponent();
        }

        private enum ChecResults
        {
            Passed, Failed
        }

        public enum OperationResult
        {
            Success,
            NullCoordinador,
            InvaliCoordinador,
            UnknowFail,
            SQLFail,
            ExistingRecord

        }

        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (textboxNoPersonal.Text == String.Empty || textboxNombre.Text == String.Empty || textboxAPaterno.Text == String.Empty || CoordinadorPassword.Password == String.Empty || textboxAMaterno.Text == String.Empty || textboxAMaterno.Text == String.Empty || textboxCubiculo.Text == String.Empty || CoordinadorPasswordRepite.Password == String.Empty)
            {
                check = ChecResults.Failed;
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }

        private ChecResults CheckFields()
        {
            ChecResults check = ChecResults.Failed;
            Logica.CheckFields validarCampos = new Logica.CheckFields();
            if (CheckEmptyFields() == ChecResults.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = ChecResults.Failed;
            }
            else if (validarCampos.ValidarNumeropersonal(textboxNoPersonal.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("Numero de personal incorrecto");
            }
            else if (validarCampos.ValidarContraseña(CoordinadorPassword.Password) == Logica.CheckFields.ResultadosValidación.ContraseñaInvalida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }

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
                MessageBox.Show("El Coordiandor ya existe en el sistema");
            }
        }

        private void buttonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (CoordinadorPassword.Password == CoordinadorPasswordRepite.Password)
            {
                if (CheckFields() == ChecResults.Passed)
                {
                    CoordinadorController coordiandorcontroller = new CoordinadorController();
                    DateTime fecharegistro =DateTime.Today;
                    ComprobarResultado((OperationResult)coordiandorcontroller.AddCoordinador(textboxNoPersonal.Text, textboxNombre.Text, textboxAPaterno.Text, textboxAMaterno.Text, textboxusuario.Text, CoordinadorPassword.Password, textboxCubiculo.Text,null,fecharegistro.ToString("d")));
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                CoordinadorPassword.Password = String.Empty;
                CoordinadorPasswordRepite.Password = String.Empty;
            }



        }
    }
}
