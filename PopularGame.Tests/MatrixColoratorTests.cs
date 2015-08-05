using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PopularGame.Tests
{
    [TestClass]
    public class MatrixColoratorTests
    {
        [TestMethod]        
        public void Check_Colorator_Behaviour()
        {
            var traversal = new Mock<IGraphTraversal>();
            MatrixColorator colorator = new MatrixColorator(traversal.Object);

            traversal.Setup(x => x.Traverse());
        }
    }
}
