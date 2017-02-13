﻿using PinBoard.ViewModels;
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

namespace PinBoard.Views
{
    /// <summary>
    /// Interaction logic for SideBarView.xaml
    /// </summary>
    public partial class SideBarView : UserControl
    {
        public SideBarView()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SideBarViewModel vm = DataContext as SideBarViewModel;

            if (vm != null)
            {
                vm.OnEditClick.Execute(null);
            }
        }
    }
}
