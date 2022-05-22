using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.ExpressionsCalculatingModel
{
    public class CalculatingExpression
    {
        public double calc(string[] obj)
        {
            Stack<double> temp = new Stack<double>();

            foreach (var item in obj)
            {
                if (double.TryParse(item, out var i))
                {
                    temp.Push(i);
                    continue;
                }

                var right = temp.Pop();
                var left = temp.Pop();

                switch (item)
                {
                    case "-":
                        temp.Push(left - right);
                        break;

                    case "+":
                        temp.Push(left + right);
                        break;

                    case "*":
                        temp.Push(left * right);
                        break;

                    case "/":
                        temp.Push(left / right);
                        break;

                    case "^":
                        temp.Push(Math.Pow(left, right));
                        break;
                }
            } 

            return temp.Pop();
        }
    }
}