using Calculator2.Model;
using Calculator2.Model.Executers;
using Calculator2.Model.ExpressionsCalculatingModel;
using Calculator2.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator2.ViewModel
{
    public class ExpressionsCalculatingViewModel : BaseViewModel
    {
        private string _expressionDisplay = "0";

        public string ExpressionDisplay
        {
            get { return _expressionDisplay; }
            set
            {
                _expressionDisplay = value;
                RaisePropertyChanged(nameof(ExpressionDisplay));
            }
        }

        private string _expressionSecondDisplay;

        public string ExpressionSecondDisplay
        {
            get { return _expressionSecondDisplay; }
            set
            {
                _expressionSecondDisplay = value;
                RaisePropertyChanged(nameof(ExpressionSecondDisplay));
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

        BaseCalculatorModel _expressionCalculator;

        ParameterizedOperationExecuting expressionParameterized = new();

        OperationExecuting expressionNotParameterized = new();

        public ExpressionsCalculatingViewModel()
        {
            _expressionCalculator = new();
        }

        public ICommand ExpressionNumberCommand
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

                    ExpressionDisplay = Temporary;
                });
            }
        }

        public ICommand ExpressionArithmeticCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var sign = parameter.ToString();

                    if (Temporary != String.Empty && Temporary[^1] == ',')
                        ExpressionDisplay = ExpressionDisplay.Remove(ExpressionDisplay.Length - 1);

                    if (Temporary != String.Empty && Temporary.Contains(',') && Temporary[^1] == '0')//понять как валидировать в представлении и засунуть это в отдельные методы 
                        ExpressionDisplay = NumberValidator.GetValidNumericValue(Temporary);

                    if ((Temporary != String.Empty || ExpressionDisplay == "0") && expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).CanDo())
                    expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).Do(ExpressionDisplay);

                    ExpressionSecondDisplay = expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).Do(sign);

                    Temporary = String.Empty;
                }, (parameter) => Temporary != String.Empty || ExpressionDisplay == "0");
            }
        }

        public ICommand ExpressionLeftBracketCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var bracket = parameter.ToString();

                    ExpressionSecondDisplay = expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).Do(bracket);
                }, (parameter) => (expressionParameterized.SetOperation(new Sign(_expressionCalculator)).CanDo() || Temporary == "0") && expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).CanDo());
            }
        }

        public ICommand ExpressionRightBracketCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    var bracket = parameter.ToString();

                    Temporary = ExpressionDisplay;

                    if (Temporary[^1] == ',')
                        ExpressionDisplay = ExpressionDisplay.Remove(ExpressionDisplay.Length - 1);

                    if (Temporary.Contains(',') && Temporary[^1] == '0')
                        ExpressionDisplay = NumberValidator.GetValidNumericValue(Temporary);

                    expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).Do(ExpressionDisplay);

                    ExpressionSecondDisplay = expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).Do(bracket);
                }, (parameter) => expressionParameterized.SetOperation(new Sign(_expressionCalculator)).CanDo());
            }
        }

        public ICommand ExpressionEquallyCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    expressionParameterized.SetOperation(new ExpressionElements(_expressionCalculator)).Do(ExpressionDisplay);

                    expressionNotParameterized.SetOperation(new CalculatingExpression(_expressionCalculator)).Realize();

                    ExpressionDisplay = expressionNotParameterized.SetOperation(new CalculatingExpression(_expressionCalculator)).Do();

                    expressionNotParameterized.SetOperation(new Clear(_expressionCalculator)).Realize();

                    ExpressionSecondDisplay = String.Empty;
                });
            }
        }

        #region Clear commands

        public ICommand ExpressionClearCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    ExpressionDisplay = expressionNotParameterized.SetOperation(new Clear(_expressionCalculator)).Do();

                    Temporary = "0";

                    ExpressionSecondDisplay = String.Empty;
                });
            }
        }

        public ICommand ExpressionBackspaceCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    ExpressionDisplay = ExpressionDisplay.Remove(ExpressionDisplay.Length - 1);
                    Temporary = Temporary.Remove(Temporary.Length - 1);
                    if (ExpressionDisplay.Length == 0)
                        ExpressionDisplay = "0";


                }, (parametr) => ExpressionDisplay.Length > 0 && Temporary.Length > 0);
            }
        }
        #endregion
    }
}
