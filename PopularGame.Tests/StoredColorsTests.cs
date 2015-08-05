using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PopularGame.Tests
{
    [TestClass]
    public class StoredColorsTests
    {
        [TestMethod]
        public void Should_Be_Able_To_Store_Value()
        {
            short expected = 1;

            StoredColors colors = new StoredColors();
            colors.Add(100);

            Assert.AreEqual(expected, colors.Count);
        }

        [TestMethod]
        public void Should_Be_Able_To_Store_Same_Value()
        {
            short expectedSize = 1;
            short expectedCount = 4;

            StoredColors colors = new StoredColors();
            colors.Add(100);
            colors.Add(100);
            colors.Add(100);
            colors.Add(100);

            Assert.AreEqual(expectedSize, colors.Count);
            Assert.AreEqual(expectedCount, colors[100]);
        }

        [TestMethod]
        public void Should_Be_Able_To_Store_Different_Values()
        {
            short expectedSize = 4;
            short expectedCount = 4;

            StoredColors colors = new StoredColors();
            colors.Add(100);
            colors.Add(200);
            colors.Add(300);
            colors.Add(400);

            Assert.AreEqual(expectedSize, colors.Count);            
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Should_Not_Be_Able_To_Use_Add()
        {
            StoredColors colors = new StoredColors();
            colors.Add(100, 100);
        }
    }
}
