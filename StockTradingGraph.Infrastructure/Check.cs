using System;

namespace StockTradingGraph.Infrastructure
{
    public static class Check  
    {
        public static void NotNull(params object[] items)
        {
            foreach (var item in items)
            {
                if (item == null)
                {
                    throw new ArgumentNullException();  
                }
            }
        }

    }

}



