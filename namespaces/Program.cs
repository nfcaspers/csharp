using System;
using AddOperation;

namespace namespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int result = Adder.add(100, 200);
            Console.WriteLine("Result is {0}", result);
        }
    }
}
