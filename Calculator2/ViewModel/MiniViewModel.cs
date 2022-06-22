using Calculator2.Model;
using Calculator2.Model.Executers;
using Calculator2.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator2.ViewModel
{
    public class MiniViewModel : BaseViewModel
    {
        private string _miniDisplay = "0";

        public string MiniDisplay
        {
            get { return _miniDisplay; }
            set
            {
                _miniDisplay = value;
                RaisePropertyChanged(nameof(MiniDisplay));
            }
        }

        private string _miniSecondDisplay = String.Empty;

        public string MiniSecondDisplay
        {
            get { return _miniSecondDisplay; }
            set
            {
                _miniSecondDisplay = value;
                RaisePropertyChanged(nameof(MiniSecondDisplay));
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

        BaseCalculatorModel _miniCalculator;

        protected MiniViewModel _miniVeiwModel;

        ParameterizedOperationExecuting miniParameterized = new();

        OperationExecuting miniNotParameterized = new();

        public MiniViewModel()
        {
            this._miniCalculator = new();

            _miniVeiwModel = this;
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

                    MiniDisplay = Temporary;
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

                    bool TemporarilyNoEmpty = Temporary != String.Empty;

                    if (TemporarilyNoEmpty && Temporary[^1] == ',')
                        MiniDisplay = MiniDisplay.Remove(MiniDisplay.Length - 1);

                    if (TemporarilyNoEmpty && Temporary.Contains(',') && Temporary[^1] == '0')
                        MiniDisplay = NumberValidator.GetValidNumericValue(Temporary);

                    if (TemporarilyNoEmpty)
                        miniParameterized.SetOperation(new Number(_miniCalculator)).Do(MiniDisplay);

                    MiniSecondDisplay = miniParameterized.SetOperation(new Sign(_miniCalculator)).Do(sign);

                    if (TemporarilyNoEmpty && miniNotParameterized.SetOperation(new Equally(_miniCalculator)).CanDo())
                        MiniDisplay = miniNotParameterized.SetOperation(new Equally(_miniCalculator)).Do();

                    Temporary = String.Empty;
                });
            }
        }

        public ICommand EquallyCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    miniParameterized.SetOperation(new Number(_miniCalculator)).Do(MiniDisplay);

                    MiniDisplay = miniNotParameterized.SetOperation(new Equally(_miniCalculator)).Do();

                    miniNotParameterized.SetOperation(new Clear(_miniCalculator)).Realize();

                    MiniSecondDisplay = String.Empty;

                    Temporary = "0";
                }, (parameter) => miniNotParameterized.SetOperation(new Equally(_miniCalculator)).CanRealize());
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
                    MiniDisplay = miniNotParameterized.SetOperation(new Clear(_miniCalculator)).Do();

                    Temporary = "0";

                    MiniSecondDisplay = String.Empty;
                });
            }
        }

        public ICommand CleanEntryCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    MiniDisplay = "0";

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
                    MiniDisplay = BackspaceClear.Do(MiniDisplay);

                    Temporary = BackspaceClear.Do(Temporary);

                    if (MiniDisplay.Length == 0)
                        MiniDisplay = "0";
                }, (parametr) => BackspaceClear.CanDo(MiniDisplay) && BackspaceClear.CanDo(Temporary));
            }
        }
        #endregion


        public ICommand CalculatorViewCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;

                    var mainViewModel = new MainViewModel();

                    displayRootRegistry.ShowPresentation(mainViewModel);

                    displayRootRegistry.HidePresentation(_miniVeiwModel);
                });
            }
        }
    }
}