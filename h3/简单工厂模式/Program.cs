using System;
using Food;

namespace 简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ((Rice)Factory.produceFood("米饭")).say();
            ((Bread)Factory.produceFood("面包")).say();
            ((Chicken)Factory.produceFood("鸡肉")).say();
        }
    }
}
