using Prestamo_con_Detalla.BLL;
using Prestamo_con_Detalla.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prestamo_con_Detalla.UI
{
    /// <summary>
    /// Interaction logic for rPrestamo.xaml
    /// </summary>
    public partial class rPrestamo : Window
    {
        
            
        private Prestamos prestamos = new Prestamos();
        public rPrestamo()
        {
            InitializeComponent();
            //Constructor
            this.DataContext = prestamos;
        }
        //---[ CARGAR - Registro Detallado ]---
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = prestamos;
        }
        //---[ LIMPIAR ]---
        private void Limpiar()
        {
            this.prestamos = new Prestamos();
            this.DataContext = prestamos;
        }
        //---[ Validar ]---
        private bool Validar()
        {
            if (NombreTextbox.Text.Trim() == String.Empty)
            {
                MessageBox.Show("El Campo (Nombre) esta vacio.\n\nDescriba el articulo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextbox.Focus();
            }

            bool Validado = true;
            if (PrestamoIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Validado;

        }
        //---[ BUSCAR ]---
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           
            Prestamos encontrado = PrestamosBLL.Buscar(prestamos.PrestamoId);

            if (encontrado != null)
            {
                prestamos = encontrado;
                Cargar();
                MessageBox.Show("Articulo Encontrado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Esta Id de Articulo no fue encontrada.\n\nAsegurese que existe o cree una nueva.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
        }
        //---[ NUEVO ]---
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //---[ GUARDAR ]---
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = PrestamosBLL.Guardar(prestamos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //---[ ELIMINAR ]---
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PrestamosBLL.Eliminar(Utilidades.ToInt(PrestamoIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}