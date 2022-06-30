using Calculator2.Interfaces;
using Calculator2.ViewModel;
using System;
using System.Collections.Generic;

namespace Calculator2.Model
{
    public class BaseCalculatorModel : BaseViewModel, ICalculator
    {
        private List<string> _elements = new();

        public List<string> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                RaisePropertyChanged(nameof(Elements));
            }
        }

        private Stack<string> _writeback = new();

        public Stack<string> Writeback
        {
            get { return _writeback; }
            set
            {
                _writeback = value;
                RaisePropertyChanged(nameof(Writeback));
            }
        }

        private string _firstOperand = String.Empty;

        public string FirstOperand
        {
            get { return _firstOperand; }
            set
            {
                _firstOperand = value;
                RaisePropertyChanged(nameof(FirstOperand));
            }
        }

        private string _secondOperand = String.Empty;

        public string SecondOperand
        {
            get { return _secondOperand; }
            set
            {
                _secondOperand = value;
                RaisePropertyChanged(nameof(SecondOperand));
            }
        }

        private string _operator = String.Empty;

        public string Operator
        {
            get { return _operator; }
            set
            {
                _operator = value;
                RaisePropertyChanged(nameof(Operator));
            }
        }

        private string _result = String.Empty;

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        private string _memory = String.Empty;

        public string Memory
        {
            get { return _memory; }
            set
            {
                _memory = value;
                RaisePropertyChanged(nameof(Memory));
            }
        }
    }
}
