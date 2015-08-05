using System;
using System.IO;
using System.Linq;

namespace PopularGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter your matrix:");
            System.Console.WriteLine("Sorry for inconvenience, this part isn't done yet! Check some example instead!");

            AdjacencyList list = new AdjacencyList("3x3.txt");
            var colorsLine = File.ReadLines("3x3.txt").First();
            var colors = colorsLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse);

            IGraphTraversal traversal = new MatrixTraversal(list, colors.ToArray());
            IColorator colorator = new MatrixColorator(traversal);
            colorator.Color();
        }
    }
}
