using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTradingGraph.Infrastructure;
using System.Linq;

namespace StockTradingGraph.UnitTests
{
    [TestClass()]
    public class CsvUtilTests
    {
        [TestMethod()]  
        public void Read_Test()
        {
            Stock aapl = CsvUtils.Read("csv-samples/AAPL.txt", priceIndex: 4, containsHeader: false);

            Assert.AreEqual(473, aapl.Prices.Length);
            Assert.AreEqual(553.12999, aapl.Prices.First());
            Assert.AreEqual(114.18, aapl.Prices.Last());
        }

        [TestMethod()]  
        public void ReadAllDataFrom_Test()
        {
            Stock[] stocks = CsvUtils.ReadAllDataFrom("csv-samples/", priceIndex: 4, containsHeader: false);

            Assert.AreEqual(3, stocks.Length);     

            foreach (var stock in stocks)
            {
                Assert.AreEqual(473, stock.Prices.Length);  
            }
        }
    }
}
