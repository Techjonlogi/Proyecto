﻿using Formación_de_Profesionales_en_Accesibilidad;
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

namespace Sistema_de_Prácticas_Profesionales.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainAdministrador.xaml
    /// </summary>
    public partial class MainAdministrador : Window
    {
        public MainAdministrador()
        {
            InitializeComponent();
        }

       

       

        private void buttonAdministrarProfesores_Click(object sender, RoutedEventArgs e)
        {
            AdministrarProfesores administrarprofesores = new AdministrarProfesores();
            administrarprofesores.ShowDialog();
        }

        private void buttonAdministrarCoordinadores_Click_1(object sender, RoutedEventArgs e)
        {
            AdministrarCoordinadores administrarcoordinadores = new AdministrarCoordinadores();
            administrarcoordinadores.ShowDialog();
        }

        private void buttonSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
