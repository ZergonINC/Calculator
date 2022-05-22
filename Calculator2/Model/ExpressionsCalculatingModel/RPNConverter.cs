using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator2.Model.ExpressionsCalculatingModel
{
    public class RPNConverter
    {
        Stack<string> stack = new();

        string[] result = Array.Empty<string>();
        public string[] ToRPN(string[] s)
        {
            foreach (var item in s)
            {
                if (double.TryParse(item, out var i))
                    result = result.Append(item).ToArray();

                else
                    switch (item)
                    {
                        case "-":
                            if (stack.FirstOrDefault() == "^" || stack.FirstOrDefault() == "/" || stack.FirstOrDefault() == "*")
                                result = result.Append(stack.Pop()).ToArray();
                            stack.Push(item);
                            break;

                        case "+":
                            if (stack.FirstOrDefault() == "^" || stack.FirstOrDefault() == "/" || stack.FirstOrDefault() == "*")
                                result = result.Append(stack.Pop()).ToArray();
                            stack.Push(item);
                            break;

                        case "*":
                            if (stack.FirstOrDefault() == "^" || stack.FirstOrDefault() == "/" || stack.FirstOrDefault() == "*")
                                result = result.Append(stack.Pop()).ToArray();
                            stack.Push(item);
                            break;

                        case "/":
                            if (stack.FirstOrDefault() == "^" || stack.FirstOrDefault() == "/" || stack.FirstOrDefault() == "*")
                                result = result.Append(stack.Pop()).ToArray();
                            stack.Push(item);
                            break;

                        case "^":
                            if (stack.FirstOrDefault() == "^")
                                result = result.Append(stack.Pop()).ToArray();
                            stack.Push(item);
                            break;

                        case "(":
                            stack.Push(item);
                            break;

                        case ")":
                            var temp = stack.ToArray();
                            foreach (var j in temp)
                            {
                                if (j != "(")
                                    result = result.Append(stack.Pop()).ToArray();
                                else
                                {
                                    stack.Pop();
                                    break;
                                }
                            }
                            break;
                    }
            }

            while (stack.Count > 0)
                result = result.Append(stack.Pop()).ToArray();

            return result;
        }
    }
}
