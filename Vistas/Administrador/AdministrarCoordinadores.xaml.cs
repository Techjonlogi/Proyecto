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
using Sistema_de_Prácticas_Profesionales.DAO;
using static Sistema_de_Prácticas_Profesionales.Controller.CoordinadorController;
using Sistema_de_Prácticas_Profesionales.Pojos;
using Sistema_de_Prácticas_Profesionales.Controller;
using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;

namespace Sistema_de_Prácticas_Profesionales.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para AdministrarCoordinadores.xaml
    /// </summary>
    public partial class AdministrarCoordinadores : Window



    {

        public enum OperationResult
        {
            Success,
            NullCoordinador,
            InvaliCoordinador,
            UnknowFail,
            SQLFail,
            ExistingRecord

        }

        private void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("eliminado con exito");
                this.Close();
            }
            else if (result == OperationResult.UnknowFail)
            {
                MessageBox.Show("Error desconocido, no se puedo eliminar");
            }
            else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }
          
        }


        public AdministrarCoordinadores()
        {
            InitializeComponent();
            UpdateGrid();
        }





        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (datagridCoordinadores.SelectedIndex > -1)
            {
                CoordinadorController controller = new CoordinadorController();
                ComprobarResultado((OperationResult)controller.DeleteCoordinador(((Coordinador)datagridCoordinadores.SelectedValue).NoPersonal));
                UpdateGrid();
            }
            else MessageBox.Show("Debe seleccionar un celda valida para eliminar");
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCoordinador RC = new RegistrarCoordinador();
            RC.ShowDialog();
            this.Close();
        }

        private void UpdateGrid()
        {
            CoordinadorController coordiandorController = new CoordinadorController();
            datagridCoordinadores.ItemsSource = null;
            if (coordiandorController.GetCoordinador().Any())
            {
                datagridCoordinadores.ItemsSource = coordiandorController.GetCoordinador();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }









    }
}
