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
using Sistema_de_Prácticas_Profesionales.Pojos.OrganizacionVinculada;
using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;

namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarProyecto.xaml
    /// </summary>
    public partial class RegistrarProyecto : Window
    {
        public RegistrarProyecto()
        {
            InitializeComponent();
            LlenarOrganizaciones();
            LlenarCoordinadores():


        }

        public void LlenarOrganizaciones()
        {
            OrganizacionVinculadaController controladorOrganización = new OrganizacionVinculadaController();
            List<OrganizacionVinculada> organizaciones = controladorOrganización.GetOrganizacion();
            if (!organizaciones.Any())
            {
                MessageBox.Show("No se encontraron organizaciones");
            }
            else
            {
                comboOrganizaciones.ItemsSource = organizaciones;
            }

        }

        public void LlenarCoordinadores()
        {
            CoordinadorController cordinadorController = new CoordinadorController();
            List<Coordinador> cordinadores = cordinadorController.GetCoordinador();
            if (!cordinadores.Any())
            {
                MessageBox.Show("No se encontraron organizaciones");
            }
            else
            {
                comboCordinador.ItemsSource = cordinadores;
            }

        }



    }
}
