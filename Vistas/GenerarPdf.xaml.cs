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
using Sistema_de_Prácticas_Profesionales.Pojos;
using Sistema_de_Prácticas_Profesionales.Controller;
using Sistema_de_Prácticas_Profesionales.Pojos.Coordinador;
using Controller;
using Sistema_de_Prácticas_Profesionales.Pojos.Proyecto;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using Microsoft.Win32;
using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;



namespace Sistema_de_Prácticas_Profesionales.Vistas
{
   
    public partial class GenerarPdf : Window
    {
        public GenerarPdf()
        {
            InitializeComponent();
            UpdateGrid();

        }








        private enum ChecResults
        {
            Passed, Failed
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

        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (textBoxActividad.Text == String.Empty || textBoxDescripcion.Text == String.Empty)
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
            

            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }






        private void UpdateGrid()
        {
            ControladorProyecto controller = new ControladorProyecto();
            datagridProyecto.ItemsSource = null;
            if (controller.ObtenerProyectos().Any())
            {
                datagridProyecto.ItemsSource = controller.ObtenerProyectos();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }

        private void generarpdf_Click(object sender, RoutedEventArgs e)
        {
            

                if (datagridProyecto.SelectedIndex > -1)
                {
                if (CheckFields() == ChecResults.Passed)
                {
                    String nombreActividad = textBoxActividad.Text;
                    String descripcionActividad = textBoxDescripcion.Text;
                    String id;
                    ProfesorController controller = new ProfesorController();
                    id = ((Proyecto)datagridProyecto.SelectedValue).IdProyecto;

                    GenerarArchivo(id, nombreActividad, descripcionActividad);
                }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un celda valida para generar el archivo");
                }

            
        }
             
            
        




        private void GenerarArchivo(String id,String nombreActividad, String descripcionActividad) 
        {


            ControladorProyecto controller = new ControladorProyecto();
            Proyecto proyecto = new Proyecto();
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".Pdf";
            dialog.Filter = "PDF Documents (.pdf)|*.pdf";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {


                

                String filename = dialog.FileName;


                proyecto = controller.getProyecto(id);
                PdfWriter pw = new PdfWriter(filename);
                PdfDocument pdfDocument = new PdfDocument(pw);
                Document doc = new Document(pdfDocument, PageSize.A4);
                doc.SetMargins(75, 35, 70, 35);
                doc.Add(new iText.Layout.Element.Paragraph("identificador del proyecto: "+proyecto.IdProyecto.ToString()));
                doc.Add(new iText.Layout.Element.Paragraph("Nombre del proyecto: "+proyecto.NombreProyecto.ToString()));
                doc.Add(new iText.Layout.Element.Paragraph("Descripcion del proyecto: "+proyecto.Descripcion.ToString()));
                doc.Add(new iText.Layout.Element.Paragraph("Nombre nueva Actividad: "+nombreActividad));
                doc.Add(new iText.Layout.Element.Paragraph("Descripcion de la actividad: "+descripcionActividad));

                doc.Close();

            }


            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
