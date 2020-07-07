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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MensajeController controller = new MensajeController();
        }
    }
}
