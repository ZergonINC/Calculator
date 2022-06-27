﻿using Calculator2.Model;
using Calculator2.Model.Executers;
using Calculator2.Model.Operations;
using Calculator2.Model.Operations.ClearOperations;
using Calculator2.Model.Operations.ConvertorsAndValidators;
using Calculator2.Views;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator2.ViewModel
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

        BaseCalculatorModel _calculator;

        protected MainWindowViewModel _mainVeiwModel;

        ParameterizedOperationExecuting parameterized = new();

        OperationExecuting notParameterized = new();

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

                    bool TemporarilyNoEmpty = Temporary != String.Empty;

                    if (TemporarilyNoEmpty && Temporary[^1] == ',')
                        Display = Display.Remove(Display.Length - 1);

                    if(TemporarilyNoEmpty && Temporary.Contains(',') && Temporary[^1] == '0')
                        Display = NumberValidator.GetValidNumericValue(Temporary);

                    if (TemporarilyNoEmpty)
                        parameterized.SetOperation(new Number(_calculator)).Do(Display);

                    SecondDisplay = parameterized.SetOperation(new Sign(_calculator)).Do(sign);

                    if (TemporarilyNoEmpty && notParameterized.SetOperation(new Equally(_calculator)).CanDo())
                        Display = notParameterized.SetOperation(new Equally(_calculator)).Do();

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
                    parameterized.SetOperation(new Number(_calculator)).Do(Display);

                    Display = notParameterized.SetOperation(new Equally(_calculator)).Do();

                    notParameterized.SetOperation(new Clear(_calculator)).Realize();

                    SecondDisplay = String.Empty;

                    Temporary = "0";
                }, (parameter) => notParameterized.SetOperation(new Equally(_calculator)).CanRealize());
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
                });
            }
        }
        #endregion
    }
}