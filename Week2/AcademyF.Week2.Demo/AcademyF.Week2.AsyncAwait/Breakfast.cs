using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.AsyncAwait
{
    public class Breakfast
    {
        //MODALITA' SINCRONE
        //public static async Task PrepareBreakfastAsync()
        //{
        //    Stopwatch timer = Stopwatch.StartNew(); //facciamo partire il timer per cronometrare le operazioni
        //    //Coffee cup = PourCoffee();
        //    Coffee cup = await PourCoffeeAsync();
        //    Console.WriteLine("Coffee is ready");

        //    //Egg eggs = FryEggs(2);
        //    Egg eggs = await FryEggsAsync(2);

        //    //Bacon bacon = FryBacon(3);
        //    Bacon bacon = await FryBaconAsync(3);

        //    //Toast toast = ToastBread(2);
        //    Toast toast = await ToastBreadAsync(2);

        //    ApplyButter(toast);
        //    ApplyJam(toast);

        //    Juice orangeJuice = PourOJ();
        //    Console.WriteLine("The orange juice is ready");
        //    Console.WriteLine("Breakfast is ready!");
        //    Console.WriteLine($"It tooks {timer.ElapsedMilliseconds} ms");
        //}

        //MODALITA' ASINCRONA
        public static async Task PrepareBreakfastAsync()
        {
            Stopwatch timer = Stopwatch.StartNew();
            Task<Coffee> cup = PourCoffeeAsync();
            Console.WriteLine("Coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toast is ready");

            Egg eggs = await eggsTask;
            Console.WriteLine("Eggs are ready");
            Bacon bacon = await baconTask;
            Console.WriteLine("Bacon is ready");

            Juice oj = PourOJ();
            Console.WriteLine("Oj is ready");

            Console.WriteLine("Breakfast is ready");
            Console.WriteLine($"It tooks {timer.ElapsedMilliseconds}ms");

        }


        private static async Task<Toast> ToastBreadAsync(int howMany)
        {
            for (int slice = 0; slice < howMany; slice++)
            {
                Console.WriteLine("Putting a slide of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Put {slices} slices of bacon in the pan");
            Console.WriteLine("Cooking first side of bacon");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking second side of bacon");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait(); //metto in attesa il metodo che è in esecuzione
            Console.WriteLine($"Cracking {howMany} eggs");
            Console.WriteLine("Cooking the eggs");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs in plate");
            return new Egg();
        }

        private static async Task<Coffee> PourCoffeeAsync()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }

        private static Toast ToastBread(int howMany)
        {
            for(int slice = 0; slice < howMany; slice++)
            {
                Console.WriteLine("Putting a slide of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"Put {slices} slices of bacon in the pan");
            Console.WriteLine("Cooking first side of bacon");
            Task.Delay(3000).Wait();
            for(int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking second side of bacon");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait(); //metto in attesa il metodo che è in esecuzione
            Console.WriteLine($"Cracking {howMany} eggs");
            Console.WriteLine("Cooking the eggs");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs in plate");
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}
