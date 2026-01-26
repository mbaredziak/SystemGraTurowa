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
    }
}