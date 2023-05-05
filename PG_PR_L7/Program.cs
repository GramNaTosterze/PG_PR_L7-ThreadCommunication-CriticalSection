using System;
using System.Threading;
using System.Collections.Generic;


namespace PG_PR_L7
{
    class MainClass
    {
        public static List<int> sharedList = new List<int>();
        public static void Main(string[] args)
        {
            var thread1 = new Thread(() => Task("1"));
            var thread2 = new Thread(() => Task("2"));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
        public static void Task(string thread)
        {
            while(true)
            {
                int number = new Random().Next(10000);
                lock(sharedList)
                {
                    if (!sharedList.Contains(number))
                    {
                        Console.WriteLine($"{thread} - {number}");
                        sharedList.Add(number);
                    }
                    else
                    {
                        Console.WriteLine($"{thread} - Konflikt:{number}");
                    }
                }
            }
        }
    }
}
