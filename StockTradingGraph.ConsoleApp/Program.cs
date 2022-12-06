using StockTradingGraph.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockTradingGraph.ConsoleApp
{
    class Program
    {
        private const string MarketDataDirectory = "";
        private const double Balance = 100000.00;

        private static string[] Symbols = { "GOOG", "IBM", "XOM" };

        static void Main(string[] args)
        {
            var marketData = CsvUtils.ReadAllDataFrom(MarketDataDirectory, 4, false);

            var selectedShares = marketData.ToList().FindAll(i => Symbols.Contains(i.Name));

            var financialPairs = FinancialPair.CreateMany(selectedShares);

            var riskManager = new RiskManager(financialPairs, Balance);
            riskManager.Calculate();

            DisplayResults(financialPairs);

            Console.WriteLine("PRESS 'ENTER' TO EXIT.");
            Console.ReadLine();
        }

        static void DisplayResults(IEnumerable<FinancialPair> pairs)
        {
            foreach(var pair in pairs)
            {
                var result = $"[{pair.Name}]\n";
                result += $"Weight={pair.Weight} TradeVolume={pair.TradeVolume}\n";
                result += $"{pair.X.Name}={pair.X.TradeVolume} {pair.Y.Name}={pair.Y.TradeVolume}\n\n";
                Console.WriteLine(result);
            }
        }
    }
}
