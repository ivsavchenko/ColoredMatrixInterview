using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PopularGame.Tests
{
    [TestClass]
    public class MatrixTraversalTests
    {
        [TestMethod]   
        [ExpectedException(typeof(ArgumentException))]     
        public void MatrixTraversal_Should_Be_Initialized()
        {            
            MatrixTraversal traversal = new MatrixTraversal(null, null);
            Assert.Inconclusive();
        }
    }
}
