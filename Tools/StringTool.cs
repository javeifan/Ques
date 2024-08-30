using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Tools
{
    class StringTool
    {
        //Reads ArithmeticExpression including  + - * / sqr decimal and int
        //Returns the string[] contains each individual number or operator
        public static string[] ReadInfixArithmeticExpression(string expression)
        {
            List<string> eles = new List<string>();
            foreach (char c in expression)
            {
                string lastS = "";
                if (eles.Any()) lastS = eles.Last();
                if (c == ' ') continue;
                else if (c == '+' || c == '-' || c == '*' || c == '/') eles.Add(c.ToString());
                else if (c == '.' || (containsNum(c.ToString()) && containsNum(lastS))) eles[eles.Count - 1] = lastS + c;
                else if (lastS == "s" || lastS == "sq" || lastS == "sqr") eles[eles.Count - 1] = lastS + c;
                else eles.Add(c.ToString());
            }
            return eles.ToArray();
        }
        
        public static bool containsNum(string s)
        {
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9') return true;
            }
            return false;
        }

        public static char[] GetRandomAlphabetChars(int count, bool isDifferent)
        {
            char[] chars = new char[count];
            if (isDifferent)
            {
                char[] alphabet = new char[26];

            }
            return chars;
        }
    }
}
