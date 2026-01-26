using graTurowa;
using System;
using System.Numerics;
using System.Threading;
class Program
{
    static void Main()
    {
        string title = "Podróbka Shakes&Fidget";
        int consoleWidth = Console.WindowWidth;
        int leftPadding = (consoleWidth - title.Length) / 2;
        Console.WriteLine(title.PadLeft(leftPadding + title.Length));
        Console.WriteLine("\nNaciśnij dowolny klawisz, aby rozpocząć tworzenie postaci.");
        Console.ReadKey();
        Console.Clear();

        Player hero1 = CharCreator.Create();
        Player hero2 = CharCreator.Create();

        BattleSystem.Battle(hero1, hero2);
    }
}