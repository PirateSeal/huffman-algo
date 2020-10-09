using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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


            Dictionary<char,int> frequencies = TextUtils.GetCharNbr(text);
            Node node = TextUtils.BuildTree(frequencies);
            string asciiChars = "";
            foreach (char letter in frequencies.Keys) asciiChars += letter;
            TextUtils.SaveDictionnary(asciiChars, node);

            BitArray encoded = TextUtils.Encode(text, node);
            Console.WriteLine("Binary size: " + bin.Length);
            Console.WriteLine("Encoded binary size: " + encoded.Length);

            byte[] bytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
            encoded.CopyTo(bytes, 0);

            File.WriteAllBytes("encoded", bytes);
            Console.ReadLine();
        }
    }
}