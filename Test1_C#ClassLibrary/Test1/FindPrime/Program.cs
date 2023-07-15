using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("小于100的素数有：");
            for (int i = 2; i <= 100; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    //如果能被小于它的数整除，则不是素数
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    //输出素数
                    Console.WriteLine("{0}", i);
                }
            }
        }
    }
}
