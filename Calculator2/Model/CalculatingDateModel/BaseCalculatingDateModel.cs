using Calculator2.Interfaces;
using Calculator2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.CalculatingDateModel
{
    public class BaseCalculatingDateModel : BaseViewModel, IDateModel
    {

        private DateTime _firstDate;

        public DateTime FirstDate
        {
            get { return _firstDate; }
            set
            {
                _firstDate = value;
                RaisePropertyChanged(nameof(FirstDate));
            }
        }


        private DateTime _secondDate;

        public DateTime SecondDate
        {
            get { return _secondDate; }
            set
            {
                _secondDate = value;
                RaisePropertyChanged(nameof(SecondDate));
            }
        }
    }
}
