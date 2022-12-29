using Calculator.Model;
using Calculator.Model.Operations;
using Calculator.ViewModel;
using Calculator.ViewModel.Services;
using Calculator.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new();
        MainWindowViewModel mainViewModel;
        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<AdvancedWindowViewModel, AdvancedWindow>();
            displayRootRegistry.RegisterWindowType<MiniWindowViewModel, MiniWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainViewModel = new MainWindowViewModel();

            displayRootRegistry.ShowPresentation(mainViewModel);
        }
    }
}
