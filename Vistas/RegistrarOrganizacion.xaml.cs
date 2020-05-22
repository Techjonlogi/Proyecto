using Sistema_de_Prácticas_Profesionales.Logica;
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
using static Sistema_de_Prácticas_Profesionales.Logica.CheckFields;
using Sistema_de_Prácticas_Profesionales.Controller;

namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarOrganizacion.xaml
    /// </summary>
    public partial class RegistrarOrganizacion : Window
    {
        public RegistrarOrganizacion()
        {
            InitializeComponent();
        }
        private enum CheckResults {
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

        private CheckResults CheckEmptyFields() {
            CheckResults chec = CheckResults.Failed;
            if(textBoxRFC.Text == String.Empty || textBoxNombre.Text == String.Empty || comboSector.Text==String.Empty || textboxUsuarioDirecto.Text==String.Empty || textBoxUsuarioIndirecto.Text == String.Empty || textBoxTelefono.Text == String.Empty || textBoxEstado.Text== String.Empty||textBoxCiudad.Text == String.Empty|| textBoxDireccion.Text == String .Empty)
            {
                chec= CheckResults.Failed;
            }
            else
            {
                chec = CheckResults.Passed;
            }


            return chec;
        }

        private CheckResults ValidarCampos() {
            CheckResults check = CheckResults.Failed;
            CheckFields checfields = new CheckFields();
            if (CheckEmptyFields() == CheckResults.Failed)
            {
                MessageBox.Show("Existen Campos sin llenar");
                check = CheckResults.Failed;

            }
            else if (checfields.ValidarRFC(textBoxRFC.Text) == CheckFields.ResultadosValidación.RfcInvalido)
            {
                MessageBox.Show("RFC ingresado es inválido");
                check = CheckResults.Failed;

            }
            else if (checfields.ValidarNúmero(textBoxTelefono.Text) == CheckFields.ResultadosValidación.NúmeroInválido) {
                MessageBox.Show("el numero de telefono que ingresó no es valido");
                check = CheckResults.Failed;
            }
            else if (checfields.ValidarCorreo(textBoxCorreo.Text) == CheckFields.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("El correo ingresado no es valido");
                check = CheckResults.Failed;
            }
            else
            {
                check = CheckResults.Passed;
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
                MessageBox.Show("El registro ya existe en el sistema");
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos() == CheckResults.Passed)
            {
                OrganizacionVinculadaController organizacionController = new OrganizacionVinculadaController();
                ComprobarResultado((OperationResult)organizacionController.AddOrganizacion(textBoxRFC.Text, textBoxNombre.Text, textBoxDireccion.Text, comboSector.Text, textBoxTelefono.Text, textBoxCorreo.Text,textboxUsuarioDirecto.Text,textBoxUsuarioIndirecto.Text,textBoxEstado.Text,textBoxCiudad.Text));
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
