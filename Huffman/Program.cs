using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Huffman
{
    internal class Program
    {
        public static void Main(string[] args)
        {



            string text = TextUtils.GetText();
            var stopWatchStepOne = Stopwatch.StartNew();
            var stepOneModel = TextUtils.BuildStepOneModel(text);
            stopWatchStepOne.Stop();
            Console.WriteLine($"Computation time for step one: {stopWatchStepOne.ElapsedMilliseconds}ms");

            Console.WriteLine($"Length: {stepOneModel.Length}");
            Console.WriteLine($"Frequencies: {string.Join(", ", stepOneModel.Frequencies.Select((k) => k.Key + ": " + k.Value))}");
            Console.WriteLine($"Binary: {stepOneModel.BinaryString}");


            var stopWatchBuildTree = Stopwatch.StartNew();
            Node node = TextUtils.BuildTree(stepOneModel.Frequencies);
            stopWatchBuildTree.Stop();
            Console.WriteLine($"Computation time for tree building: {stopWatchBuildTree.ElapsedMilliseconds}ms");

            TextUtils.SaveDictionnary(string.Join("",stepOneModel.Frequencies.Keys), node);

           
            Console.WriteLine("Binary size: " + stepOneModel.BinaryString.Length);

            BitArray encoded = TextUtils.Encode(text, node);
            Console.WriteLine("Encoded binary size: " + encoded.Length);

            byte[] bytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
            encoded.CopyTo(bytes, 0);
            File.WriteAllBytes("encoded.txt", bytes);

            Console.ReadLine();
        }
    }
}