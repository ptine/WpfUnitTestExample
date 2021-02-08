using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfUnitTestExample;

namespace UnitTests
{
    [TestClass]
    public class ViewModelUnitTest
    {
        private ViewModel _viewModel;


        public ViewModelUnitTest()
        {
            _viewModel = new ViewModel();

            _viewModel.Positions = new bool[]
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
        }

        [TestMethod]
        public void NeededPlaces6_ShouldReturnNotFound()
        {            
            _viewModel.IsCircular = false;
            _viewModel.PositionsNeeded = 6;
            Assert.AreEqual(_viewModel.CheckResult(), -1);
        }

        [TestMethod]
        public void NeededPlaces4_ShouldReturn_5()
        {
            _viewModel.IsCircular = false;
            _viewModel.PositionsNeeded = 4;
            Assert.AreEqual(_viewModel.CheckResult(), 5);
        }

        [TestMethod]
        public void NeededPlaces5_ShouldReturnNotFound()
        {
            _viewModel.IsCircular = false;
            _viewModel.PositionsNeeded = 5;
            Assert.AreEqual(_viewModel.CheckResult(), -1);
        }

        [TestMethod]
        public void IsCircularNeededPlaces5_ShouldReturn_10()
        {
            _viewModel.IsCircular = true;
            _viewModel.PositionsNeeded = 5;
            Assert.AreEqual(_viewModel.CheckResult(), 10);
        }
    }
}
