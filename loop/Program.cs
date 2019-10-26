using System;

namespace loop
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("First loop finished.");

            int n = 0;
            while (n < 10) 
            {
                Console.WriteLine(n);
                n++;
            }
            Console.WriteLine("Second loop finished.");

            int c = 0;
            do {
                Console.WriteLine(c);
                c++;
            } while (c > 10);
            Console.WriteLine("Third loop finished.");

            string[] x = new string[] {"Hello", ",", "world", "!\n"};
            foreach (string element in x) {
                Console.Write(element);
            }
            Console.WriteLine("Fourth loop finished");
        }
    }
}
