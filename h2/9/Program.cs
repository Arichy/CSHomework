using System;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[101];
            for (int i = 0; i < 101; i++)
            {
                arr[i] = 1;
            }

            for (int i = 2; i <= 100; i++)
            {
                for (int j = i + 1; j <= 100; j++)
                {
                    if (j % i == 0)
                    {
                        arr[j] = 0;
                    }
                }
            }

            for (int i = 2; i < 101; i++)
            {
                if (arr[i] == 1)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
