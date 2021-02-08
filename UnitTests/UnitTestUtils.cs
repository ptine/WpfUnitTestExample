using System;
using BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestUtils
    {
        private bool[] _places = new bool[]
        {
            false,
            false,
            false,
            true,
            true,
            false,
            false,
            false,
            false,
            true,
            false,
            false
        };

        public UnitTestUtils()
        {
        }

        [TestMethod]
        public void NeededPlaces6_ShouldReturnNotFound()
        {
            var result = Utils.FindFreePosition(_places, 6, false);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void NeededPlaces4_ShouldReturn_5()
        {
            var result = Utils.FindFreePosition(_places, 4, false);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void NeededPlaces5_ShouldReturnNotFound()
        {
            var result = Utils.FindFreePosition(_places, 5, false);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void IsCircularNeededPlaces5_ShouldReturn_10()
        {
            var result = Utils.FindFreePosition(_places, 5, true);
            Assert.AreEqual(result, 10);
        }
    }
}
