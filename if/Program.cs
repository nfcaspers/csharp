using System;

namespace ifApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number greater than 16: ");
            String user_input = Console.ReadLine();
            int user_input_int;
            bool conversion_success = Int32.TryParse(user_input, out user_input_int);
            if (conversion_success) 
            {
                if (user_input_int > 16) 
                {
                    Console.WriteLine("The number {0} is greater than 16!", user_input_int);
                } else 
                {
                    Console.WriteLine("The number {0} is smaller than 16!", user_input_int);
                }
            } else 
            {
                Console.WriteLine("Conversion of input failed.");
            }
        }
    }
}
