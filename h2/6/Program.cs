using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个正整数:");
            string str = Console.ReadLine();
            int num = Convert.ToInt32(str);

            Console.WriteLine("他的素数因子为:");
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0 && Program.judge(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool judge(int num)// 判断是否为素数
        {
            if (num <= 2)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
