using Calculator2.Model;
using Calculator2.Model.Executers;
using Calculator2.Model.Operations;
using Calculator2.Model.Operations.ClearOperations;
using Calculator2.Model.Operations.ConvertorsAndValidators;
using Calculator2.Model.Operations.MemoryOperations;
using Calculator2.ViewModel.Services;
using Calculator2.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator2.ViewModel
{
    public class MainPageViewModel : BaseViewModel
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


        private string _secondDisplay = String.Empty;
        public string SecondDisplay
        {
            get { return _secondDisplay; }
            set
            {
                _secondDisplay = value;
                RaisePropertyChanged(nameof(SecondDisplay));
            }
        }


        private string _temporary = "0";
        public string Temporary
        {
            get { return _temporary; }
            set
            {
                _temporary = value;
                RaisePropertyChanged(nameof(Temporary));
            }
        }


        private string _memoryDisplay = "0";
        public string MemoryDisplay
        {
            get { return _memoryDisplay; }
            set
            {
                _memoryDisplay = value;
                RaisePropertyChanged(nameof(MemoryDisplay));
            }
        }


        protected BaseCalculatorModel _calculator;

        protected ParameterizedOperationExecuting parameterized = new();

        protected OperationExecuting notParameterized = new();


        public MainPageViewModel()
        {
            this._calculator = new();
        }

        #region Base commands
        public ICommand NumberCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var number = parameter.ToString();

                    Temporary += number;

                    if (Temporary.StartsWith(","))
                        Temporary = "0,";

                    Temporary = NumberValidator.Check(Temporary) ?
                                NumberValidator.GetValidValue(Temporary) :
                                BackspaceClear.Do(Temporary); // валидировать в пердставлении

                    Temporary = Temporary.Contains(',') ?
                                Temporary :
                                NumberValidator.GetValidNumericValue(Temporary);

                    Display = Temporary;
                });
            }
        }

        public ICommand ArithmeticCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var sign = parameter.ToString();

                    if (Temporary != String.Empty && Temporary[^1] == ',')
                        Display = Display.Remove(Display.Length - 1);

                    if (Temporary != String.Empty && Temporary.Contains(',') && Temporary[^1] == '0')
                        Display = NumberValidator.GetValidNumericValue(Temporary);

                    if (Temporary != String.Empty)
                        parameterized.SetOperation(new Numbers(_calculator)).Do(Display);

                    SecondDisplay = parameterized.SetOperation(new Sign(_calculator)).Do(sign);

                    if (Temporary != String.Empty && notParameterized.SetOperation(new Equally(_calculator)).CanDo())
                        Display = notParameterized.SetOperation(new Equally(_calculator)).Do();

                    Temporary = String.Empty;
                });
            }
        }


        public ICommand UnaryArithmeticCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var element = parameter.ToString();

                    if (Temporary[^1] == ',')
                        Display = Display.Remove(Display.Length - 1);

                    if (Temporary.Contains(',') && Temporary[^1] == '0')
                        Display = NumberValidator.GetValidNumericValue(Temporary);

                    parameterized.SetOperation(new UnaryElements(_calculator)).Do(Display);

                    parameterized.SetOperation(new UnaryElements(_calculator)).Do(element);

                    Display = notParameterized.SetOperation(new UnaryEqually(_calculator)).Do();//изменять шрифт чисел при достижении определенного количества

                    Temporary = "0";
                });
            }
        }


        public ICommand EquallyCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    parameterized.SetOperation(new Numbers(_calculator)).Do(Display);

                    Display = notParameterized.SetOperation(new Equally(_calculator)).Do();

                    notParameterized.SetOperation(new ClearAfterEqually(_calculator)).Do();

                    SecondDisplay = String.Empty;

                    Temporary = "0";
                }, (parameter) => notParameterized.SetOperation(new UnaryEqually(_calculator)).CanDo());
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
                    Display = notParameterized.SetOperation(new Clear(_calculator)).Do();

                    Temporary = "0";

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

                    Temporary = "0";
                });
            }
        }

        public ICommand BackspaceCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Display = BackspaceClear.Do(Display);

                    Temporary = BackspaceClear.Do(Temporary);

                    if (Display.Length == 0)
                        Display = "0";
                }, (parametr) => BackspaceClear.CanDo(Display) && BackspaceClear.CanDo(Temporary));
            }
        }
        #endregion

        #region Memory commands
        public ICommand MemoryClearCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    MemoryDisplay = notParameterized.SetOperation(new MemoryClear(_calculator)).Do();
                });
            }
        }

        public ICommand MemoryReadCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Temporary = notParameterized.SetOperation(new MemoryRead(_calculator)).Do();

                    Display = Temporary;
                });
            }
        }

        public ICommand MemorySaveCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    MemoryDisplay = parameterized.SetOperation(new MemorySave(_calculator)).Do(Display);

                    Temporary = "0";
                });
            }
        }
        #endregion
    }  
}