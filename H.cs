using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques
{
    class H
    {
        #region 正则表达式匹配
        public bool IsMatch1(string s, string p)//这是我当时初步构想的版本 真的很难想啊这题
        {
            //上来先考虑边界情况 安全问题
            if (p == "" || (s == "" && p[1] != '*'))
            {
                return false;
            }
            //直接双指针上来扫
            int i = 0;
            int j = 0;
            bool isWildCard = false;//表示是否继续通配状态 .*
            bool[] isMatch = new bool[s.Length];//可能首先需要一个数组来记录它每个字符是否匹配 
                                                //p要处理的一共就四种情况 1.单个确定字符 2.单个任意字符 3.通配确定字符 4.通配任意字符
            while (i < s.Length || j < p.Length)
            {
                if (j + 1 <= p.Length && p[j + 1] == '*')
                {//确定字符和任意字符的通配
                    if (p[j] == '.')
                    {//通配任意字符 可以通配后方的任意字符 这就需要看.*后面的pattern了 如果再遇到.*就递归处理 但是递归处理程序跟主程序还不太一样

                    }
                    else
                    {

                        j = j + 2;

                    }
                }
                if ((j + 1 <= p.Length && p[j + 1] == '*') || (j + 1 == p.Length))
                {//单个字符
                    if (p[j] == '.')
                    {//任意字符
                        isMatch[i] = true;
                    }
                    else
                    {//确定字符
                        if (s[i] == s[j])
                        {
                            isMatch[i] = true;
                        }
                    }
                    i++;
                    j++;
                }
            }
            return false;
        }

        //下面这个函数展示了思考过程 IsMatch Process 1
        public bool IsMatchP1(string s, string p)//首先如果不考虑*通配符 直接一路匹配过去就行了
        {
            int i = 0;
            int j = 0;
            while (i<s.Length && j <s.Length){//必须要两个都满足
                if (s[i] == p[j] || p[j] == '.') { i++; j++; }
                else { return false; }
            }
            return i ==  j;//有两个指标可以判断是否匹配 1.两个都走到了尽头还没返回false 那肯定是true 2.如果两个都走到尽头 由于是一对一匹配的 所以长度肯定相等
        }

        public static bool IsMatchP2(string s, string p)//如果考虑* 分情况讨论 没必要一开始就通用代码写到底 先写分支 发现能够合并就合并
        {
            int i = 0;
            int j = 0;
            bool[] isWildCard = new bool[s.Length];
            //判断两个字符串是否匹配的标准要确定 就是 i和j都走到了最后 就能匹配 之前提前返回的 都不匹配
            //你一开始分情况是分p的情况 还有其他思路 比如直接s和p一起比较的情况
            //有哪些分类 先把基本的流程想一遍 在流程中 哪些条件是影响分支的 都可以作为分类条件 
            //像这里的 指针所指向的字符是否匹配 也是分类条件之一 只不过在某些分支当中 作为隐式条件
            while (i < s.Length && j < p.Length)
            {
                if (s[i] == p[j] || p[j] == '.')//指针所指向的字符是否匹配又包括两个部分 相等或者p[j]是通配'.'
                {
                    if ( j+1 <= p.Length && p[j+1] == '*' )//这种情况就可以匹配任意个了
                    {
                        //有通配符 可以匹配任意个 到底匹配多少个 看它后面情况
                        if (j + 1 < p.Length - 1)//1.j后面还有模式子串要匹配
                        {
                            if (p[j] == '.')//1.[.*] 形式 中间可以任意 后面递归调用
                            {
                                string p1 = p.Substring(j+2,s.Length - j - 2);
                                int k = i;
                                for(;k < s.Length; k++){
                                    string s1 = s.Substring(k,s.Length - k);
                                    if (IsMatchP2(s1,p1))
                                    {
                                        return true;//只要后面的模式串能匹配某段结尾子串 那一定匹配了
                                    }
                                }
                            }
                            else//2. [字母*]形式 中间不能任意 可以是0或者n个该字母
                            {

                            }
                        }
                        else //2.j后面没有模式子串要匹配
                        {
                            if (p[j] == '.')//1.如果是.*形式 那就直接结束了
                            {
                                return true;
                            }
                            else//2.如果不是 继续往后判断就行
                            {
                                i++;
                            }
                        }
                    }
                    else//没有通配符 只匹配1个
                    {
                        i++; j++;
                    }
                }
                else//不匹配 还是要看是否有通配符*
                {
                    if (j+1 <= p.Length && p[j+1] == '*')//下一个字符有通配符*的话 可以匹配0或多个
                    {
                        
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return i == s.Length && j == p.Length;
            //最后的分析 循环是穷举 分支是选择 所以就可以用动态规划 状态是指针i,j 选择是p[j]能匹配多少个
        }

        //直接用动态规划吧
        public static bool DPIsMatch(string s, string p,int i,int j)//这个状态转移函数表示子串s[i..]能否与p[j..]相匹配
        {
            while ( i < s.Length && j < p.Length)
            {
                if (s[i] == p[j] || p[j] == '.')
                {

                }
                else
                {

                }
            }
            //对于base case 总共有两种情况能匹配
            if ( i == s.Length)
            {
                
            }
            return false;
        }
        #endregion

        public static int _135_Candy(int[] ratings)
        {
            int n = ratings.Length;
            for (int i = 0; i < n;i++)
            {

            }
            for (int i = n-1; i>=0; i--)
            {

            }
            return 0;
        }
    }
}
