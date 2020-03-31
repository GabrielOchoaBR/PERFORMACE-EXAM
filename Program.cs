using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = { 1, 2, 1, 2, 1, 2, 1, 2 };
            //int[] A = { 1, 3, 4, 2, 2, 2, 1, 1, 2, 0 };
            //int[] A = { 1, 1, 1, 1, 1 };
            //int[] A = { 1, 3, 4, 2, 2, 2, 1, 1, 2 };
            int[] A = new int[20000];

            //Super Array
            for (int i = 0; i < 20000; i++)
                A[i] = (i % 2) + 1;

            //Tester.
            Stopwatch clock = new Stopwatch();
            clock.Start();

            Console.WriteLine(loadBalancerRecursive(A, 2));
            
            Console.WriteLine(clock.ElapsedMilliseconds);
        }


        /// <summary>
        /// Split array N parts with the same sum value
        /// </summary>
        /// <param name="array">Current Array</param>
        /// <param name="deepLevel">Recursive level</param>
        /// <param name="sumParted">Actual Sum of the array itens</param>
        /// <param name="currentIndex">Current Item Index</param>
        /// <returns></returns>
        private static bool loadBalancerRecursive(int[] array, int deepLevel, int? sumParted = null, int currentIndex = 0)
        {
            int length = array.Length;
            int currentSum = 0;

            for (int i = currentIndex + (Convert.ToInt32(sumParted != null) * 2); i < length; i++)
            {
                currentSum += array[i];

                if (currentSum > sumParted)
                    return false;

                else if (currentSum == sumParted || sumParted == null)
                {
                    if (deepLevel != 0 && loadBalancerRecursive(array, deepLevel - 1, sumParted, i))
                        return true;

                    else if (deepLevel == 0 && i == length - 1)
                        return true;
                }
            }

            return false;
        }
    }
}

