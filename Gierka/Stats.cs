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
        
        public virtual int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(MinDmg, MaxDmg + 1);
            if (rnd.Next(0, 101) <= CritChance)
            {
                damage *= 2;
                Console.ForegroundColor = ConsoleColor.Red;
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
    }
    public class Archer : Stats
    {
        public Archer()
        {
            Hp = 10000;
            MinDmg = 430;
            MaxDmg = 600;
            Name = "Archer";
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
            Hp = 15850;
            MinDmg = 370;
            MaxDmg = 460;
            Name = "Warrior";
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
            Hp = 7370;
            MinDmg = 430;
            MaxDmg = 2000;
            Name = "Mage";
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

}