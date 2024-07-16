using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Tools;

namespace Ques.Algorithms
{
    class Basic
    {
        /*
         * Gives the result of the simple arithmetic expresion.
        * Which allows only + - * / and sqrt
        * In the arithmetic expression, sub expression which has higher priority must be enclosed in parentheses. 
        * test : string expression = "( ( 1 + sqrt( 5.0 ) ) / 2.0 )";
        */
        public static double simpleArithMeticExpression(string expression)
        {
            string[] eles = StringTool.readArithMeticExpression(expression);

            Stack<double> vals = new Stack<double>();
            Stack<string> ops = new Stack<string>();

            foreach (string s in eles)
            {
                if (s == "+" || s == "-" || s == "*" || s == "/" || s == "sqrt") ops.Push(s);
                else if (s == "(") ;
                else if (s == ")")
                {
                    double res = 0;
                    double val1 = vals.Pop();

                    string op = ops.Pop();
                    if (op == "+") res = vals.Pop() + val1;
                    if (op == "-") res = vals.Pop() - val1;
                    if (op == "*") res = vals.Pop() * val1;
                    if (op == "/") res = vals.Pop() / val1;
                    if (op == "sqrt") res = Math.Sqrt(val1);
                    vals.Push(res);
                }
                else { vals.Push(Convert.ToDouble(s)); }
            }

            return vals.Pop();
        }
    }
}
