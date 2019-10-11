using System;

namespace DataTypeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size of int: {0}", sizeof(int));
            int x = 100;
            int y = 200;
            Console.WriteLine("Product of x and y is: {0}", x+y);

            //Booleans
            bool bool_value = true;
            if (bool_value == true) 
            {
                Console.WriteLine("Boolean is true");
            }

            //unsigned types 
            uint unsigned_number = 12;
            ushort unsigned_short_number = 6;
            ulong unsigned_long_number = 18;

            //signed types 
            int number = +45;
            short short_number = -20;
            long long_number = -60;

            //bytes
            byte computer_number = 64;
            sbyte signed_computer_number = -84;

            //boxing & unboxing
            object boxed_number = number;
            int unboxed_number = (int)boxed_number;
        }
    }
}
