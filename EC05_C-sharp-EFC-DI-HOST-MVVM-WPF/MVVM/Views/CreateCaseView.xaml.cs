﻿using System;
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

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for CreateCaseView.xaml
    /// </summary>
    public partial class CreateCaseView : UserControl
    {
        public CreateCaseView()
        {
            InitializeComponent();

        }

        private void tb_Description_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_Description.Text = string.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
