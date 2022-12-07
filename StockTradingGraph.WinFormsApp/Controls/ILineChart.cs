
namespace StockTradingGraph.Controls
{
    public interface ILineChart
    {
        void ClearSMA();
        void ClearWMA();
        void SetCurrentDeltaValue(double currentDelta);
        void SetDeltaValues(double[] values);
        void SetSMA(double[] values, int interval);
        void SetWMA(double[] values, int interval);
    }
}