using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huffman
{
    public static class TextUtils
    {
        public static void PrintBin(string text)
        {
            string bin = text.Aggregate("", (current, b) => current + b);
            Console.WriteLine(bin);
        }

        public static Dictionary<char, int> GetCharNbr(string text)
        {
            var occurrences = new Dictionary<char, int>();

            {
                foreach (char c in text)
                    if (!occurrences.ContainsKey(c)) occurrences.Add(c, 1);
                    else occurrences[c]++;
            }
            foreach (var occurrence in occurrences)
            {
                Console.WriteLine("{0} occurred {1} times",occurrence.Key,occurrence.Value);
            }
            return occurrences;
        }

        public static Node BuildTree(Dictionary<char, int> frequencies)
        {
            Node root = null;
            List<Node> nodes = frequencies.Select(f =>
            {
                return new Node()
                {
                    Char = f.Key,
                    Frequency = f.Value
                };
            }).ToList();

            while(nodes.Count > 1)
            {
                List<Node> orderedByFrequency = nodes.OrderBy(n => n.Frequency).ToList();
                if (orderedByFrequency.Count >= 2)
                {

                    List<Node> taken = orderedByFrequency.Take(2).ToList();

                    Node parent = new Node()
                    {
                        Char = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        NodeLeft = taken[0],
                        NodeRight = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                root = nodes.FirstOrDefault();
            }

            return root;
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