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

namespace Sistema_de_Prácticas_Profesionales.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para AdministrarCoordinadores.xaml
    /// </summary>
    public partial class AdministrarCoordinadores : Window
    {
        public AdministrarCoordinadores()
        {
            InitializeComponent();
        }





        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCoordinador RC = new RegistrarCoordinador();
            RC.Show();
            this.Close();
        }

       









    }
}
