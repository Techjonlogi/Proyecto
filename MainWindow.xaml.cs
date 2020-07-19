
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sistema_de_Prácticas_Profesionales.Pojos.Administrador;
using Sistema_de_Prácticas_Profesionales.Controller;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Vistas;
using Sistema_de_Prácticas_Profesionales.Vistas.Administrador;
using Sistema_de_Prácticas_Profesionales.Vistas.Mensajes;
using Sistema_de_Prácticas_Profesionales.Pojos.Mensaje;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Logica;
using Sistema_de_Prácticas_Profesionales.Properties;


namespace Formación_de_Profesionales_en_Accesibilidad
  
{

    public partial class MainWindow : Window
    {
        public MainWindow()
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
            NullOrganization,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }

        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (textboxUsuario.Text == String.Empty || passwordboxccontraseña.Password == String.Empty)
            {
                check = ChecResults.Failed;
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }





        private ChecResults CheckField()
        {
            ChecResults check = ChecResults.Failed;
            CheckFields validarCampos = new CheckFields();
            if (CheckEmptyFields() == ChecResults.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = ChecResults.Failed;
            }

            else if (validarCampos.ValidarContraseña(passwordboxccontraseña.Password) == CheckFields.ResultadosValidación.ContraseñaInvalida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
            }
            else if (validarCampos.ValidaEspacios(textboxUsuario.Text) == CheckFields.ResultadosValidación.UsuarioInvalido)
            {
                MessageBox.Show("No puede haber espacios en blanco");
            }
            else {
                check = ChecResults.Passed;
            }
            return check;
        }




        private void btn_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (CheckField() == ChecResults.Passed)
            {
                UsuarioController controller = new UsuarioController();
                MessageBox.Show(controller.doLoging(textboxUsuario.Text, passwordboxccontraseña.Password).ToString());
                if (controller.doLoging(textboxUsuario.Text, passwordboxccontraseña.Password) == AddResult.Success) {

                    AbrirVentana();





                }
            }


        }


        private void AbrirVentana(){

            switch (Sistema_de_Prácticas_Profesionales.Properties.Settings.Default.tipoUsuario) {

                case ("Usuario"):
                    MainUsuario ventanausuario =  new MainUsuario();
                    ventanausuario.Show();
                    this.Close();

                    break;
                case ("Practicante"):
                    MainPracticante ventanaPracticante = new MainPracticante();
                    ventanaPracticante.Show();
                    this.Close();

                    break;

                case ("Administrador"):
                    MainAdministrador ventanaAdministrador = new MainAdministrador();
                    ventanaAdministrador.Show();
                    this.Close();

                    break;
            
            }
        
        
        }



       
    }
}
