﻿using P2_AP1_Nachely_20190734.BLL;
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
        public rProyectos()
        {
            InitializeComponent();

            TipoTareaComboBox.ItemsSource = TiposTareasBLL.GetTiposTareas();
            TipoTareaComboBox.SelectedValuePath = "TipoTareaId";
            TipoTareaComboBox.DisplayMemberPath = "DescripcionTipoTarea";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
