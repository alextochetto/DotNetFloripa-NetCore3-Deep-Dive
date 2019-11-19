using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncIterators
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await Demo();

            Console.ReadKey();
        }

        public static async Task Demo()
        {
            await foreach (var number in GerarSequencia())
            {
                Console.WriteLine($"Agora são: {DateTime.Now:hh:mm:ss.fff}. Número: {number}");
            }
        }

        private static async IAsyncEnumerable<int> GerarSequencia()
        {
            for (var i = 0; i < 50; i++)
            {
                // a cada 10 elementos aguarda 2s
                if (i % 10 == 0)
                {
                    Console.WriteLine($"Bloco processado.");
                    await Task.Delay(2000);
                }
                yield return i;
            }
        }
    }
}
