using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics;

namespace StockTradingGraph.Infrastructure.Tests
{
    [TestClass()]
    public class MathUtilsTests
    {
        [TestMethod()]
        public void GetStandardDeviationTest()
        {
            double[] values = { 1, 3, 5, 7 };


            double result = MathUtils.GetStandardDeviation(values);

            Assert.AreEqual(2.5819, result, 0.0001);


            values = new double[] { 1, 2, 4, 5 };

            result = MathUtils.GetStandardDeviation(values);

            Assert.AreEqual(1.8257, result, 0.0001);
        }
    }

}


