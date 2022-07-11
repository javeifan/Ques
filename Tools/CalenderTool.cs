using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Tools
{
    class CalenderTool
    {
        //subtract days by Date
        //Date should conform to such format yyyy-mm-dd
       public static DateTime DateSubtract(string Date,int days)//allow negative number
        {
            DateTime newDateTime = new DateTime();
            try
            {
                int year = Convert.ToInt32(Date.Split("-")[0]);
                int month = Convert.ToInt32(Date.Split("-")[1]);
                int date = Convert.ToInt32(Date.Split("-")[2]);
                string newDate = RecursiveDateSubtract(year, month, date, days);
                newDateTime = Convert.ToDateTime(newDate);
            }
            catch { }//catch the parse exception
            return newDateTime;
        }
        public static string RecursiveDateSubtract(int year,int month,int date,int days)
        {
            string NewDate = "";
            bool IsLeap;
            if (days < date)
            {
                date = date - days;
                NewDate = year + "-" + month + "-" + date;
            }
            else//factoring in the leap year, a leap year is:
                //non integral hundred years : can be divided by 4
                //integral hundred years: can be divided by 400
            {
                int difference = days - date;
                if (month == 1)
                {
                    month = 13;
                    year -= 1;
                }
                month -= 1;
                date = MonthDays(year,month);
                NewDate = RecursiveDateSubtract(year,month,date,difference);
            }
            return NewDate;
        }
        public static bool IsLeap(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            return false;
        }

        public static int MonthDays(int year,int month)
        {
            int days = 31;
            switch (month)
            {
                case 2: {
                        if (IsLeap(year)){ days = 29; }
                        else{ days = 28; }
                        break; 
                    } 
                case 4: days = 30; break;
                case 6: days = 30; break;
                case 9: days = 30; break;
                case 11: days = 30; break;
            }
            return days;
        }


    }
}
