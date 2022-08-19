using System;


namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Simulation.SimulateYangdao(1.0, 0.06, 30);
            Console.WriteLine("攻击次数为" + array[0]);
            Console.WriteLine("总攻速为" + array[1]);
        }

        static void  TraverseArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+ " ");
            }
            Console.WriteLine("");
        }

        
    }
}
