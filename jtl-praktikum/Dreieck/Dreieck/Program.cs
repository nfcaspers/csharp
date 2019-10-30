using System;

namespace Dreieck
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool isValueSet = false;
                string userInput;
                int anzahlReihen = 0;
                while (!isValueSet)
                {
                Console.Write("Reihen von Dreiecken:");
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out anzahlReihen))
                    {
                        isValueSet = true;
                    }
                }

                int dreieckTyp = 1;
                int dreieckTypErstellt = 0;
                int dreieckeProReihe = 1;
                bool reiheFertig = false;
                int erstellteReihen = 0;
                while (erstellteReihen < anzahlReihen)
                {
                    if (reiheFertig)
                    {
                        dreieckeProReihe++;
                        erstellteReihen++;
                        reiheFertig = false;
                        if (erstellteReihen == anzahlReihen)
                        {
                            return;
                        }
                    }
                    switch (dreieckTyp)
                    {
                        case 1:
                            Console.Write("#   ");
                            dreieckTypErstellt++;
                            if (dreieckTypErstellt == dreieckeProReihe)
                            {
                                reiheFertig = false;
                                Console.Write("\n");
                                dreieckTypErstellt = 0;
                                dreieckTyp = 2;
                            }
                            break;
                        case 2:

                            Console.Write("##  ");
                            dreieckTypErstellt++;
                            if (dreieckTypErstellt == dreieckeProReihe)
                            {
                                Console.Write("\n");
                                dreieckTypErstellt = 0;
                                dreieckTyp = 3;
                            }
                            break;
                        case 3:
                            Console.Write("# # ");
                            dreieckTypErstellt++;
                            if (dreieckTypErstellt == dreieckeProReihe)
                            {
                                Console.Write("\n");
                                dreieckTypErstellt = 0;
                                dreieckTyp = 4;
                            }
                            break;
                        case 4:
                            Console.Write("####");
                            dreieckTypErstellt++;
                            if (dreieckTypErstellt == dreieckeProReihe)
                            {
                                reiheFertig = true;
                                Console.Write("\n");
                                dreieckTypErstellt = 0;
                                dreieckTyp = 1;
                            }
                            break;
                    }
                }
            }
        }
    }
}
