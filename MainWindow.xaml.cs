using Formación_de_Profesionales_en_Accesibilidad.Ventanas;
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

namespace Formación_de_Profesionales_en_Accesibilidad
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            LoginAdministrador loginAdministrador = new LoginAdministrador();
            MessageBox.Show("Logueado Correctamente");
            loginAdministrador.Show();
            this.Close();
        }

        private void btn_ClickAqui_Click(object sender, RoutedEventArgs e)
        {
            RegistrarseATaller reg = new RegistrarseATaller();
            reg.Show();
            this.Close();
        }
    }
}
