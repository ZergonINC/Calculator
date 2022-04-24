using Calculator2.Interfaces;
using Calculator2.Model;
using Calculator2.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
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


        private string _secondDisplay;

        public string SecondDisplay
        {
            get { return _secondDisplay; }
            set
            {
                _secondDisplay = value;
                RaisePropertyChanged(nameof(SecondDisplay));
            }
        }

        BaseCalculatorModel _calculator;

        NumberValidator numberValidator = new();

        ParametrizedCalculatorModel parametrized = new();

        CalculatorModel notparametezer = new();

        public MainViewModel(BaseCalculatorModel calculator)
        {
            this._calculator = calculator;
        }


        #region Base commands
        public ICommand NumberCommand
        {
            get
            {
                return new RelayCommand((parametr) =>
                {
                    var number = parametr.ToString();

                    number = numberValidator.Check(number) ?
                     numberValidator.GetValidValue(number) :
                     number.Remove(number.Length - 1);

                    parametrized.SetOp(new Number(_calculator)).Do(number);

                    Display += number;
                }, (parametr) => parametrized.SetOp(new Number(_calculator)).CanDo());
            }
        }

        public ICommand ArithmeticCommand
        {
            get
            {
                return new RelayCommand((parametr) =>
                {
                    var sign = parametr.ToString();
                    parametrized.SetOp(new Sign(_calculator)).Do(sign);

                    Display += " " + sign + " ";
                }, (parametr) => parametrized.SetOp(new Sign(_calculator)).CanDo());
            }
        }

        public ICommand EqualsCommand
        {
            get
            {
                return new RelayCommand((parametr) =>
                {
                    notparametezer.SetOp(new Equally(_calculator)).Do();

                    Display = _calculator.Result;
                }, (parametr) => notparametezer.SetOp(new Equally(_calculator)).CanDo());
            }
        }
        #endregion

        #region Clear commands
        public ICommand ClearCommand
        {
            get
            {
                return new RelayCommand((parametr) =>
                {
                    notparametezer.SetOp(new Clear(_calculator)).Do();
                }, (parametr) => notparametezer.SetOp(new Clear(_calculator)).CanDo());
            }
        }

        public ICommand CleanEntryCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }

        public ICommand BackspaceCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
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
    }
}
