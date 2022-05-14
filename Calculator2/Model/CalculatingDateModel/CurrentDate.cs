using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.CalculatingDateModel
{
    public class CurrentDate
    {
        BaseCalculatingDateModel _dateModel;

        public CurrentDate(BaseCalculatingDateModel dateModel)
        {
            _dateModel = dateModel;
        }

        public void GettingCurrentDate()
        {
            _dateModel.FirstDate = DateTime.Today;

            _dateModel.SecondDate = DateTime.Today;
        }
    }
}
