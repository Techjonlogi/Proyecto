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

namespace Sistema_de_Prácticas_Profesionales.Vistas
{
    /// <summary>
    /// Lógica de interacción para GenerarPdf.xaml
    /// </summary>
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
            PdfWriter pw = new PdfWriter("C:\\demo.pdf");
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);
            doc.SetMargins(75, 35, 70, 35);
            doc.Add(new iText.Layout.Element.Paragraph("hola"));
            
            doc.Close();

          
            

        }

        
    }
}
