using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            var dictionary = GetCharNbr(text);
            Console.WriteLine(dictionary);
        }
        public static Dictionary<char, int> GetCharNbr(string text) { 

            var occurrences = new Dictionary<char, int>();
            
            foreach (char c in text) { 
                if (!occurrences.ContainsKey(c)) occurrences.Add(c, 1);
                else occurrences[c]++;
            }
            return occurrences;
            
        }
    }
}