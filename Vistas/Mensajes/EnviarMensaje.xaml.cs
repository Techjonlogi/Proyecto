using Sistema_de_Prácticas_Profesionales.Pojos.Mensaje;
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
using Sistema_de_Prácticas_Profesionales.Controller;

namespace Sistema_de_Prácticas_Profesionales.Vistas.Mensajes
{
    /// <summary>
    /// Lógica de interacción para EnviarMensaje.xaml
    /// </summary>
    public partial class EnviarMensaje : Window
    {
        public EnviarMensaje()
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
            if (textBoxEmisor.Text== String.Empty || textBoxReceptor.Text == String.Empty || textBoxMensaje.Text == String.Empty)
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
            else if (validarCampos.ValidarMatricula(textBoxEmisor.Text) == Logica.CheckFields.ResultadosValidación.MatriculaInvalida || validarCampos.ValidarNumeropersonal(textBoxEmisor.Text)==Logica.CheckFields.ResultadosValidación.NúmeroInválido) 
            { 
                MessageBox.Show("Numero o Matricula invalida, porfavor ingrese algo valido");
            }
            else if (validarCampos.ValidarMatricula(textBoxReceptor.Text) == Logica.CheckFields.ResultadosValidación.MatriculaInvalida || validarCampos.ValidarNumeropersonal(textBoxReceptor.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("Numero o Matricula invalida, porfavor ingrese algo valido");
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
                MessageBox.Show("Enviado Correctamente");
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
            
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields() == ChecResults.Passed)
            {
                MensajeController controller = new MensajeController();
                ComprobarResultado((OperationResult)controller.AddMensaje(textBoxReceptor.Text, textBoxEmisor.Text, textBoxMensaje.Text));
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
