using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Huffman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = ToBinary(GetText());
            string bin = result.Aggregate("", (current, b) => current + b);

            Console.WriteLine(bin);
            var path = "Output.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(bin);
            }

            Console.ReadLine();

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

        public static String ToBinary(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);

            return string.Join(" ",
                data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}