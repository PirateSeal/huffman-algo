using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huffman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text = TextUtils.GetText();
            string bin = TextUtils.ToBinary(text);
            TextUtils.PrintBin(bin);
            TextUtils.GetTextLength(text);
            TextUtils.GetTextLength(bin);
            Console.ReadLine();
        }
    }
}