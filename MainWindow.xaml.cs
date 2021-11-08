using P2_AP1_Nachely_20190734.UI.Consultas;
using P2_AP1_Nachely_20190734.UI.Registros;
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

namespace P2_AP1_Nachely_20190734
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

        private void cTiposTaresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTiposTareas tareas = new cTiposTareas();
            tareas.Show();
        }

        private void rProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProyectos proyecto = new rProyectos();
            proyecto.Show();
        }

        private void cProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
