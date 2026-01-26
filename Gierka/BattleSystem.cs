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
                bool p1Turn = true;
                while (p1Turn)
                {
                    Console.WriteLine($"Atakuje {player1.Vocation.Name} {player1.PlayerName}");
                    int damage = player1.Vocation.Attack();
                    Thread.Sleep(1000);
                    int fdamage = player2.Vocation.Defend(damage);
                    player2.Vocation.Hp -= fdamage;
                    if (fdamage > 0)
                    {
                        Console.WriteLine($"{player2.Vocation.Name} otrzymuje {fdamage} DMG! (Pozostałe HP: {player2.Vocation.Hp})");
                    }
                    if (player2.Vocation.Hp <= 0)
                    {
                        p1Turn = false;
                        break;
                    }
                    if(player1.Vocation.ExtraTurn())
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        p1Turn = false;
                    }
                    Console.WriteLine("-------------------------------------------------");
                }
                if(player2.Vocation.Hp <= 0)
                {
                    Console.WriteLine($"Wygrywa {player1.Vocation.Name}!");
                    break;
                }
                
                bool p2Turn = true;
                while (p2Turn)
                {
                    Console.WriteLine($"Atakuje {player2.Vocation.Name} {player2.PlayerName}");
                    int damage = player2.Vocation.Attack();
                    Thread.Sleep(1000);
                    int fdamage = player1.Vocation.Defend(damage);
                    player1.Vocation.Hp -= fdamage;
                    if (fdamage > 0)
                    {
                        Console.WriteLine($"{player1.Vocation.Name} otrzymuje {fdamage} DMG! (Pozostałe HP: {player1.Vocation.Hp})");
                    }
                    if (player1.Vocation.Hp <= 0)
                    {
                        p2Turn = false;
                        break;
                    }
                    if (player1.Vocation.ExtraTurn())
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        p2Turn = false;
                    }
                    Console.WriteLine("-------------------------------------------------");
                }
                if (player1.Vocation.Hp <= 0)
                {
                    Console.WriteLine($"Wygrywa {player2.Vocation.Name}!");
                    break;
                }
                r++;
            }
            Console.WriteLine("\nKoniec gry, naciśnij dowolny klawisz, aby zakończyć");
            Console.ReadKey();
        }
    }
}