using Calculator.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator.ViewModel
{
    internal class GraphDrawingViewModel : BaseViewModel
    {
        private double _coordinateY;
        public double СoordinateY
        {
            get { return _coordinateY; }
            set
            {
                _coordinateY = value;
                RaisePropertyChanged(nameof(СoordinateY));
            }
        }

        private double _coordinateX;
        public double СoordinateX
        {
            get { return _coordinateX; }
            set
            {
                _coordinateX = value;
                RaisePropertyChanged(nameof(СoordinateX));
            }
        }

        private PathGeometry _drawnShape = new();
        public PathGeometry DrawnShape
        {
            get { return _drawnShape; }
            set
            {
                _drawnShape = value;
                RaisePropertyChanged(nameof(DrawnShape));
            }
        }

        public ICommand Command
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
