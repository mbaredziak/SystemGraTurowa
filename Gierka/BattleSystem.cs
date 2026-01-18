using System;
using System.Collections.Generic;
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
            Console.Clear();
            Console.WriteLine("Wciśnij dowolny klawisz, aby rozpocząć");
            Console.ReadKey();
            Console.Clear();

            while (player1.Vocation.Hp > 0 && player2.Vocation.Hp > 0)
            {
                player1.Attack(player2);

                if (player2.Vocation.Hp <= 0)
                {
                    Console.WriteLine($"Wygrywa {player1.PlayerName}!");
                    break;
                }
                Thread.Sleep(1000);

                player2.Attack(player1);

                if (player1.Vocation.Hp <= 0)
                {
                    Console.WriteLine($"Wygrywa {player2.PlayerName}!");
                    break;
                }
                Thread.Sleep(1000);
            }
        }
    }
}