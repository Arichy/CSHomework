using System;
using System.Timers;

namespace Clock
{
    class Event
    {
        public delegate void Handler();

        public event Handler printTime;

        public void timeout()
        {
            printTime();
        }
    }

    class Subscribe
    {
        public void printf()
        {
            Console.WriteLine("闹钟时间到了");
            Console.ReadKey();
        }

    }
    class Program
    {
        static Timer t = new Timer(1000); // 定时器
        static int hour, min, second; // 设定的时间

        static Event e = new Event(); // 事件
        static Subscribe sub = new Subscribe(); //委托
        static void Main(string[] args)
        {
            // 设置闹钟时间
            Program.setTime();
            // 注册事件
            e.printTime += new Event.Handler(sub.printf);
            // 设置定时器
            t.Enabled = true;
            t.Elapsed += Program.T_Elapsed;
            Console.Read();
        }

        // 设置闹钟时间
        public static void setTime()
        {
            Console.WriteLine("请输入闹钟：时");
            hour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入闹钟：分");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入闹钟：秒");
            second = Convert.ToInt32(Console.ReadLine());
        }

        // 获取当前时间
        public static int[] getNowTime()
        {
            return new int[3] {
                Convert.ToInt32(DateTime.Now.Hour.ToString()) ,
                Convert.ToInt32(DateTime.Now.Minute.ToString()),
                Convert.ToInt32(DateTime.Now.Second.ToString())
            };
        }

        // 定时器函数
        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            int[] nowTime = Program.getNowTime();
            Console.WriteLine("当前时间:" + nowTime[0] + "点" + nowTime[1] + "分" + nowTime[2] + "秒");

            // 时间到了
            if (nowTime[0] == hour && nowTime[1] == min && nowTime[2] == second)
            {
                // 触发事件
                Program.e.timeout();
                // 关闭定时器
                Program.t.Enabled = false;
            }
        }

    }
}
