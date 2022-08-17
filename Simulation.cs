using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques;
using System.Windows;

namespace Ques
{
    public class Simulation
    {
        //used to simulate some logistic 
        /// <summary>
        /// 羊刀模拟器 based on start speed, accelaration and time.
        /// </summary>
        /// <returns>how many times the character would hit</returns>
        public static double[] SimulateYangdao(double start, double accelaration, int time)//
        {
            double[] array = new double[2];
            double timeSum = 0;
            double hitTimes = 0;
            while (timeSum < time)
            {
                double hitTime = 1.0 / start;
                timeSum += hitTime;
                hitTimes++;
                start = start + accelaration;
                Console.WriteLine("攻击次数为" + hitTimes);
                Console.WriteLine("总攻速为" + start);
            }
            array[0] = hitTimes;
            array[1] = start;
            return array;
        }
    }

}
