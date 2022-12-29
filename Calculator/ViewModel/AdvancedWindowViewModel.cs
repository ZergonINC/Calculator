using Calculator.Model;
using Calculator.Model.AdvancedCalculatingModel;
using Calculator.Model.Executers;
using Calculator.Model.ExpressionsCalculatingModel;
using Calculator.Model.Operations;
using Calculator.Model.Operations.ClearOperations;
using Calculator.Model.Operations.ConvertorsAndValidators;
using Calculator.Model.Operations.MemoryOperations;
using Calculator.ViewModel.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class AdvancedWindowViewModel : BaseViewModel
    {
        private string _advancedDisplay = "0";
        public string AdvancedDisplay
        {
            get { return _advancedDisplay; }
            set
            {
                _advancedDisplay = value;
                RaisePropertyChanged(nameof(AdvancedDisplay));
            }
        }


        private string _advancedSecondDisplay;
        public string AdvancedSecondDisplay
        {
            get { return _advancedSecondDisplay; }
            set
            {
                _advancedSecondDisplay = value;
                RaisePropertyChanged(nameof(AdvancedSecondDisplay));
            }
        }


        private string _advancedMemoryDisplay = "0";
        public string AdvancedMemoryDisplay
        {
            get { return _advancedMemoryDisplay; }
            set
            {
                _advancedMemoryDisplay = value;
                RaisePropertyChanged(nameof(AdvancedMemoryDisplay));
            }
        }


        private string _advancedBracketDisplay = "0";
        public string AdvancedBracketDisplay
        {
            get { return _advancedBracketDisplay; }
            set
            {
                _advancedBracketDisplay = value;
                RaisePropertyChanged(nameof(AdvancedBracketDisplay));
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


        protected BaseCalculatorModel _advancedCalculator;

        protected AdvancedWindowViewModel _advancedCalculatingVeiwModel;

        protected ParameterizedOperationExecuting advancedParameterized = new();

        protected OperationExecuting advancedNotParameterized = new();

        public AdvancedWindowViewModel()
        {
            _advancedCalculator = new();

            _advancedCalculatingVeiwModel = this;
        }

        public ICommand AdvancedNumberCommand
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

                    AdvancedDisplay = Temporary;
                });
            }
        }

        public ICommand AdvancedArithmeticCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var sign = parameter.ToString();

                    if (Temporary != String.Empty && Temporary[^1] == ',')
                        AdvancedDisplay = AdvancedDisplay.Remove(AdvancedDisplay.Length - 1);

                    if (Temporary != String.Empty && Temporary.Contains(',') && Temporary[^1] == '0')//понять как валидировать в представлении и засунуть это в отдельные методы 
                        AdvancedDisplay = NumberValidator.GetValidNumericValue(Temporary);

                    if ((Temporary != String.Empty || AdvancedDisplay == "0") && advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).CanDo())
                    advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).Do(AdvancedDisplay);

                    AdvancedSecondDisplay = advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).Do(sign);

                    Temporary = String.Empty;
                }, (parameter) => Temporary != String.Empty || AdvancedDisplay == "0");
            }
        }

        public ICommand AdvancedLeftBracketCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var bracket = parameter.ToString();

                    AdvancedSecondDisplay = advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).Do(bracket);

                    AdvancedBracketDisplay = advancedNotParameterized.SetOperation(new BracketValidator(_advancedCalculator)).Do();

                }, (parameter) => (advancedParameterized.SetOperation(new Sign(_advancedCalculator)).CanDo() || Temporary == "0") && advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).CanDo());
            }
        }

        public ICommand AdvancedRightBracketCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var bracket = parameter.ToString();

                    Temporary = AdvancedDisplay;

                    if (Temporary[^1] == ',')
                        AdvancedDisplay = AdvancedDisplay.Remove(AdvancedDisplay.Length - 1);

                    if (Temporary.Contains(',') && Temporary[^1] == '0')
                        AdvancedDisplay = NumberValidator.GetValidNumericValue(Temporary);

                    advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).Do(AdvancedDisplay);

                    AdvancedSecondDisplay = advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).Do(bracket);

                    AdvancedBracketDisplay = advancedNotParameterized.SetOperation(new BracketValidator(_advancedCalculator)).Do();
                }, (parameter) => advancedNotParameterized.SetOperation(new BracketValidator(_advancedCalculator)).CanDo());
            }
        }

        public ICommand AdvancedEquallyCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    advancedParameterized.SetOperation(new AdvancedElements(_advancedCalculator)).Do(AdvancedDisplay);

                    AdvancedDisplay = advancedNotParameterized.SetOperation(new AdvancedEqually(_advancedCalculator)).Do();

                    advancedNotParameterized.SetOperation(new ClearAfterEqually(_advancedCalculator)).Do();

                    AdvancedSecondDisplay = String.Empty;
                });
            }
        }

        #region Clear commands

        public ICommand AdvancedClearCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    AdvancedDisplay = advancedNotParameterized.SetOperation(new Clear(_advancedCalculator)).Do();

                    Temporary = "0";

                    AdvancedSecondDisplay = String.Empty;
                });
            }
        }

        public ICommand AdvancedBackspaceCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    AdvancedDisplay = AdvancedDisplay.Remove(AdvancedDisplay.Length - 1);
                    Temporary = Temporary.Remove(Temporary.Length - 1);
                    if (AdvancedDisplay.Length == 0)
                        AdvancedDisplay = "0";


                }, (parametr) => AdvancedDisplay.Length > 0 && Temporary.Length > 0);
            }
        }
        #endregion

        #region Memory commands
        public ICommand AdvancedMemoryClearCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    AdvancedMemoryDisplay = advancedNotParameterized.SetOperation(new MemoryClear(_advancedCalculator)).Do();
                });
            }
        }

        public ICommand AdvancedMemoryReadCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    Temporary = advancedNotParameterized.SetOperation(new MemoryRead(_advancedCalculator)).Do();

                    AdvancedDisplay = Temporary;
                });
            }
        }

        public ICommand AdvancedMemorySaveCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    AdvancedMemoryDisplay = advancedParameterized.SetOperation(new MemorySave(_advancedCalculator)).Do(AdvancedDisplay);

                    Temporary = "0";
                });
            }
        }
        #endregion

        #region Menu commands

        public ICommand MainCalculatorCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;

                    var mainViewModel = new MainWindowViewModel();

                    displayRootRegistry.ShowPresentation(mainViewModel);

                    displayRootRegistry.HidePresentation(_advancedCalculatingVeiwModel);
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

                    displayRootRegistry.HidePresentation(_advancedCalculatingVeiwModel);
                });
            }
        }
        #endregion
    }
}
