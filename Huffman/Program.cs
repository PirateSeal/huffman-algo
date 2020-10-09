using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huffman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text = GetText();
            string bin = ToBinary(text);
            PrintBin(bin);
            GetTextLength(text);
            Console.ReadLine();
        }

        public static void PrintBin(string text)
        {
            string bin = text.Aggregate("", (current, b) => current + b);
            Console.WriteLine(bin);
        }

        public static string GetText()
        {
            Console.WriteLine("Enter text location");
            string location = Console.ReadLine();
            if (location != null && location.Contains(".txt"))
            {
                return System.IO.File.ReadAllText(location);
            }

            throw new Exception();
        }

        public static void GetTextLength(string text)
        {
            var nbChar = 0;
            foreach (char c in text)
                nbChar++;

            Console.WriteLine("text length is : {0}", nbChar);
        }

        public static String ToBinary(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);

            return string.Join("",
                data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}