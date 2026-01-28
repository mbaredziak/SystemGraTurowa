using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graTurowa
{
    public static class CharCreator
    {
        public static Player Create()
        {
            Console.WriteLine("--- TWORZENIE POSTACI ---");

            Console.Write("Podaj imię: ");
            string name = Console.ReadLine();

            Stats choosenClass = null;
            ConsoleColor color = ConsoleColor.Black;

            while (choosenClass == null)
            {
                Console.WriteLine("\nWybierz klasę postaci:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Wojownik        (Dużo HP, Słaby atak, BLOK TARCZĄ)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2. Łucznik         (Średnie HP, Średni atak, UNIK)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("3. Mag             (Mało HP, Potężny atak, PODWÓJNE OBRAŻENIA)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("4. Berserk         (Średnie HP, Średni atak, PODWAJANIE TURY)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("5. Paladyn         (Średnie HP, Średni atak, ZWIĘKSZENIE OBRAŻEŃ, REDUKCJA OBRAŻEŃ)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("6. Łowca aniołów   (Średnie HP, Średni atak, ODRODZENIE)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("7. Farciarz        (Średnie HP, Średni atak, ALL IN ONE)");
                Console.ResetColor();
                Console.Write("\nTwój wybór (1-7): ");
                Console.WriteLine();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        choosenClass = new Warrior();
                        color = ConsoleColor.Blue;
                        break;
                    case "2":
                        choosenClass = new Archer();
                        color = ConsoleColor.Green;
                        break;
                    case "3":
                        choosenClass = new Mage();
                        color = ConsoleColor.DarkMagenta;
                        break;
                    case "4":
                        choosenClass = new Berserk();
                        color = ConsoleColor.DarkYellow;
                        break;
                    case "5":
                        choosenClass = new Paladin();
                        color = ConsoleColor.DarkRed;
                        break;
                    case "6":
                        choosenClass = new AngelHunter();
                        color = ConsoleColor.Cyan;
                        break;
                    case "7":
                        choosenClass = new LuckyGuy();
                        color = ConsoleColor.DarkGray;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Wpisz 1, 2, 3, 4, 5, 6 lub 7.");
                        break;
                }
            }

            Console.Write($"\nStworzono postać: {name} (");
            Console.ForegroundColor = color;
            Console.Write(choosenClass.Name);
            Console.ResetColor();
            Console.WriteLine(")");

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();

            Console.Clear();

            return new Player(name, choosenClass);
        }
    }
}