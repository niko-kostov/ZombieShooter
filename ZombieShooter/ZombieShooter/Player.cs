using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieShooter
{
    public class Player
    {
        string Name;
        int Points;

        public Player (string playername)
        {
            this.Name = playername;
            Points = 0;
        }
    }
}
