using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Tools;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        public static double CalculateInfixArithMeticExpression(string expression)
        {
            string[] eles = StringTool.ReadInfixArithmeticExpression(expression);

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

        public static double CalculateSufixArithMeticExpression(string expression)
        {
            string[] eles = expression.Split(' ');
            Regex numberRegex = new Regex(@"^\d+$");// '\d' means number, '+' means one or more preceding character 
            Stack<double> vals = new Stack<double>();

            foreach (string str in eles)
            {   
                if (numberRegex.IsMatch(str))
                {
                    vals.Push(Convert.ToDouble(str));
                }
                else
                {
                    double n1 = vals.Pop();
                    double n2 = vals.Pop();
                    double res = 0;
                    if (str == "+") res = n1 + n2;
                    if (str == "-") res = n2 - n1;
                    if (str == "*") res = n1 * n2;
                    if (str == "/") res = n2 / n1;
                    vals.Push(res);
                }
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

        /*1. Creates a stack for operators and a list for numbers, then scans the expression by char.
          2.
         */
        public static string InfixTest1 = "3 * (11 - 8) - 45 / ((98 - 60) / 10 + 6) ";
        /// <summary>
        /// Only apply to single-digit integers and + - * /
        /// Variable a is the infix expression char list.
        /// s is to contain operators.
        /// </summary>
        /// <param name="sufixExpression"></param>
        /// <returns></returns>
        public static string InfixToSufix(string infixExpression)
        {
            Stack<string> s = new Stack<string>();
            List<string> a = new List<string>();
            string[] expressionElements = StringTool.ReadInfixArithmeticExpression(infixExpression);
            foreach (string ele in expressionElements)
            {
                if (ele=="+" || ele== "-" || ele== "*" || ele== "/")
                {                       
                    while (s.Any() && s.Peek() != "(" && OperatorPriority(s.Peek(),ele))
                    {
                        a.Add(s.Pop());
                    }
                    s.Push(ele);
                }
                else if ( ele == "(")
                {
                    s.Push(ele);
                }
                else if ( ele == ")")
                {
                    string ele_s = s.Pop();
                    while (ele_s != "(")
                    {
                        a.Add(ele_s);
                        ele_s = s.Pop();
                    }
                }
                else //if it's a number
                {
                    a.Add(ele);
                }
            }
            while (s.Any())
            {
                a.Add(s.Pop());
            }
            StringBuilder sb = new StringBuilder();
            foreach (string str in a)
            {
                sb.Append(str + " ");
            }
            string sufixExpression = sb.ToString().Substring(0,sb.Length - 1);
            return sufixExpression;
        }

        

        /// <summary>
        /// Compare whether operator o1 has higher priority than o2
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>

        public static bool OperatorPriority(string o1, string o2)
        {
            int priorityO1 = 1;
            int priorityO2 = 1;
            if (o1 == "*" || o1 == "/") priorityO1 = 2;
            if (o2 == "*" || o2 == "/") priorityO2 = 2;
            return priorityO1 > priorityO2;
        }

        //1.3.5 Return the binary
        public static void _1_3_5(int N)
        {
            Stack<int> s = new Stack<int>();
            while (N > 0)
            {
                s.Push(N % 2);
                N = N / 2;
            }
            foreach (int n in s) Console.Write(n);
        }

        //1.3.6 reverses the items of the q
        public static void _1_3_6()
        {
            Queue<int> q = new Queue<int>();
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < 5; i++)
            {
                q.Enqueue(i);
            }
            //incomplete
        }

        static string _1_3_9Test = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        //1.3.9 complete the infix with left parenthesis
        public static string _1_3_9(string infixEx)
        {
            
            string fixedInfixEx = "";
            string[] eles = StringTool.ReadInfixArithmeticExpression(infixEx);
            List<string> listEles = new List<string>();
            for (int i = eles.Length - 1 ; i >= 0; i --)
            {
                string ele = eles[i];
                if (ele == ")") listEles.Add(ele);
                if (IsNumber((ele)))
                {
                    if (i + 2 < eles.Length - 1) 
                    { 
                        if (IsOperator(eles[i+1]) && IsNumber(eles[i + 2]))
                        {
                            //if 
                            //listEles.Add("0");//a placeholder for number result of the calculation. 
                        }
                    }
                }
            }
            return fixedInfixEx;
        }
        private static bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }
        private static bool IsNumber(string s)
        {
            Regex isNum = new Regex(@"^\d+$");
            return isNum.IsMatch(s);
        }
    }
}
