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
            string text = GetText();
            string bin = ToBinary(text);

            PrintBin(bin);
            GetTextLength(text);
            var dictionary = GetCharNbr(text);
            Console.WriteLine(dictionary);
        }

        public static void PrintBin(string text)
        {
            string bin = "";
            foreach (char c in text) bin = bin + c;
            Console.WriteLine(bin);
            var path = "Output.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(bin);
            }
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
            var x = 0;
            foreach (char c in text) x++;
            Console.WriteLine("text length is : {0}", x);
        }

        public static String ToBinary(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);

            return string.Join("",
                data.Select(byt =>
                    Convert.ToString(byt, 2)
                        .PadLeft(8, '0')));
        }

        public static Dictionary<char, int> GetCharNbr(string text)
        {
            var occurrences = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (!occurrences.ContainsKey(c)) occurrences.Add(c, 1);
                else occurrences[c]++;
            }
            
            return occurrences;
        }
    }
}