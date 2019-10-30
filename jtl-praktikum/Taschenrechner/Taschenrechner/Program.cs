using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
                bool conversionSuccess;
                long firstValueInt;
                string InputValue;
                do
                {
                    
                    Console.Write("Erster Wert:");
                    InputValue = Console.ReadLine();
                    conversionSuccess = long.TryParse(InputValue, out firstValueInt);
                    if (!conversionSuccess)
                    {
                        Console.WriteLine("Der erste Wert ist nicht valide!");
                    }
                } while (!conversionSuccess);

                string operatorValue;
                do
                {
                    Console.Write("Operation:");
                    operatorValue = Console.ReadLine().Trim();
                    if (operatorValue == "+" || operatorValue == "-" ||
                        operatorValue == "*" || operatorValue == "/")
                    {
                        break;
                    } 
                    Console.WriteLine("Die Operation ist nicht valide!");
                    
                } while (true);

                long secondValueInt;
                do
                {
                    Console.Write("Zweiter Wert:");
                    InputValue = Console.ReadLine();
                    conversionSuccess = long.TryParse(InputValue, out secondValueInt);
                    if (!conversionSuccess)
                    {
                        Console.WriteLine("Der zweite Wert ist keine valide Zahl!");
                    }
                } while (!conversionSuccess);

                long result;
                switch (operatorValue)
                {
                    case "+":
                        result = firstValueInt + secondValueInt;
                        break;
                    case "-":
                        result = firstValueInt - secondValueInt;
                        break;
                    case "*":
                        result = firstValueInt * secondValueInt;
                        break;
                    case "/":
                        decimal result_div;
                        try
                        {
                            result_div = firstValueInt / (decimal)secondValueInt;
                        } catch (DivideByZeroException)
                        {
                            Console.WriteLine("Durch 0 teilen ist nicht möglich.");
                            continue;
                        }
                        Console.WriteLine("Das Ergebnis der Rechnung {0} {1} {2} ist {3}", firstValueInt, operatorValue, secondValueInt, result_div);
                        continue;
                    default:
                        return;
                }
                Console.WriteLine("Das Ergebnis der Rechnung {0} {1} {2} ist {3}", firstValueInt, operatorValue, secondValueInt, result);
                    
            }
        }
    }
}
