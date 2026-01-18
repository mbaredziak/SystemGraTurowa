using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graTurowa
{
    public class Player
    {
        public string PlayerName { get; set; }
        public Stats Vocation { get; set; }

        private Random rng = new Random();

        public Player(string playerName, Stats vocation)
        {
            PlayerName = playerName;
            Vocation = vocation;
        }

        public void Attack(Player target)
        {
            int damage = rng.Next(Vocation.MinDmg, Vocation.MaxDmg + 1);
            int roll = rng.Next(1, 101);

            if (roll <= Vocation.CritChance)
            {
                damage *= 2;
                Console.WriteLine("Trafienie krytyczne!");
            }

            target.Vocation.Hp -= damage;

            if (target.Vocation.Hp < 0) target.Vocation.Hp = 0;

            Console.WriteLine($"{PlayerName} atakuje {target.PlayerName} za {damage} obrazen!");
            Console.WriteLine($"Pozostałe zdrowie {target.PlayerName}: {target.Vocation.Hp}");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}