using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Model.DrawingModel
{
    class ValuesFilling
    {
        Point FillPoint(double coordinateX, double coordinateY)
        {
            Point point = new(coordinateX, coordinateY);
            
            return point;
        }

        List<Point> FillPoints(Point point) 
        {
            List<Point> points = new();

            points.Add(point);

            return points;
        }
    }
}
