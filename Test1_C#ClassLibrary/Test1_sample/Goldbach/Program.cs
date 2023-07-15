using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldbach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("大于2的偶数都可写成两个素数之和?");
            List<int> liPrime = new List<int>(); //不定长素数数组List
            for (int i = 2; i <= 100; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    liPrime.Add(i);     //找到素数
                }
                if (i > 2 && i % 2 == 0)//大于2的偶数
                {
                    bool bGuess = false;
                    foreach (int m in liPrime)
                    {
                        foreach (int n in liPrime)
                        {
                            if (m + n == i)
                            {
                                bGuess = true;
                                Console.WriteLine("{0}={1}+{2}", i, m, n);
                                break;
                            }
                        }
                        if (bGuess)
                        {
                            break;
                        }
                    }
                    if (!bGuess)
                    {
                        Console.WriteLine("The guess is false.");
                    }
                }
            }
        }
    }
}
