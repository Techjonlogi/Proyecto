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
using Sistema_de_Prácticas_Profesionales.Pojos.Profesor;

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
            UpdateGrid();
        }
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

       

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarProfesor RP = new RegistrarProfesor();
            RP.Show();
            this.Close();
        }


        private void UpdateGrid()
        {
            ProfesorController controller = new ProfesorController();
            dataProfesores.ItemsSource = null;
            if (controller.GetProfesor().Any())
            {
                dataProfesores.ItemsSource = controller.GetProfesor();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");



            }
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (dataProfesores.SelectedValue.ToString() != String.Empty)
            {
                ProfesorController controller = new ProfesorController();
                ComprobarResultado((OperationResult)controller.DeleteProfesor(((Profesor)dataProfesores.SelectedValue).IdProfesor));
                UpdateGrid();
            }
            else MessageBox.Show("Debe seleccionar un celda valida para eliminar");
        }
    }
}
