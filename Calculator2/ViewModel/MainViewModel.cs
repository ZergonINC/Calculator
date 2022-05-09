using Calculator2.Model;
using Calculator2.Model.Executers;
using Calculator2.Model.Operations;
using Calculator2.Views;
using Calculator2.Views.DatePages;
using Calculator2.Views.Pages;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator2.ViewModel
{
    public class MainViewModel : BaseViewModel
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

        private string _display = "0";

        public string Display
        {
            get { return _display; }
            set
            {
                _display = value;
                RaisePropertyChanged(nameof(Display));
            }
        }

        private string _secondDisplay = string.Empty;

        public string SecondDisplay
        {
            get { return _secondDisplay; }
            set
            {
                _secondDisplay = value;
                RaisePropertyChanged(nameof(SecondDisplay));
            }
        }

        private string _temporary = String.Empty;

        public string Temporary
        {
            get { return _temporary; }
            set
            {
                _temporary = value;
                RaisePropertyChanged(nameof(Temporary));
            }
        }

        BaseCalculatorModel _calculator;

        CalculatingDatePage _calculatingDate;

        UnitConversionPage _unitConversion;

        ParameterizedOperationExecuting parameterized = new();

        OperationExecuting notparameterized = new();

        public MainViewModel()
        {
            this._calculator = new BaseCalculatorModel();

            this._calculatingDate = new CalculatingDatePage();
            this._unitConversion = new UnitConversionPage();
        }


        #region Base commands
        public ICommand NumberCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Display = String.Empty;

                    var number = parameter.ToString();

                    Temporary += number;

                    Temporary = NumberValidator.Check(Temporary) ?
                        NumberValidator.GetValidValue(Temporary) :
                        Temporary.Remove(Temporary.Length - 1); // валидировать в пердставлении

                    Display = Temporary;

                }, (parameter) => parameterized.SetOp(new Number(_calculator)).CanDo());
            }
        }

        public ICommand ArithmeticCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var sign = parameter.ToString();

                    parameterized.SetOp(new Number(_calculator)).Do(Display);

                    Temporary = String.Empty;

                    Display += " " + sign + " ";

                    SecondDisplay = Display;

                    parameterized.SetOp(new Sign(_calculator)).Do(sign);

                }, (parameter) => parameterized.SetOp(new Sign(_calculator)).CanDo());
            }
        }

        public ICommand EquallyCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    parameterized.SetOp(new Number(_calculator)).Do(Display);

                    Display = notparameterized.SetOp(new Equally(_calculator)).Do();

                    SecondDisplay = String.Empty;

                }, (parameter) => notparameterized.SetOp(new Equally(_calculator)).CanDo());
            }
        }
        #endregion
         
        #region Clear commands
        public ICommand ClearCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Display = notparameterized.SetOp(new Clear(_calculator)).Do();
                    
                    Temporary = String.Empty;
                    
                    SecondDisplay = String.Empty;
                });
            }
        }

        public ICommand CleanEntryCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Display = "0";
                    Temporary = String.Empty;
                });
            }
        }

        public ICommand BackspaceCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Display = Display.Remove(Display.Length - 1);
                    Temporary = Temporary.Remove(Temporary.Length - 1);
                    if (Display.Length == 0)
                        Display = "0";


                }, (parametr) => Display.Length > 0 && Temporary.Length > 0);
            }
        }
        #endregion

        #region Memory commands
        public ICommand MemoryClearCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }

        public ICommand MemoryReadCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }

        public ICommand MemorySaveCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }

        public ICommand MemoryPlusCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }

        public ICommand MemoryMinusCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }
        #endregion


        public ICommand CalculatingDateCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    CurrentPage = _calculatingDate;
                });
            }
        }


        public ICommand UnitConversionCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    CurrentPage = _unitConversion;
                });
            }
        }

    }
}
