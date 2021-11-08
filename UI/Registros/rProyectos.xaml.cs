using P2_AP1_Nachely_20190734.BLL;
using P2_AP1_Nachely_20190734.Entidades;
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

namespace P2_AP1_Nachely_20190734.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos proyecto = new Proyectos();
        private ProyectosDetalle detalles = new ProyectosDetalle();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyecto;

            TipoTareaComboBox.ItemsSource = TiposTareasBLL.GetTiposTareas();
            TipoTareaComboBox.SelectedValuePath = "TipoTareaId";
            TipoTareaComboBox.DisplayMemberPath = "DescripcionTipoTarea";

            TotalTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }
        private void Limpiar()
        {
            this.proyecto = new Proyectos();
            this.DataContext = proyecto;
        }

        private bool ExisteEnLaBD()
        {
            Proyectos esValido = ProyectosBLL.Buscar(proyecto.ProyectoId);
            return (esValido != null);
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(proyecto.ProyectoId);

            if (encontrado != null)
            {
                proyecto = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("El proyecto no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            proyecto.Detalle.Add(new ProyectosDetalle(Utilidades.ToInt(ProyectoIdTextBox.Text), (int)TipoTareaComboBox.SelectedValue,
                RequerimientoTextBox.Text, Utilidades.ToInt(TiempoTextBox.Text), (TiposTareas)TipoTareaComboBox.SelectedItem, proyecto));

            TotalTextBox.Text = proyecto.Total.ToString();

            Cargar();
            
            TotalTextBox.Focus();
            TotalTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                proyecto.Total -= Utilidades.ToInt(TotalTextBox.Text);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (proyecto.ProyectoId == 0)
            {
                paso = ProyectosBLL.Guardar(proyecto);
            }
            else
            {
                if (ExisteEnLaBD())
                {
                    paso = ProyectosBLL.Guardar(proyecto);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡Fallo al guardar!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
