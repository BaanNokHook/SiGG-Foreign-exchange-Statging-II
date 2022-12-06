using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace StockTradingGraph.Infrastructure
{
    public static class CsvUtils
    {
        public static Stock[] ReadAllDataFrom(string directory, int priceIndex, bool containsHeader)  
        {
            Check.NotNull(directory);

            if (priceIndex < 0) throw new ArgumentException("[priceIndex] can't be less than 0.");
            List<Stock> stocks = new List<Stock>();

            foreach (string file in Directory.EnumerateFiles(directory))
            {
                if (file.EndsWith(".txt") || file.EndsWith(".csv"))
                {
                    Stock stock = Read(file, priceIndex, containsHeader);

                    stocks.Add(stock);
                }
            }

            if (stocks.Count == 0)
            {
                throw new Exception("Files are not found.");
            }

            return stocks.ToArray();
        }

        public static Stock Read(string path, int priceIndex, bool containsHeader)
        {
            string[] lines = File.ReadAllLines(path);

            List<double> result = new List<double>();

            int startlineCount = containsHeader ? 1 : 0;

            for (int i = startlineCount; i < lines.Length; i++)
            {
                string[] cuts = lines[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (cuts.Length == 0)
                    throw new FormatException("Check csv files format.");

                double price = double.Parse(cuts[priceIndex], CultureInfo.InvariantCulture);

                if (price <= 0)
                {
                    throw new FormatException($" price = {price} in {path}");
                }
                result.Add(price);
            }

            string name = Path.GetFileNameWithoutExtension(path);

            return new Stock { Name = name, Prices = result.ToArray() };
        }
    }

    public class Stock
    {
    }
}
