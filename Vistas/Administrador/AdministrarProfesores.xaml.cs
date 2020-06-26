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
    /// Lógica de interacción para AdministrarProfesores.xaml
    /// </summary>
    public partial class AdministrarProfesores : Window
    {
        public AdministrarProfesores()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarProfesor RP = new RegistrarProfesor();
            RP.Show();
            this.Close();
        }
    }
}
