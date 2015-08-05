using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PopularGame.Tests
{
    [TestClass]
    public class ColoringTests
    {
        [TestMethod]
        public void AdjacencyList_Should_Be_Equal_To_Colored_Vertices()
        {
            AdjacencyList list = new AdjacencyList("2x2onecolor.txt");
            var colorsLine = File.ReadLines("2x2onecolor.txt").First();            
            var colors = colorsLine.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse);

            Assert.AreEqual(list.Count(), colors.Count());
        }

        [TestMethod]
        public void Should_Be_More_Than_One_Row()
        {            
            var lines = File.ReadLines("2x2onecolor.txt");

            Assert.IsTrue(lines.Count() > 1);
        }

        [TestMethod]
        public void ColorMyMatrix()
        {
            AdjacencyList list = new AdjacencyList("3x3.txt");
            var colorsLine = File.ReadLines("3x3.txt").First();
            var colors = colorsLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse);

            IGraphTraversal traversal = new MatrixTraversal(list, colors.ToArray());
            IColorator colorator = new MatrixColorator(traversal);
            colorator.Color();
        }

        [TestMethod]
        public void DontColorMyMatrix()
        {
            AdjacencyList list = new AdjacencyList("2x2onecolor.txt");
            var colorsLine = File.ReadLines("2x2onecolor.txt").First();
            var colors = colorsLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse);

            IGraphTraversal traversal = new MatrixTraversal(list, colors.ToArray());
            IColorator colorator = new MatrixColorator(traversal);
            colorator.Color();
        }
    }
}
