﻿using Prestamo_con_Detalla.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prestamo_con_Detalla
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                rMoras rMoras = new rMoras();
                rMoras.Show();
            }
        }

        private void Button_Clickitem(object sender, RoutedEventArgs e)
        {
            rPrestamo rPrestamos = new rPrestamo();
            rPrestamos.Show();
        }
    }
}
    