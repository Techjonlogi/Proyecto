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
using static Sistema_de_Prácticas_Profesionales.DAO.ProfesorDAO;
using Sistema_de_Prácticas_Profesionales.Controller;
using static Sistema_de_Prácticas_Profesionales.Logica.CheckFields;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Pojos.Profesor;

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
            if (textboxnoPersonal.Text == String.Empty || textBoxnombres.Text == String.Empty || textBoxAPaterno.Text == String.Empty || textBoxAMaterno.Text == String.Empty || textBoxCorreo.Text == String.Empty || textBoxusuario.Text == String.Empty || passwordProfesor.Password == String.Empty || repitePasswordProfesor.Password == String.Empty)
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
            else if (validarCampos.ValidarNumeropersonal(textboxnoPersonal.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("numero de personal incorrecto");
            }
            else if (validarCampos.ValidarContraseña(passwordProfesor.Password) == Logica.CheckFields.ResultadosValidación.ContraseñaInvalida)
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
                MessageBox.Show("El profesor ya existe en el sistema");
            }
        }

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            if (passwordProfesor.Password == repitePasswordProfesor.Password)
            {
                if (CheckFields() == ChecResults.Passed)
                {

                    CoordinadorController coordiandorcontroller = new CoordinadorController();
                    DateTime fecharegistro = DateTime.Today;
                    ProfesorController profesorcontroller = new ProfesorController();
                    ComprobarResultado((OperationResult)profesorcontroller.AñadirProfesor(textboxnoPersonal.Text, textBoxnombres.Text, textBoxAPaterno.Text, textBoxAMaterno.Text, textBoxusuario.Text,passwordProfesor.Password,fecharegistro.ToString(), fecharegistro.ToString(), comboturno.Text,textBoxCorreo.Text));
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                passwordProfesor.Password = String.Empty;
                repitePasswordProfesor.Password = String.Empty;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}








