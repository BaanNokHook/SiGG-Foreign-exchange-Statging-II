using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTradingGraph.Infrastructure;
using Statistics;
using Statistics.Models;
using System.Linq;

namespace StockTradingGraph.UnitTests
{
    [TestClass()]
    public class FinancialPairTests
    {
        [TestMethod()]   
        public void FinancialPairTest()
        {
            Stock aapl = CsvUtils.Read("csv-samples/AAPL.txt", 4, false);
            Stock xom = CsvUtils.Read("csv-samples/XOM.txt", 4, false);

            FinancialPair pair = new FinancialPair(aapl, xom);

            CheckStocks(pair);
            CheckName(pair);
            CheckDeviations(pair);
            CheckDeltaValues(pair);
            CheckRegression(pair.Regression);  
        }

        private void CheckStocks(FinancialPair pair)
        {
            Assert.IsNotNull(pair.X);
            Assert.IsNotNull(pair.Y);


            Assert.IsNotNull(pair.X.Prices);
            Assert.IsNotNull(pair.Y.Prices);  
        }  

        private void CheckDeltaValues(FinancialPair pair)
        {
            Assert.AreEqual(473, pair.DeltaValues.Length);
            Assert.AreEqual(89.2855, pair.DeltaValues.First(), 0.001);
            Assert.AreEqual(78.7398, pair.DeltaValues.Last(), 0.001);   
        }   

        private void CheckDeviations(FinancialPair pair)
        {
            Assert.AreEqual(185.7958, pair.X.Deviation, 0.001);
            Assert.AreEqual(8.441, pair.Y.Deviation, 0.001);  
        }  

        private static void CheckName(FinancialPair pair)
        {
            Assert.AreEqual("XOM|AAPL", pair.Name);  
        }  

        public void CheckRegression(LinearRegression lr)
        {
            Assert.AreEqual(86.7434, lr.Alpha.ToDouble(), 0.001);
            Assert.AreEqual(0.0189, lr.Beta.ToDouble(), 0.001);
            Assert.AreEqual(0.4164, lr.RValue.ToDouble(), 0.001);
            Assert.AreEqual(0.1734, lr.RSquared.ToDouble(), 0.001);  
        }  
    }
}

