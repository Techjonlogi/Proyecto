
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
            Administrador loginAdministrador = new Administrador();
            MessageBox.Show("Logueado Correctamente");
            
            this.Close();
        }

        private void btn_ClickAqui_Click(object sender, RoutedEventArgs e)
        {
             RegistrarPracticante reg = new RegistrarPracticante();
            reg.Show();
            this.Close();
        }
    }
}
