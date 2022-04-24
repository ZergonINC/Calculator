using Calculator2.Model;
using Calculator2.Model.Operations;
using Calculator2.ViewModel;
using Calculator2.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            BaseCalculatorModel baseCalculatorModel = new();
            MainViewModel mainViewModel = new(baseCalculatorModel);
            
            MainWindow window = new();
            window.DataContext = mainViewModel;

            window.Show();
        }
    }
}
