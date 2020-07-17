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
using System.Diagnostics;
using Microsoft.Win32;
using Sistema_de_Prácticas_Profesionales.Controller;

namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarPlanActividades.xaml
    /// </summary>
    public partial class RegistrarPlanActividades : Window
    {
        public RegistrarPlanActividades()
        {
            InitializeComponent();
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
                MessageBox.Show("El registro ya existe en el sistema");
            }
        }






        private void btnSeleccionarArchivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.ShowDialog();
            textBoxRuta.Text = dialogo.FileName;
        }

        private void btnSubirArchivo_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxRuta.Text == String.Empty)
            {

                MessageBox.Show("Debe Seleccionar un archivo primero");



            }
            else
            {
                DocumentoController controller = new DocumentoController();
                ComprobarResultado((OperationResult)controller.AddDocumento(textBoxRuta.Text));

            }
        }
    }
}
