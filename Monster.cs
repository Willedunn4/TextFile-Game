﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFile_Game
{
    class Monster
    {
        public string Type { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int AP { get; set; }
        public int DEF { get; set; }

        public Monster(string type, int hp, int mp, int ap, int def)
        {
            Type = type;
            HP = hp;
            MP = mp;
            AP = ap;
            DEF = def;
        }
    }
}
