using Formación_de_Profesionales_en_Accesibilidad;
using Sistema_de_Prácticas_Profesionales.Vistas.Mensajes;
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
    /// Lógica de interacción para MainUsuario.xaml
    /// </summary>
    public partial class MainUsuario : Window
    {
        public MainUsuario()
        {
            InitializeComponent();
        }

        private void btnBuzón_Click(object sender, RoutedEventArgs e)
        {
            VerMensajes vermensajes = new VerMensajes();
            vermensajes.ShowDialog();
        }

        private void btnMensaje_Click(object sender, RoutedEventArgs e)
        {
            EnviarMensaje enviarmensjae = new EnviarMensaje();
            enviarmensjae.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }
}
