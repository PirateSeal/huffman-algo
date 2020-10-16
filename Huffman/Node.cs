using System;
using System.Collections.Generic;

namespace Huffman
{
    public class Node
    {
        public Node NodeRight { get; set; }
        public Node NodeLeft { get; set; }
        public Char Char { get; set; }
        public int Frequency { get; set; }


        public List<bool> Traverse(char symbol, List<bool> data)
        {
            if (NodeRight == null && NodeLeft == null)
            {
                if (symbol.Equals(this.Char)) return data;
                else return null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (NodeLeft != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);
                    left = NodeLeft.Traverse(symbol, leftPath);
                }

                if (NodeRight != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = NodeRight.Traverse(symbol, rightPath);
                }

                if (left != null) return left;
                else return right;
            }
        }

    }
}
