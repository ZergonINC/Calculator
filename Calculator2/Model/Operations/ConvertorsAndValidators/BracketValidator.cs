using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.ConvertorsAndValidators
{
    public static class BracketValidator
    {
        public static string ValidParentheses(string input)//убрать статик и добавить переменную отвечающую за скобки
        {
            int c = 0;
            var output = input.Select(i => c += i == '(' ? 1 : i == ')' ? -1 : 0).LastOrDefault().ToString();


            return output;//доделать отображение
        }
    }
}
