using System;

namespace Food
{
    public class Food
    {
        public void say() { }
    }
    public class Bread : Food
    {
        public new void say()
        {
            Console.WriteLine("我是面包");
        }
    }

    public class Chicken : Food
    {
        public new void say()
        {
            Console.WriteLine("我是鸡肉");
        }
    }

    public class Rice : Food
    {
        public new void say()
        {
            Console.WriteLine("我是米饭");
        }
    }
}
