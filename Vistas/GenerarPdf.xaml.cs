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
            GenerarArchivo();
        }

        private void GenerarArchivo(/*Proyecto proyecto,String nombreActividad, String actividad*/) 
        {

            if (datagridProyecto.SelectedValue.ToString() != String.Empty)
            {
                String id;
                ProfesorController controller = new ProfesorController();
                id=((Proyecto)datagridProyecto.SelectedValue).IdProyecto;
                UpdateGrid();
            }
            else { MessageBox.Show("Debe seleccionar un celda valida para eliminar"); }

            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".Pdf";
            dialog.Filter = "PDF Documents (.pdf)|*.pdf";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                String filename = dialog.FileName;



                PdfWriter pw = new PdfWriter(filename);
                PdfDocument pdfDocument = new PdfDocument(pw);
                Document doc = new Document(pdfDocument, PageSize.A4);
                doc.SetMargins(75, 35, 70, 35);
                doc.Add(new iText.Layout.Element.Paragraph("hola"));

                doc.Close();

            }



        }

        
    }
}
