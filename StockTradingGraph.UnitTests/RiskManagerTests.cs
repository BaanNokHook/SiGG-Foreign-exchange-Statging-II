using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace StockTradingGraph.Infrastructure.Tests
{
    [TestClass()]
    public class RiskManagerTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            Stock[] stocks = CsvUtils.ReadAllDataFrom("csv-samples/", 4, false);

            List<FinancialPair> pairs = FinancialPair.CreateMany(stocks);

            RiskManager rm = new RiskManager(pairs.ToArray(), 100000.00);
            rm.Calculate();

            pairs.ForEach(i => { Assert.AreNotEqual(0, i.TradeVolume); });

            Assert.AreEqual(100000.00, pairs.Select(i => i.TradeVolume).Sum());

            Assert.AreEqual(1, pairs.Select(i => i.Weight).Sum());
        }
    }
}