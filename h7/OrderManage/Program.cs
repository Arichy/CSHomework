using System;
using System.Collections;

namespace OrderManage
{
    class Item
    {
        public string itemName;
        public int itemNum;

        public Item(string name, int num)
        {
            itemName = name;
            itemNum = num;
        }
    }
    class Order
    {
        public static int orderIdIndex = 0;
        public int orderId;
        public string customer;
        public OrderDetails details = null;

        public Order(string customer)
        {
            this.orderId = ++orderIdIndex;
            this.customer = customer;
            this.details = new OrderDetails();
        }

        public void print() // 打印自己
        {
            Console.WriteLine("订单编号:" + this.orderId + "\t" + "客户:" + this.customer);
            foreach (Item item in this.details.itemList)
            {
                Console.Write(item.itemName + ":" + item.itemNum + "件\t");
            }
            Console.WriteLine("\n");
        }
    }
    class OrderDetails
    {
        public ArrayList itemList = new ArrayList(); // 保存该订单商品的数组
    }

    class OrderService
    {
        public ArrayList orderList = new ArrayList(); // 保存订单的数组

        // 通过订单号找到订单
        public Order getOrderById(int id)
        {
            foreach (Order order in this.orderList)
            {
                if (order.orderId == id)
                {
                    return order;
                }
            }

            return null;
        }


        public void addOrder() // 添加订单
        {
            Console.WriteLine("请输入商品种类数:");
            int itemType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入客户名字:");
            string customer = Console.ReadLine();

            Order order = new Order(customer);

            for (int i = 0; i < itemType; i++)
            {
                Console.WriteLine("请输入商品名字:");
                string itemName = Console.ReadLine();
                Console.WriteLine("请输入该商品的数量:");
                int itemNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(itemName + ":" + itemNum + "件");
                Item item = new Item(itemName, itemNum);
                order.details.itemList.Add(item);
            }

            this.orderList.Add(order);
        }

        public void deleteOrder()// 删除订单
        {
            foreach (Order order in this.orderList)
            {
                order.print();
            }
            Console.WriteLine("请输入要删除的订单编号:");
            int orderId = Convert.ToInt32(Console.ReadLine());

            Order target = this.getOrderById(orderId);

            if (target == null)
            {
                throw (new Exception("该订单编号不存在"));
            }
            else
            {
                this.orderList.Remove(target);
            }

        }

        public void modifyOrder()// 修改订单
        {
            foreach (Order order in this.orderList)
            {
                order.print();
            }
            Console.WriteLine("请输入要修改的订单编号:");
            int orderId = Convert.ToInt32(Console.ReadLine());

            Order target = this.getOrderById(orderId);

            if (target == null)
            {
                throw (new Exception("该订单编号不存在"));
            }
            else
            {
                Console.WriteLine("请输入要修改的信息:");
                Console.WriteLine("1.客户名字 2.商品信息");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("请输入新的客户名:");
                    string newName = Console.ReadLine();
                    target.customer = newName;
                }
                else
                {
                    Console.WriteLine("请输入要修改的商品的名字:");
                    string itemName = Console.ReadLine();

                    Item targetItem = null;
                    foreach (Item item in target.details.itemList)
                    {
                        if (item.itemName == itemName)
                        {
                            targetItem = item;
                        }
                    }
                    if (targetItem == null)
                    {
                        throw (new Exception("该商品不存在"));
                    }
                    else
                    {
                        Console.WriteLine("请输入要修改的商品的信息:");
                        Console.WriteLine("1.商品名字 2.商品数量");

                        int input2 = Convert.ToInt32(Console.ReadLine());
                        if (input2 == 1)
                        {
                            Console.WriteLine("请输入要新的商品名字:");
                            string newItemName = Console.ReadLine();
                            targetItem.itemName = newItemName;
                        }
                        else
                        {
                            Console.WriteLine("请输入要新的商品数量:");
                            int newItemNum = Convert.ToInt32(Console.ReadLine());
                            targetItem.itemNum = newItemNum;
                        }
                    }
                }
            }

        }

        public void queryOrder()// 查询订单
        {
            Console.WriteLine("按照什么字段查询？");
            Console.WriteLine("1.订单号 2.商品名称 3.客户名称");
            int input = Convert.ToInt32(Console.ReadLine());
            ArrayList result = new ArrayList();

            switch (input)
            {
                case 1:
                    Console.WriteLine("请输入订单号:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Order target = this.getOrderById(id);
                    if (target == null)
                    {
                        throw (new Exception("该订单号不存在"));
                    }
                    else
                    {
                        result.Add(target);
                    }

                    break;

                case 2:
                    Console.WriteLine("请输入商品名称:");
                    string itemName = Console.ReadLine();

                    foreach (Order order in this.orderList)
                    {
                        foreach (Item item in order.details.itemList)
                        {
                            if (item.itemName == itemName)
                            {
                                result.Add(order);
                            }
                        }
                    }

                    break;

                case 3:
                    Console.WriteLine("请输入客户名:");
                    string customer = Console.ReadLine();

                    foreach (Order order in this.orderList)
                    {
                        if (order.customer == customer)
                        {
                            result.Add(order);
                        }
                    }

                    break;
            }
            Console.WriteLine("查询结果为:");
            if (result.Count == 0)
            {
                Console.WriteLine("无符合要求的结果");
            }
            foreach (Order order in result)
            {
                order.print();
            }
        }
    }
    class Program
    {
        public static OrderService os = new OrderService();
        static void Main(string[] args)
        {
            // OrderService os = new OrderService();
            test();
        }

        static void showTip()
        {
            Console.WriteLine("\n请输入要选的功能:");
            Console.WriteLine("1.添加订单 2.删除订单 3.修改订单 4.查询订单 5.退出程序");
        }

        public static void test()
        {
            Order order = new Order("小明");
            order.details.itemList.Add(new Item("苹果", 13));
            order.details.itemList.Add(new Item("草莓", 13));

            os.orderList.Add(order);

            showTip();
            Console.WriteLine("请依次输入序号来测试功能是否正确.");
            int index = Convert.ToInt32(Console.ReadLine());
            while (index != 5)
            {
                showTip();
                switch (index)
                {
                    case 1:
                        os.addOrder();
                        break;
                    case 2:
                        try
                        {
                            os.deleteOrder();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 3:

                        try
                        {
                            os.modifyOrder();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case 4:
                        try
                        {
                            os.queryOrder();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                }
                showTip();
                index = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
