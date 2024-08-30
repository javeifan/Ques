using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Tools;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Ques.Mathemaitcs;
using Ques.Algorithms.Collections;


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
                if (ele == "+" || ele == "-" || ele == "*" || ele == "/")
                {
                    while (s.Any() && s.Peek() != "(" && OperatorPriority(s.Peek(), ele))
                    {
                        a.Add(s.Pop());
                    }
                    s.Push(ele);
                }
                else if (ele == "(")
                {
                    s.Push(ele);
                }
                else if (ele == ")")
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
            string sufixExpression = sb.ToString().Substring(0, sb.Length - 1);
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

        public static string _126S1 = "ACTGACG";
        public static string _126S2 = "CGACTGA";
        //1.2.6
        public static bool CircularRotation(string s1, string s2)
        {
            for (int i = 1; i < s1.Length; i++)
            {
                string sub1 = s2.Substring(0, i);
                string sub2 = s2.Substring(i, s1.Length - i);
                if (s1 == (sub2 + sub1)) return true;
            }
            return false;
        }
        public static bool CircularRotation1(string s1, string s2)
        {
            return (s1.Length == s2.Length) && (s2 + s2).Contains(s1);
        }

        //1.2.7
        public static string _127ReverseString(string s)
        {
            int N = s.Length;
            if (N == 1) return s;
            string a = _127ReverseString(s.Substring(0, N / 2));
            string b = _127ReverseString(s.Substring(N / 2, N - N / 2));
            return b + a;
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

        //This test case is just one of the real case. 
        //In real cases, it might have many results.
        public static string _1_3_9Test = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        //1.3.9 complete the infix with left parenthesis
        public static string _1_3_9_S1(string infixEx)
        {
            string[] eles = StringTool.ReadInfixArithmeticExpression(infixEx);
            Stack<string> stackEles = new Stack<string>();
            foreach (string ele in eles)
            {
                if (ele == ")")
                {
                    string n2 = stackEles.Pop();
                    string o = stackEles.Pop();
                    string n1 = stackEles.Pop();
                    string leftPart = "(" + n1 + o + n2 + ele;
                    stackEles.Push(leftPart);
                }
                else
                {
                    stackEles.Push(ele);
                }
            }
            return stackEles.Pop();
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

        //1.3.13 
        public class ResizingArrayQueueOfStrings
        {
            string[] array { get; set; }
            int N;

            public ResizingArrayQueueOfStrings()
            {
                array = new string[1];
            }

            public void Enqueue(string str)
            {
                if (N == array.Length) Resize();
                array[N++] = str;
            }

            public void Resize()
            {
                string[] newArray = new string[N * 2];
                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }

            //1.3.15 returns the k-to-last string in the queue.
            public string _1_3_15(int k)
            {
                return (array[N - k]);
            }

            public int Size()
            {
                return N;
            }
        }


        public static Node<int> _1319_DeleteTail(Node<int> node)
        {
            Node<int> first = node;
            if (node == null) throw new ArgumentNullException("Node is null");
            if (node.next == null) return null;
            while (node.next.next != null)
            {
                node = node.next;
            }
            node.next = null;
            return first;
        }
    }

    public class Date : IComparable<Date>
    {
        public string DateStringTest1 = "5/2/1939";
        private static readonly int[] DAYS = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private readonly int Month;
        private readonly int Day;
        private readonly int Year;

        public Date(int month, int day, int year)
        {
            if (!isValid(month, day, year)) throw new Exception("Invalid date");
            this.Month = month;
            this.Day = day;
            this.Year = year;
        }

        public Date(String date)
        {
            String[] fields = date.Split("/");
            if (fields.Length != 3)
            {
                throw new Exception("Invalid date");
            }
            Month = Convert.ToInt32(fields[0]);
            Day = Convert.ToInt32(fields[1]);
            Year = Convert.ToInt32(fields[2]);
            if (!isValid(Month, Day, Year)) throw new Exception("Invalid date");
        }

        public int month()
        {
            return Month;
        }

        public int day()
        {
            return Day;
        }
        public int year()
        {
            return Year;
        }

        private static bool isValid(int m, int d, int y)
        {
            if (m < 1 || m > 12) return false;
            if (d < 1 || d > DAYS[m]) return false;
            if (m == 2 && d == 29 && !isLeapYear(y)) return false;
            return true;
        }

        //These branch statements are really clever.
        private static bool isLeapYear(int y)
        {
            if (y % 400 == 0) return true;
            if (y % 100 == 0) return false;
            return y % 4 == 0;
        }

        //Returns the next date in the calendar
        public Date next()
        {
            if (isValid(Month, Day + 1, Year)) return new Date(Month, Day + 1, Year);
            else if (isValid(Month + 1, 1, Year)) return new Date(Month + 1, 1, Year);
            else return new Date(1, 1, Year + 1);
        }

        //These branch statements are really clever.
        //Program doesn't need to re-compare the year/month in the following comparing.
        //I called this Implicit Condition/Comparison.
        public int CompareTo(Date other)
        {
            if (this.Year > other.Year) return -1;
            if (this.Year < other.Year) return 1;
            if (this.Month < other.Month) return -1;
            if (this.Month > other.Month) return 1;
            if (this.Day < other.Day) return -1;
            if (this.Day > other.Day) return 1;
            return 0;
        }

        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (other == this) return true;
            if (other.GetType() != this.GetType()) return false;
            return CompareTo((Date)other) == 0;
        }

        public override int GetHashCode()
        {
            return Day + 31 * Month + 31 * 12 * Year;
        }
    }

    public class Transaction
    {
        public string TranStringTest = "Turing 5/22/1939 11.99";
        private readonly String Who;
        private readonly Date When;
        private readonly double Amount;

        public Transaction(String who, Date when, double amount)
        {
            if (Double.IsNaN(amount) || Double.IsInfinity(amount))
                throw new ArgumentException("Amount cannot be NaN or infinite");
            this.Who = who;
            this.When = when;
            this.Amount = amount;
        }

        public Transaction(string trasactionString)
        {
            string[] fields = trasactionString.Split(' ');
            Who = fields[0];
            When = new Date(fields[1]);
            Amount = Convert.ToDouble(fields[2]);
        }
    }

    class Rational : IComparable<Rational>
    {
        private long Numerator { get; set; }
        private long Denominator { get; set; }


        public Rational(long n1, long n2)
        {
            Numerator = n1;
            Denominator = n2;
            
        }
        public Rational Plus(Rational other)
        {           
           long n = this.Numerator * other.Denominator + this.Denominator * other.Numerator;
           long d = this.Denominator * other.Denominator;

           Rational rational = new Rational(n,d);
           rational.FractionSimplify();
           return rational;
        }

        public Rational Minus(Rational other)
        {
            Rational newOther = new Rational(other.Numerator * -1, other.Denominator);
            return this.Plus(newOther);
        }

        public Rational Times(Rational other)
        {
            long n = this.Numerator * other.Numerator;
            long d = this.Denominator * other.Denominator;
            Rational r = new Rational(n,d);
            r.FractionSimplify();
            return r;
        }

        public Rational Divides(Rational other)
        {
            Rational reciprocal = other.Reciprocal();
            return this.Times(reciprocal);
        }

        public Rational Reciprocal()
        {
            return new Rational(this.Denominator, this.Numerator);
        }

        public static Rational RationalTestCase(int TestCaseNum)
        {
            Rational rational = null;
            switch (TestCaseNum)
            {
                case 1:
                    {
                        rational = new Rational(8,7);
                        break;
                    }
                case 2:
                    {
                        rational = new Rational(9, 8);
                        break;
                    }
                case 3:
                    {
                        rational = new Rational(20, 3);
                        break;
                    }
                case 4:
                    {
                        rational = new Rational(14, 12);
                        break;
                    }
                case 5:
                    {
                        rational = new Rational(28, 24);
                        break;
                    }
                case 6:
                    {
                        rational = new Rational(3037141, 3247033);
                        break;
                    }
                case 7:
                    {
                        rational = new Rational(3037547, 3246599);
                        break;
                    }
                case 8:
                    {
                        rational = new Rational(0, 18);
                        break;
                    }
                case 9:
                    {
                        rational = new Rational(0, 13);
                        break;
                    }
            }
            return rational;
        }

        public void FractionSimplify()
        {
            if (this.Numerator == 0) return;
            long gcd = ElementaryMath.Euclidean(this.Numerator, this.Denominator);
            this.Numerator = this.Numerator / gcd;
            this.Denominator = this.Denominator / gcd;
        }

        public override bool Equals(Object other)
        {
            if (this == other) return true;
            if (other.GetType() != this.GetType()) return false;
            
            return this.CompareTo((Rational)other) == 0;
        }

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        public int CompareTo(Rational other)
        {
            this.FractionSimplify();
            other.FractionSimplify();
            long lhs = this.Numerator * other.Denominator;
            long rhs = this.Numerator * this.Denominator;
            if (lhs > rhs) return 1;
            if (lhs < rhs) return -1;
            return 0;
        }

        #region 1.4 Analysis of Algorithm
        public static int TwoSum()
        {
            return 0;
        }

        #endregion
    }



}
