using Calculator.Interfaces;
using Calculator.Model.Operations.ConvertorsAndValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.ExpressionsCalculatingModel
{
    public class AdvancedElements : IParameterizedOperationExecuting
    {
        BaseCalculatorModel _baseCalculatorModel;

        public AdvancedElements(BaseCalculatorModel baseCalculatorModel)
        {
            _baseCalculatorModel = baseCalculatorModel;
        }

        public bool CanDo()
        {
            return !_baseCalculatorModel.Elements.LastOrDefault("").Contains(')');
        }

        public bool CanDoSign(string element)
        {
            return !NumberValidator.Check(element) && !NumberValidator.Check(_baseCalculatorModel.Elements.LastOrDefault(""));
        }

        public string Do(string element)
        {
            if (!element.Contains(')') && !element.Contains('('))
            {
                if (CanDoSign(element) && CanDo())
                    _baseCalculatorModel.Elements.RemoveAt(_baseCalculatorModel.Elements.Count - 1);
            }

            _baseCalculatorModel.Elements = _baseCalculatorModel.Elements.Append(element).ToList();

            return String.Join(" ", _baseCalculatorModel.Elements);
        }
    }
}
