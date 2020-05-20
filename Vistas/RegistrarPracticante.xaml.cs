//Realizado Jonathan de Jesus Moreno Martinez 
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
using static Sistema_de_Prácticas_Profesionales.DAO.PracticanteDAO;
using Sistema_de_Prácticas_Profesionales.Controller;
using static Sistema_de_Prácticas_Profesionales.Logica.CheckFields;


using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.Pojos.Practicante;

namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarPracticante.xaml
    /// </summary>
    public partial class RegistrarPracticante : Window
    {
        public RegistrarPracticante()
        {
            InitializeComponent();
        }

        private enum ChecResults {
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

        /// <summary>Checa los campos vacios.</summary>
        /// <returns>El resultado del chequeo</returns>
        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (textboxMatricula.Text == String.Empty || textboxNombre.Text == String.Empty || comboPeriodo.Text == String.Empty || alumnoPassword.Password == String.Empty|| textboxAPaterno.Text == String.Empty || textboxAMaterno.Text == String.Empty || ComboCarrera.Text == String.Empty || alumnoPasswordRepite.Password==String.Empty)
            {
                check = ChecResults.Failed;
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }

        /// <summary>Checa los campos en busqueda de datos no validos.</summary>
        /// <returns>El resultado del chequeo</returns>
        private ChecResults CheckFields()
        {
            ChecResults check = ChecResults.Failed;
            Logica.CheckFields validarCampos = new Logica.CheckFields();
            if (CheckEmptyFields() == ChecResults.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = ChecResults.Failed;
            }
            else if (validarCampos.ValidarMatricula(textboxMatricula.Text) == Logica.CheckFields.ResultadosValidación.MatriculaInvalida)
            {
                MessageBox.Show("Formato de matricula incorrecto");
            }
            else if (validarCampos.ValidarContraseña(alumnoPassword.Password) == Logica.CheckFields.ResultadosValidación.ContraseñaInvalida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }

        /// <summary>Comprueba el resultado de la operacion.</summary>
        /// <param name="result">El resultado.</param>
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
                MessageBox.Show("El alumno ya existe en el sistema");
            }
        }

       

        

        private void registrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (alumnoPassword.Password == alumnoPasswordRepite.Password)
            {
                if (CheckFields() == ChecResults.Passed)
                {
                    PracticanteController practicantecontroller = new PracticanteController();
                    ComprobarResultado((OperationResult)practicantecontroller.AddAlumno(textboxMatricula.Text, textboxNombre.Text,ComboCarrera.Text,alumnoPassword.Password, textboxAPaterno.Text,textboxAMaterno.Text,comboPeriodo.Text  ));
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                alumnoPassword.Password = String.Empty;
                alumnoPasswordRepite.Password = String.Empty;
            }
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboPeriodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
