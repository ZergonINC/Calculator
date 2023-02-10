using Calculator.Interfaces;
using Calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalculatorModel : BaseViewModel, ICalculatorModel
    {
        private List<double> _elements = new();
        public List<double> Elements
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


        private double _firstOperand = 0;
        public double FirstOperand
        {
            get { return _firstOperand; }
            set
            {
                _firstOperand = value;
                RaisePropertyChanged(nameof(FirstOperand));
            }
        }


        private double _secondOperand = 0;
        public double SecondOperand
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


        private double _result = 0;
        public double Result
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

        private int _bracket = 0;
        public int Bracket
        {
            get { return _bracket; }
            set
            {
                _bracket = value;
                RaisePropertyChanged(nameof(Bracket));
            }
        }
    }
}
