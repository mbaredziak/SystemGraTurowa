using System;
using System.Collections.Generic;
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

            while (choosenClass == null)
            {
                Console.WriteLine("\nWybierz klasę postaci:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Wojownik (Dużo HP, Słaby atak)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2. Łucznik  (Średnie HP, Średni atak)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("3. Mag      (Mało HP, Potężny atak)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("4. Berserk  (Średnie HP, Średni atak");
                Console.ResetColor();
                Console.Write("Twój wybór (1-4): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        choosenClass = new Warrior();
                        break;
                    case "2":
                        choosenClass = new Archer();
                        break;
                    case "3":
                        choosenClass = new Mage();
                        break;
                    case "4":
                        choosenClass = new Berserk();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Wpisz 1, 2, 3 lub 4.");
                        break;
                }
            }
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine($"\nStworzono postać: {name} ({choosenClass.Name})");
            Console.ResetColor();

            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();

            Console.Clear();

            return new Player(name, choosenClass);
        }
    }
}