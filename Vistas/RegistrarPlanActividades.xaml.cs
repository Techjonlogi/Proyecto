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

        private void btnSeleccionarArchivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.ShowDialog();
            txtBoxRuta.Text = dialogo.FileName;
        }
    }
}
