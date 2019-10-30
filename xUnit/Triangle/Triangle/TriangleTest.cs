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
        public void IsTriangleTwoBadSidesTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(-4, -5, 6));
        }

        [TestMethod]
        public void IsIsoscelesTriangleTwoEqualSidesTest()
        {
            Assert.IsTrue(Triangle.IsIsoscelesTriangle(12, 10, 10));
        }

        [TestMethod]
        public void IsIsoscelesTriangleBadTest()
        {
            Assert.IsFalse(Triangle.IsIsoscelesTriangle(2, 5, 3));
        }

        [TestMethod]
        public void IsIsoscelesTriangleOneBadSideTest()
        {
            Assert.IsFalse(Triangle.IsIsoscelesTriangle(4, -5, 6));
        }

        [TestMethod]
        public void IsRightTriangleGoodTest()
        {
            Assert.IsTrue(Triangle.IsRightTriangle(6, 8, 10));
        }

        [TestMethod]
        public void IsRightTriangleThreeBadSidesTest()
        {
            Assert.IsFalse(Triangle.IsRightTriangle(-4, -5, -6));
        }

        [TestMethod]
        public void IsRightTriangleDoubleBadTest()
        {
            Assert.IsFalse(Triangle.IsRightTriangle(2.5, 3.5, 4.5));
        }
    }
}
