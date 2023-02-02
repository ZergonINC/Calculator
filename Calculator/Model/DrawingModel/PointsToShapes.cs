using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Calculator.Model.DrawingModel
{
    public class PointsToShapes 
    {
        public PathGeometry GetShape(List<Point> points, PathGeometry shapes)
        {

            List<PathSegment> pathsegments = new();//Набор сегментов пути
            //по точкам добавляем сегменты пути
            pathsegments.Add(new PolyLineSegment(points, true));
            
            //Из сегментов пути строим фигуру с первой точкой вначале.
            PathFigure graph = new PathFigure(points.First(), pathsegments, false);
            //Добавляем фигуру в геометрию
            shapes.Figures.Add(graph);
            
            //Возвращаем геометрию.
            return shapes;
        }

    }
}
