using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations.ClearOperations
{
    public static class BackspaceClear
    {
        public static bool CanDo(string input)
        {
            return input.Length > 0;
        }

        public static string Do(string input) => input.Remove(input.Length - 1);
    }
}
