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

using Controller;

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
            LlenarCoordinadores();


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


        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (textBoxClaveProyecto.Text == String.Empty || textBoxNombreProyecto.Text == String.Empty || comboOrganizaciones.Text == String.Empty || comboCordinador.Text == String.Empty || textBoxDuracion.Text == String.Empty || textBoxObjetivoGeneral.Text == String.Empty || textBoxDescripcion.Text == String.Empty || textBoxObjetivoMediato.Text == String.Empty || textBoxActividad.Text==String.Empty || textBoxMetodologia.Text==String.Empty || textBoxresponsabilidades.Text == String.Empty || textBoxCargoEncargado.Text== String.Empty || textBoxEmailEncargado.Text == String.Empty || textBoxNombreyapellidosResponsable.Text == String.Empty || textBoxRecursos.Text == String.Empty )
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
            else if (validarCampos.ValidarMatricula(textBoxEmailEncargado.Text) == Logica.CheckFields.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("Formato de matricula incorrecto");
            }
            
            else
            {
                check = ChecResults.Passed;
            }
            return check;
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
                MessageBox.Show("Este Proyecto ya Existe");
            }
        }











        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields() == ChecResults.Passed)
            {
                ControladorProyecto proyectocontroller = new ControladorProyecto();
                ComprobarResultado((OperationResult)proyectocontroller.AddProyecto(textBoxClaveProyecto.Text,textBoxresponsabilidades.Text,textBoxNombreProyecto.Text, textBoxDuracion.Text,textBoxDescripcion.Text,textBoxObjetivoGeneral.Text, textBoxObjetivoMediato.Text,textBoxCargoEncargado.Text,textBoxEmailEncargado.Text,textBoxNombreyapellidosResponsable.Text,textBoxMetodologia.Text,textBoxRecursos.Text,comboCordinador.Text, textBoxActividad.Text));
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
