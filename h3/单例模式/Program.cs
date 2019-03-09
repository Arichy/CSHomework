using System;

public class Singleton
{
    private Singleton()
    {
        Console.WriteLine("单例实例已被加载");
    }

    private static Singleton single = new Singleton();

    public static Singleton getInstance()
    {
        return single;
    }

    public void say(){
        Console.WriteLine("我是单例实例");
    }

}

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton single = Singleton.getInstance();
            single.say();
        }
    }
}
