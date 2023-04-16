using Calculator.Model;
using Calculator.Model.Operations;
using Calculator.ViewModel;
using Calculator.ViewModel.Services;
using Calculator.Views;
using log4net;
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
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<AdvancedWindowViewModel, AdvancedWindow>();
            displayRootRegistry.RegisterWindowType<MiniWindowViewModel, MiniWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            mainViewModel = new MainWindowViewModel();
            displayRootRegistry.ShowPresentation(mainViewModel);
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("Приложение запущено");
            base.OnStartup(e);       
        }
    }
}
