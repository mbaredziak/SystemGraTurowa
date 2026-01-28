using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace graTurowa
{
    public class BattleSystem
    {
        public static void Battle(Player player1, Player player2)
        {
            int r = 1;
            Console.Clear();
            Console.WriteLine("Wciśnij dowolny klawisz, aby rozpocząć");
            Console.ReadKey();
            Console.Clear();

            while (player1.Vocation.Hp > 0 && player2.Vocation.Hp > 0)
            {
                Console.WriteLine($"Runda {r}");
                Console.WriteLine("-------------------------------------------------");
                bool p1Turn = true;
                while (p1Turn)
                {
                    Console.WriteLine($"Atakuje {player1.Vocation.Name} {player1.PlayerName}");
                    Console.WriteLine($"HP: {player1.Vocation.Hp}/{player1.Vocation.maxHp} | Mikstury: {player1.Vocation.Potions}");
                    Console.WriteLine("1. Atak");
                    Console.WriteLine("2. Użyj mikstury, aby się wyleczyć");
                    Console.WriteLine("Wybierz akcję: ");
                    int move = Console.ReadKey(true).KeyChar;
                    Console.WriteLine();
                    if (move == '1')
                    {
                        int damage = player1.Vocation.Attack();
                        Thread.Sleep(1000);
                        int fdamage = player2.Vocation.Defend(damage);
                        player2.Vocation.Hp -= fdamage;
                        if (fdamage > 0)
                        {
                            Console.WriteLine($"{player2.Vocation.Name} {player2.PlayerName} otrzymuje {fdamage} DMG! (Pozostałe HP: {player2.Vocation.Hp})");
                        }
                        if (player2.Vocation.Hp <= 0)
                        {
                            p1Turn = false;
                            break;
                        }
                        if (player1.Vocation.ExtraTurn())
                        {
                            Thread.Sleep(200);
                        }
                        else
                        {
                            p1Turn = false;
                        }
                        Console.WriteLine("-------------------------------------------------");
                    }
                    else if (move == '2')
                    {
                        bool healSucces = player1.Vocation.Heal();
                        if(healSucces)
                        {
                            p1Turn = false;
                            Thread.Sleep(1000);
                        }
                        Console.WriteLine("-------------------------------------------------");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieznana akcja! Wybierz 1 lub 2.");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
                if(player2.Vocation.Hp <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.WriteLine($"\nWygrywa {player1.Vocation.Name} {player1.PlayerName}!");
                    Console.ResetColor();
                    break;
                }
                
                bool p2Turn = true;
                while (p2Turn)
                {
                    Console.WriteLine($"Atakuje {player2.Vocation.Name} {player2.PlayerName}");
                    Console.WriteLine($"HP: {player2.Vocation.Hp}/{player2.Vocation.maxHp} | Mikstury: {player2.Vocation.Potions}");
                    Console.WriteLine("1. Atak");
                    Console.WriteLine("2. Użyj mikstury, aby się wyleczyć");
                    Console.WriteLine("Wybierz akcję: ");
                    int move = Console.ReadKey(true).KeyChar;
                    Console.WriteLine();
                    if (move == '1')
                    {
                        int damage = player2.Vocation.Attack();
                        Thread.Sleep(1000);
                        int fdamage = player1.Vocation.Defend(damage);
                        player1.Vocation.Hp -= fdamage;
                        if (fdamage > 0)
                        {
                            Console.WriteLine($"{player1.Vocation.Name} {player1.PlayerName} otrzymuje {fdamage} DMG! (Pozostałe HP: {player1.Vocation.Hp})");
                        }
                        if (player1.Vocation.Hp <= 0)
                        {
                            p2Turn = false;
                            break;
                        }
                        if (player2.Vocation.ExtraTurn())
                        {
                            Thread.Sleep(200);
                        }
                        else
                        {
                            p2Turn = false;
                        }
                        Console.WriteLine("-------------------------------------------------");
                    }
                    else if (move == '2')
                    {
                        bool healSucces = player2.Vocation.Heal();
                        if (healSucces)
                        {
                            p2Turn = false;
                            Thread.Sleep(1000);
                        }
                        Console.WriteLine("-------------------------------------------------");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieznana akcja! Wybierz 1 lub 2.");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
                if (player1.Vocation.Hp <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nWygrywa {player2.Vocation.Name} {player2.PlayerName}!");
                    Console.ResetColor();
                    break;
                }
                r++;
            }
            Console.WriteLine("\nKoniec gry, naciśnij dowolny klawisz, aby zakończyć");
            Console.ReadKey();
        }
    }
}