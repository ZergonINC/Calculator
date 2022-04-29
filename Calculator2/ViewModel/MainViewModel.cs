using Calculator2.Interfaces;
using Calculator2.Model;
using Calculator2.Model.Executers;
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

        private string _temp = String.Empty;

        public string Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                RaisePropertyChanged(nameof(Temp));
            }
        }

        BaseCalculatorModel _calculator;

        ParameterizedOperationExecuting parameterized = new();

        OperationExecuting notparameterized = new();

        public MainViewModel(BaseCalculatorModel calculator)
        {
            this._calculator = calculator;
        }


        #region Base commands
        public ICommand NumberCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Display = "";

                    var number = parameter.ToString();

                    Temp += number;

                    Temp = NumberValidator.Check(Temp) ?
                        NumberValidator.GetValidValue(Temp) :
                        Temp.Remove(Temp.Length - 1); // валидировать в пердставлении

                    Display = Temp;

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

                    Temp = "";

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
                    Temp = "";
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
                    Temp = Temp.Remove(Temp.Length - 1);
                    if (Display.Length == 0)
                    {
                        Display = "0";
                    }

                }, (parametr) => Display.Length > 0 && Temp.Length > 0);
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
