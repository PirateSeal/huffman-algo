using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Huffman
{
    public static class TextUtils
    {

        public static StepOneAnnalizeModel BuildStepOneModel(string text)
        {
            StepOneAnnalizeModel model = new StepOneAnnalizeModel() { BinaryString = "", Frequencies = new Dictionary<char, int>(), Length = 0, Bytes = new List<Byte>() };

            foreach(char c in text)
            {
                model.Length++;

                if (!model.Frequencies.ContainsKey(c)) model.Frequencies.Add(c, 1);
                else model.Frequencies[c]++;

                byte cByte = (byte)c;
                model.Bytes.Add(cByte);
                model.BinaryString += Convert.ToString(c, 2).PadLeft(8, '0');
            }

            return model;
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

        public static BitArray Encode(string source, Node node)
        {
            List<bool> encodedSource = new List<bool>();
            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = node.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            BitArray bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public static void SaveDictionnary(string source, Node node)
        {
            string file = "";
            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = node.Traverse(source[i], new List<bool>());
                file += source[i] + ": ";
                foreach (bool bit in new BitArray(encodedSymbol.ToArray())) file += Convert.ToInt32(bit);
                file += "\n";
            }

            file.Replace("\n", Environment.NewLine);
            using (StreamWriter sw = File.CreateText("dico.txt")) sw.WriteLine(file);
        }

    }
}