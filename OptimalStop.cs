using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Ques
{
    class OptimalStop
    {
        public void Simulate()
        {

            int maxTimes=0;
            double possibility = 0;
            for (int i = 0; i < 100000; i++)
            {
                List<int> randomSecretariesList = Get100RandomSecretaries();
                int result = GetTheSecretaryByThreshold(50, randomSecretariesList);
                //Console.WriteLine("Max of the Whole Algorithm : " + result);
                if (result == 100)
                {
                    maxTimes++;
                }
            }
            
            possibility = maxTimes * 1.00 / 100000;
            Console.WriteLine("The Times with ideal result are " + maxTimes);
            Console.WriteLine("The posibility of 37% Rule to get the best secretary is :" + possibility);
        }

        // Get 100 Secretaries with ids(index) and ranks.
        public List<int> Get100RandomSecretaries()
        {
            Random random = new Random();
            List<int> auxiliaryList = new List<int>();
            List<int> secList = new List<int>();
            string secListStr = "[";
            for (int i = 0; i < 100; i++)
            {
                auxiliaryList.Add(i+1);
            }
            for (int i = 0; i < 100; i++)
            {
                int randomRank = random.Next(0,100-i);
                secList.Add(auxiliaryList[randomRank]);
                auxiliaryList.RemoveAt(randomRank);
                if (i!=99)
                {
                    secListStr += secList[i] + ",";
                }
                else
                {
                    secListStr += secList[i] + "]";
                }
            }
           // Console.WriteLine(secListStr);
            return secList;
        }

        //Threashold should be greater than 1 and less than 
        public int GetTheSecretaryByThreshold(int threashold, List<int> secretaryRankList)
        {
            int maxRankBeforeThreashold = 0;
            int finalresult = 0;
            
            for (int i = 0; i <= threashold; i++)
            {
                if (secretaryRankList[i] > maxRankBeforeThreashold)
                {
                    maxRankBeforeThreashold = secretaryRankList[i];
                }
            }
            Console.WriteLine("MaxBeforeThreashold : "+maxRankBeforeThreashold);
            for (int i = threashold; i < secretaryRankList.Count; i++)
            {
                if (secretaryRankList[i]>maxRankBeforeThreashold)
                {
                    finalresult = secretaryRankList[i];
                    break;
                }
                else
                {
                    finalresult = secretaryRankList[i];
                }
            }
            
            return finalresult;
        }
    }

 
}
