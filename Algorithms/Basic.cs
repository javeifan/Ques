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
            string[] eles = StringTool.ReadArithmeticExpression(expression);

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

            return !leftParentheses.Any();//This is also a critical case.
        }

        public static string InfixTest1 = "3 * (11 - 8) - 45 / ((98 - 60) / 10 + 6) ";
        /// <summary>
        /// Only apply to single-digit integers and + - * /
        /// Variable a is the infix expression char list.
        /// s is to contain operators.
        /// </summary>
        /// <param name="sufixExpression"></param>
        /// <returns></returns>
        public static string InfixToSufix(string sufixExpression)
        {
            Stack<char> s = new Stack<char>();
            List<char> a = new List<char>();
            foreach (char c in sufixExpression.ToCharArray())
            {
                if (c=='+' || c=='-' || c== '*'|| c=='/')
                {
                    while (true)
                    {
                        if (s.Peek() == '(' || OperatorPriority(c, s.Peek()))
                        {
                            s.Push(c);
                            continue;
                        }
                        else
                        {
                            a.Add(s.Pop());
                        }
                    }
                }
                else if ( c == '(')
                {
                    s.Push(c);
                }
                else if ( c == ')')
                {
                    while (true)
                    {
                        char c_s = s.Pop();
                        if (c == '+' || c == '-' || c == '*' || c == '/')
                        {
                            a.Add(c_s);
                        }
                        if (c == '(') continue;
                    }
                }
                else //1. if it's number
                {
                    a.Add(c);
                }
            }
            return new StringBuilder().Append(a.ToArray()).ToString();
        }

        /// <summary>
        /// Compare whether operator o1 has higher priority than o2
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>

        public static bool OperatorPriority(char o1, char o2)
        {
            int priorityO1 = 1;
            int priorityO2 = 1;
            if (o1 == '*' || o1 == '/') priorityO1 = 2;
            if (o2 == '*' || o2 == '/') priorityO2 = 2;
            return priorityO1 > priorityO2;
        }
    }
}
