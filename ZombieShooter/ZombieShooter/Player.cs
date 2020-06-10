using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieShooter
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Player(string playername)
        {
            this.Name = playername;
            Points = 0;
        }
        public void IncreasePoints()
        {
            Points++;
        }
    }
}
