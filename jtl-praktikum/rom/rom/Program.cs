using System;

namespace rom
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool isValueCorrect=false;
                string UserInput;
                int NumericValue;
                do
                {
                    Console.Write("Bis zu Vierstellige Nummer:");
                    UserInput = Console.ReadLine().Trim();
                    if (!int.TryParse(UserInput, out NumericValue))
                    {
                        Console.WriteLine("Eingabe ist invalid!");
                        continue;
                    } else if (NumericValue > 9999)
                    {
                        Console.WriteLine("Es sind nur Zahlen bis zu Vier Stellen erlaubt!");
                        continue;
                    } else if (NumericValue == 0)
                    {
                        Console.WriteLine("0 ist nicht in römischen Zahlen darstellbar!");
                        continue;
                    }
                    isValueCorrect = true;
                } while (!isValueCorrect);

                string RomanNumber = "";
                do
                {
                    switch (NumericValue)
                    {
                        case int _ when NumericValue >= 1000:
                            NumericValue -= 1000;
                            RomanNumber += "M";
                            break;
                        case int _ when NumericValue >= 900: //Subtraktionsregel
                            NumericValue -= 900;
                            RomanNumber += "CM";
                            break;
                        case int _ when NumericValue >= 500:
                            NumericValue -= 500;
                            RomanNumber += "D";
                            break;
                        case int _ when NumericValue >= 400: //Subtraktionsregel
                            NumericValue -= 400;
                            RomanNumber += "CD";
                            break;
                        case int _ when NumericValue >= 100:
                            NumericValue -= 100;
                            RomanNumber += "C";
                            break;
                        case int _ when NumericValue >= 90: //Subtraktionsregel
                            NumericValue -= 90;
                            RomanNumber += "XC";
                            break;
                        case int _ when NumericValue >= 50:
                            NumericValue -= 50;
                            RomanNumber += "L";
                            break;
                        case int _ when NumericValue >= 40: //Subtraktionsregel
                            NumericValue -= 40;
                            RomanNumber += "XL";
                            break;
                        case int _ when NumericValue >= 10:
                            NumericValue -= 10;
                            RomanNumber += "X";
                            break;
                        case int _ when NumericValue >= 9: //Subtraktionsregel
                            NumericValue -= 9;
                            RomanNumber += "IX";
                            break;
                        case int _ when NumericValue >= 5:
                            NumericValue -= 5;
                            RomanNumber += "V";
                            break;
                        case int _ when NumericValue >= 4: //Subtraktionsregel
                            NumericValue -= 4;
                            RomanNumber += "IV";
                            break;
                        case int _ when NumericValue >= 1:
                            NumericValue -= 1;
                            RomanNumber += "I";
                            break;
                    }
                } while (NumericValue > 0);
                Console.WriteLine("{0} ist als römische Zahl: {1}", UserInput, RomanNumber);
            }
        }
    }
}
