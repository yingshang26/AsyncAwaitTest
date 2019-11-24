using System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Egg eggs = FryEggs();
            Console.WriteLine("eggs are ready");
            Bacon bacon = FryBacon();
            Console.WriteLine("bacon is ready");
            Toast toast = ToastBread();
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
            watch.Stop();
            Console.WriteLine($"总共花费时间：{watch.ElapsedMilliseconds}");
            Console.ReadLine();
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring Juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Applying Jam to Toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Applying Butter to Toast");
        }

        private static Toast ToastBread()
        {
            Console.WriteLine($"Making Toast");
            Thread.Sleep(300);
            return new Toast();
        }

        private static Bacon FryBacon()
        {
            Console.WriteLine($"Making Bacon");
            Thread.Sleep(200);
            return new Bacon();
        }

        private static Egg FryEggs()
        {
            Console.WriteLine($"Making Eggs ");
            Thread.Sleep(1000);
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Making Coffee");
            return new Coffee();
        }

    }
}
