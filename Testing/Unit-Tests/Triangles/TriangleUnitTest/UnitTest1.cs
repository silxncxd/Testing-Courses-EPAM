using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangles;

namespace TriangleUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsTriangleEquilateralTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(1, 1, 1));
        }

        [TestMethod]
        public void IsTriangleIsosceles()
        {
            Assert.IsTrue(Triangle.IsIsoscelesTriangle(12, 10, 10));
        }

        [TestMethod]
        public void IsTriangleIsoscelesTest()
        {
            Assert.IsTrue(Triangle.IsIsoscelesTriangle(2, 2, 3));
        }

        [TestMethod]
        public void IsTriangleAllSidesNullTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void IsTriangleBadTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(1, 4, 7));
        }

        [TestMethod]
        public void IsRightTriangleTest()
        {
            Assert.IsFalse(Triangle.IsRightTriangle(4, 5, 6));
        }

        [TestMethod]
        public void IsTriangleOneBadSideTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(4, -5, 6));
        }

        [TestMethod]
        public void IsTriangleTwoBadSidesGoodTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(-4, -5, 6));
        }

        [TestMethod]
        public void IsTriangleThreeBadSidesGoodTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(-4, -5, -6));
        }

        [TestMethod]
        public void IsTriangleDoubleGoodTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(2.5, 3.5, 4.5));
        }
    }
}
