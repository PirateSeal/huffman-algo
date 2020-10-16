using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class StepOneAnnalizeModel
    {
        public Dictionary<Char, int> Frequencies { get; set; }
        public int Length { get; set; }
        public string BinaryString { get; set; }
        public List<byte> Bytes { get; set; }
    }
}
