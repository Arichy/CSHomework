using System;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 4, 2, 6, 9, 1 };

            int max = arr[0], min = arr[0], sum = 0;
            double average = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                sum += arr[i];
            }
            average = (double)sum / arr.Length;

            Console.WriteLine("最大值为{0}", max);
            Console.WriteLine("最小值为{0}", min);
            Console.WriteLine("平均值为{0}", average);
            Console.WriteLine("和为{0}", sum);
        }
    }
}
