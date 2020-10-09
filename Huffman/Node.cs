using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class Node
    {
        public Node NodeRight { get; set; }
        public Node NodeLeft { get; set; }
        public char Char { get; set; }
        public int Frequency { get; set; }



    }
}
