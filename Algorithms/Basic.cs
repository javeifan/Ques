using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Tools;
using System.Diagnostics;

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

        //1.4 Analysis Of Algorithms
        public static void StopwatchTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Threading.Thread.Sleep(1000);//1000 milisecond
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        //测量一个数组中的三元组和为0的数量
        public static int ThreeSum(int[] array)
        {
            int count = 0;
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int k = 0; k < length; k++)
                    {

                    }
                }
            }
            return count;
        }

        public static string ParenTest1 = "[()]{}{[()()]()}";
        public static string ParenTest2 = "[(])";

        public static bool ParenthesesCheck(string parentheses)
        {
            Stack<char> leftParentheses = new Stack<char>();

            foreach (char c in parentheses.ToCharArray())
            {
                if (c == '[' || c == '{' || c == '(') 
                { 
                    leftParentheses.Push(c);
                    continue;
                }
                if (!leftParentheses.Any()) return false;//Don't forget determine if the collection is empty, it's critical.
                int c_left = leftParentheses.Pop();
                if (c == ')' && c_left != '(') return false;
                if (c == '}' && c_left != '{') return false;
                if (c == ']' && c_left != '[') return false;
            }

            return !leftParentheses.Any();
        }
    }
}
