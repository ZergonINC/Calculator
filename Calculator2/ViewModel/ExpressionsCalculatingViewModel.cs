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

        public ExpressionsCalculatingViewModel()
        {

        }

        public ICommand ExpressionNumberCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    
                });
            }
        }

        public ICommand ExpressionClearCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    
                });
            }
        }

        public ICommand ExpressinArithmeticCommand
        {
            get
            {
                return new RelayCommand((parameter) =>
                {
                    
                });
            }
        }

    }
}
