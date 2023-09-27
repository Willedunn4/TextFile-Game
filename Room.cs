using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFile_Game
{
    class Room
    {
        public Monster Monster { get; set; }
        public Room NextRoom { get; set; }
        public Room PrevRoom { get; set; }

        public Room(Monster monster)
        {
            Monster = monster;
        }
    }
}
