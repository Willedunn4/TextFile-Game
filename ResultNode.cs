using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFile_Game
{
    class ResultNode
    {
        public string Result { get; set; }
        public ResultNode Next { get; set; }
        public ResultNode Prev { get; set; }

        public ResultNode(string result)
        {
            Result = result;
        }
    }
}
