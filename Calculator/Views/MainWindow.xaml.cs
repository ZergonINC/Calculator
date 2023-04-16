using Calculator.Model;
using Calculator.ViewModel;
using log4net;
using System.Windows;

namespace Calculator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ILog log = LogManager.GetLogger(typeof(MainWindow));
        public MainWindow()
        {
            log.Info("MainWindow - загрузка InitializeComponent()");
            InitializeComponent();
        }
    }
}
