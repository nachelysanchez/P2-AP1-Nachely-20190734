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

namespace P2_AP1_Nachely_20190734.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cTiposTareas.xaml
    /// </summary>
    public partial class cTiposTareas : Window
    {
        public cTiposTareas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var listado = new List<TiposTareas>();
            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Listado
                        listado = TiposTareasBLL.GetTiposTareas();
                        break;
                    case 1: //ID
                        listado = TiposTareasBLL.GetList(e => e.TipoTareaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2: //Descripcion
                        listado = TiposTareasBLL.GetList(e => e.DescripcionTipoTarea.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3://Tiempo Acumulado
                        listado = TiposTareasBLL.GetList(e => e.TiempoAcumulado == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = TiposTareasBLL.GetList(e => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
