using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! I'll try show you how to run sync method like async method :-) ");
            var repo = new MyClass();
            
            DateTime start = DateTime.Now;
            int sum = repo.GetSomeSum();
            Console.WriteLine($"Time span for synchronous method: {DateTime.Now - start}");

            DateTime start2 = DateTime.Now;
            sum = repo.GetSomeSumAsync();
            Console.WriteLine($"Time span for Async method: {DateTime.Now - start2}");
        }
    }

    public class MyClass
    {
        public int GetSomeSum()
        {
            return getNumber() + getNumber();
        }

        public int GetSomeSumAsync()
        {
            var number1 = Task.Run(() => {
                    return getNumber(); 
                 });
            var number2 = Task.Run(() => { 
                    return getNumber(); 
                });
            return number1.GetAwaiter().GetResult() + number2.GetAwaiter().GetResult();
        }

        private int getNumber()
        {
            //Code below simulate long time working some process
            var start = DateTime.Now;
            var val = 0;
            while (DateTime.Now < start.AddSeconds(2))
            {
                val = new Random(10).Next();
            }
            return val;
        }
    }

}
