using Calculator2.Interfaces;
using Calculator2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model
{
    public class BaseCalculatorModel : BaseViewModel, ICalculator
    {
        private string _leftOperand = "";

        public string LeftOperand
        {
            get { return _leftOperand; }
            set
            {
                _leftOperand = value;
                RaisePropertyChanged(nameof(LeftOperand));
            }
        }


        private string _rightOperand = "";

        public string RightOperand
        {
            get { return _rightOperand; }
            set
            {
                _rightOperand = value;
                RaisePropertyChanged(nameof(RightOperand));
            }
        }


        private string _operator = "";

        public string Operator
        {
            get { return _operator; }
            set
            {
                _operator = value;
                RaisePropertyChanged(nameof(Operator));
            }
        }


        private string _result = "";

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }


        private string _temp = "";

        public string Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                RaisePropertyChanged(nameof(Temp));
            }
        }
    }
}
