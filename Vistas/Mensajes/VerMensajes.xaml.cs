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
    /// Lógica de interacción para VerMensajes.xaml
    /// </summary>
    public partial class VerMensajes : Window
    {
        public VerMensajes()
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
            if (textBoxid.Text == String.Empty)
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
            else if (validarCampos.ValidarMatricula(textBoxid.Text) == Logica.CheckFields.ResultadosValidación.MatriculaValida || validarCampos.ValidarNumeropersonal(textBoxid.Text) == Logica.CheckFields.ResultadosValidación.NúmeroVálido)
            {
                check = ChecResults.Passed;
                
            }
            
            else
            {
                MessageBox.Show("Numero o Matricula invalida, porfavor ingrese algo valido");
            }
            return check;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields() == ChecResults.Passed)
            {
                UpdateGrid(textBoxid.Text);
            }
        }

        private void UpdateGrid(String id)
        {
            MensajeController Controller = new MensajeController();
            dataMensajes.ItemsSource = null;
            if (Controller.GetMensajes(id).Any())
            {
                dataMensajes.ItemsSource = Controller.GetMensajes(id);
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }
    }
}
