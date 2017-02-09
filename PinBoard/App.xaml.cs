using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PinBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        PinBoardMainWindow mainWindow;
        protected override void OnStartup(StartupEventArgs e)
        {
            mainWindow = new PinBoardMainWindow();
            mainWindow.Show();
            mainWindow.Activate();
        } 
    }
}
