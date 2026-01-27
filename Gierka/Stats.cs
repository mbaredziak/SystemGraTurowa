using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graTurowa
{
    public class Stats
    {
        public int Hp { get; set; }
        public string Name { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int CritChance { get; set; }
        public int Potions { get; set; } = 2;
        public int maxHp { get; set; }
        
        public virtual int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(MinDmg, MaxDmg + 1);
            if (rnd.Next(0, 101) <= CritChance)
            {
                damage *= 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} wyprowadza potężny cios!");
                Console.ResetColor();
            }
            return damage;
        }
        public virtual int Defend(int incomingDamage)
        {
            return incomingDamage;
        }
        public virtual bool ExtraTurn()
        {
            return false;
        }
        public virtual bool Heal()
        {
            if (Potions > 0 && Hp < maxHp)
            {
                int heal = (int)(maxHp * 0.3);
                Hp += heal;
                if (Hp > maxHp) Hp = maxHp;
                Potions--;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} leczy się za {heal} HP! (Zostało {Potions} mikstur)");
                Console.ResetColor();
                return true;
            }
            else if (Potions <= 0)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie masz już mikstur!");
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.WriteLine("-------------------------------------------------");
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"Masz już pełne HP! Twoje HP: {maxHp}");
                Console.ResetColor();
                return false;
            }
        }
    }
    public class Archer : Stats
    {
        public Archer()
        {
            maxHp = 10000;
            Hp = 10000;
            MinDmg = 430;
            MaxDmg = 600;
            Name = "Łucznik";
            CritChance = 50;
        }
        public override int Defend(int incomingDamage)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Name} wykonuje unik!");
                Console.ResetColor();
                return 0;
            }
            return incomingDamage;
        }
    }
    public class Warrior : Stats
    {
        public Warrior()
        {
            maxHp = 15850;
            Hp = 15850;
            MinDmg = 370;
            MaxDmg = 460;
            Name = "Wojownik";
            CritChance = 50;
        }
        public override int Defend(int incomingDamage)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 4) == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Name} wykonuje obronę tarczą!");
                Console.ResetColor();
                return 0;
            }
            return incomingDamage;
        }
    }
    public class Mage : Stats
    {
        public Mage()
        {
            maxHp = 7370;
            Hp = 7370;
            MinDmg = 430;
            MaxDmg = 2000;
            Name = "Mag";
            CritChance = 50;
        }
        public override int Attack()
        {
            int damage = base.Attack();
            Random rnd = new Random();
            if (rnd.Next(0, 4) == 0)
            {
                damage *= 2;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Name} podwaja obrażenia!");
                Console.ResetColor();
            }
            return damage;
        }
    }
    public class Berserk : Stats
    {
        public Berserk()
        {
            maxHp = 9000;
            Hp = 9000;
            MinDmg = 390;
            MaxDmg = 550;
            Name = "Berserk";
            CritChance = 50;
        }
        public override bool ExtraTurn()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Name} wpada w szał i uderza ponownie!");
                Console.ResetColor();
                return true;
            }
            return false;
        }
    }
    public class Paladin : Stats
    {
        public Paladin()
        {
            maxHp = 12000;
            Hp = 12000;
            MinDmg = 330;
            MaxDmg = 420;
            Name = "Paladyn";
            CritChance= 50;
        }
        public override int Attack()
        {
            int damage = base.Attack();
            Random rnd = new Random();
            if(rnd.Next(0, 5) == 0)
            {
                damage = (int)(damage * 1.5);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Name} zaklina swój miecz i zwiększa obrażenia!");
                Console.ResetColor();
            }
            return damage;
        }
        public override int Defend(int incomingDamage)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 5) == 0)
            {
                int reducedDamage = (int)(incomingDamage * 0.5);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Name} zaklina swoją zbroję i niweluje połowę obrażeń!");
                Console.ResetColor();
                return reducedDamage;
            }
            return incomingDamage;
        }
    }
    public class AngelHunter : Stats
    {
        private int resurrect;
        public AngelHunter()
        {
            resurrect = 40;
            maxHp = 10000;
            Hp = maxHp;
            MinDmg = 430;
            MaxDmg = 600;
            Name = "Łowca aniołów";
            CritChance = 50;
        }
        public override int Defend(int incomingDamage)
        {
            if (incomingDamage >= Hp)
            {
                Random rnd = new Random();
                if(rnd.Next(1,101) <= resurrect)
                {
                    Hp = (int)(maxHp * 0.8);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"{Name} otrzymuje śmiertelny cios, natomiast jego anioł odradza go z {Hp} HP!");
                    Console.ResetColor();
                    resurrect -= 10;
                    return 0;
                }
            }
            return incomingDamage;
        }
    }
}