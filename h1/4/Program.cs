using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个整数:");
            string input1 = Console.ReadLine();
            int num1 = Convert.ToInt32(input1);

            Console.WriteLine("请输入第二个整数:");
            string input2 = Console.ReadLine();
            int num2 = Convert.ToInt32(input2);

            Console.WriteLine("相乘的结果为:");
            Console.WriteLine(num1*num2);
        }
    }
}
