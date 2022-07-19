using Calculator2.ViewModel.Services;
using Calculator2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator2.ViewModel
{
    internal class MainWindowVeiwModel : BaseViewModel
    {
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged(nameof(CurrentPage));
            }
        }


        AdvancedPage advancedPage;

        MainPage mainPage;

        public MainWindowVeiwModel()
        {
            mainPage = new();

            CurrentPage = mainPage;
        }

        #region Menu commands

        public ICommand ExpressionsCalculatorCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    advancedPage = new();

                    CurrentPage = advancedPage;
                });
            }
        }

        public ICommand MainCalculatorCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    CurrentPage = mainPage;
                });
            }
        }
        #endregion
    }
}
