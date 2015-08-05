using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PopularGame.Tests
{
    [TestClass]
    public class AdjacencyListTest
    {
        [TestMethod]
        public void Load_Empty_List()
        {
            int expected = 0;
            AdjacencyList list = new AdjacencyList("empty.txt");

            Assert.AreEqual(expected, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Load_Trash_List()
        {
            int expected = 0;
            AdjacencyList list = new AdjacencyList("trash.txt");

            Assert.Inconclusive();
        }

        [TestMethod]        
        public void Load_2x2_List()
        {
            int expected = 4;
            AdjacencyList list = new AdjacencyList("2x2onecolor.txt");

            Assert.AreEqual(expected, list.Count);
        }

        [TestMethod]
        public void Load_3x3_List()
        {
            int expected = 9;
            AdjacencyList list = new AdjacencyList("3x3.txt");

            Assert.AreEqual(expected, list.Count);
        }
    }
}
