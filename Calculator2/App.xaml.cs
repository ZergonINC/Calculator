﻿using Calculator2.Model;
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
