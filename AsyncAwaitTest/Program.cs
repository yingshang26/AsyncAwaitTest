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
            MakeBreakfast();
            Console.Read();
        }

        private static async void MakeBreakfast()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            var eggTask = FryEggAsync();
            var baconTask = FryBaconAsync();
            var toastTask = MakeToastWithButterAndJamAsync();
     
            Egg egg = await eggTask;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Toast toast = await toastTask;
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
            watch.Stop();
            Console.WriteLine($"总共花费时间：{watch.ElapsedMilliseconds}");
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

        //与任务组合
        private static async Task<Toast> MakeToastWithButterAndJamAsync()
        {
            var toast = await ToastBreadAsync();
            ApplyJam(toast);
            ApplyButter(toast);
            return toast;
        }

        private static Task<Toast> ToastBreadAsync()
        {
            return Task<Toast>.Factory.StartNew(ToastBread);
        }

        private static Toast ToastBread()
        {
            Console.WriteLine($"Making Toast");
            Thread.Sleep(3000);
            return new Toast();
        }

        private static Task<Bacon> FryBaconAsync()
        {
            return Task<Bacon>.Factory.StartNew(FryBacon);
        }

        private static Bacon FryBacon()
        {
            Console.WriteLine($"Making Bacon");
            Thread.Sleep(2000);
            return new Bacon();
        }

        private static Task<Egg> FryEggAsync()
        {
            return Task<Egg>.Factory.StartNew(FryEggs);
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
