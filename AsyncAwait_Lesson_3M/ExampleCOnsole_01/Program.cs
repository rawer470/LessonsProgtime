using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleCOnsole_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SyncMath();
            //Task.Run(AsyncMath);
            //AsyncWriteBook();
           
            Console.Read();
        }

        static void SyncMath()
        {
            Math();
        }
        static  async Task AsyncMath()
        {
            await Task.Run(Math);
            Console.WriteLine("Я всё сделал");
        }

        static  async Task<int> AsyncAdd()
        {
            int a = 12;
            int b =13;

         int res =  await Task.Run(() => Add(a, b));
        return res;
        }

        static async Task AsyncWriteBook()
        {
            string text = "Когда второй выпуск?  не знаю...";
         await Task.Run(() => WriteBook(text));
            Console.WriteLine("I`m written book");
        }

        static int Add(int a,int b)
        {
            Console.WriteLine("Start Add");
            Thread.Sleep(5000);
            Console.WriteLine("Finish Add");
            return a + b;
        }

        static void WriteBook(string text)
        {
            Console.WriteLine("Start WriteBook");
            Thread.Sleep(5000);
            Console.WriteLine("Finish WriteBook");
            Console.WriteLine($"Text: {text}");
        }

        static void Math()
        {
            Console.WriteLine("Start Math");
            Thread.Sleep(5000);
            Console.WriteLine("Finish Math");
        }
    }
}
