﻿using log4net;
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

namespace Calculator.Views
{
    /// <summary>
    /// Логика взаимодействия для ExpressionWindow.xaml
    /// </summary>
    public partial class AdvancedWindow : Window
    {
        ILog log = LogManager.GetLogger(typeof(MainWindow));
        public AdvancedWindow()
        {
            log.Info("AdvancedWindow - загрузка InitializeComponent()");
            InitializeComponent();
        }
    }
}
