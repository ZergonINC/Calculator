using Calculator.Model;
using Calculator.Model.Executers;
using Calculator.Model.Operations;
using Calculator.Model.Operations.ClearOperations;
using Calculator.Model.Operations.ConvertorsAndValidators;
using Calculator.Model.Operations.MemoryOperations;
using Calculator.ViewModel.Services;
using Calculator.Views;
using log4net;
using System;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
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

        ILog log = LogManager.GetLogger(typeof(MainWindowViewModel));

        protected BaseCalculatorModel _calculator;

        protected MainWindowViewModel _mainVeiwModel;

        protected ParameterizedOperationExecuting parameterized = new();

        protected OperationExecuting notParameterized = new();

        public MainWindowViewModel()
        {
            this._calculator = new();
            _mainVeiwModel = this;
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
                                BackspaceClear.Do(Temporary); 

                    Temporary = Temporary.Contains(',') ? 
                                Temporary : 
                                NumberValidator.GetValidNumericValue(Temporary);
                    Display = Temporary;
                    log.Info($"Number - {Display}");
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

                    if(Temporary != String.Empty && Temporary.Contains(',') && Temporary[^1] == '0')
                        Display = NumberValidator.GetValidNumericValue(Temporary);

                    if (Temporary != String.Empty)
                        parameterized.SetOperation(new Numbers(_calculator)).Do(Display);

                    SecondDisplay = parameterized.SetOperation(new Sign(_calculator)).Do(sign);

                    if (Temporary != String.Empty && notParameterized.SetOperation(new Equally(_calculator)).CanDo())
                    {
                        Display = notParameterized.SetOperation(new Equally(_calculator)).Do();
                        log.Info($"Equally - {Display}");
                    }                      

                    Temporary = String.Empty;
                    log.Info($"Arithmetic - {sign}");
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

                    if ( Temporary[^1] == ',')
                        Display = Display.Remove(Display.Length - 1);

                    if ( Temporary.Contains(',') && Temporary[^1] == '0')
                        Display = NumberValidator.GetValidNumericValue(Temporary);

                    parameterized.SetOperation(new UnaryElements(_calculator)).Do(Display);

                    parameterized.SetOperation(new UnaryElements(_calculator)).Do(element);

                    Display = notParameterized.SetOperation(new UnaryEqually(_calculator)).Do();//изменять шрифт чисел при достижении определенного количества

                    Temporary = "0";
                    log.Info($"Equally - {Display}");
                    log.Info($"UnaryArithmetic - {element}");
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
                    log.Info($"Equally - {Display}");
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
                    log.Info("ClearCommand");
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
                    log.Info("ClearEntryCommand");
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
                    log.Info($"BackspaceCommand - {Display}");
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
                    log.Info("MemoryClearCommand");
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
                    log.Info($"MemoryReadCommand - {Display}");
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

                    log.Info($"MemorySaveCommand - {MemoryDisplay}");
                });
            }
        }
        #endregion

        #region Menu commands

        public ICommand ExpressionsCalculatorCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;

                    var expressionsCalculatingViewModel = new AdvancedWindowViewModel();

                    displayRootRegistry.ShowPresentation(expressionsCalculatingViewModel);

                    displayRootRegistry.HidePresentation(_mainVeiwModel);
                    log.Info("Called Expressions Calculator");
                });
            }
        }

        public ICommand MiniCalculatorCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;

                    var miniViewModel = new MiniWindowViewModel();

                    displayRootRegistry.ShowPresentation(miniViewModel);

                    displayRootRegistry.HidePresentation(_mainVeiwModel);

                    log.Info("Called Mini Calculator");
                });
            }
        }
        #endregion
    }
}