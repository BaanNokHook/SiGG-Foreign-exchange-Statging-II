using StockTradingGraph.Infrastructure;
using StockTradingGraph.WpfApp.Entities;
using StockTradingGraph.WpfApp.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StockTradingGraph.WpfApp.Logic
{
    public class LogicMediator
    {
        public ExtFinancialPair SelectedPair { get; set; }
        public ObservableCollection<ExtFinancialPair> Pairs { get; set; }

        private DataGridControl dataGridControl;
        private InfoControl infoControl;
        private MyChartControl chartControl;

        public LogicMediator(Stock[] stocks, DataGridControl dataGridControl, 
            InfoControl infoControl, MyChartControl chartControl)
        {
            this.dataGridControl = dataGridControl ?? throw new ArgumentNullException(nameof(dataGridControl));
            this.infoControl = infoControl ?? throw new ArgumentNullException(nameof(infoControl));
            this.chartControl = chartControl ?? throw new ArgumentNullException(nameof(chartControl));

            Pairs = new ObservableCollection<ExtFinancialPair>(
                FinancialPair.CreateMany<ExtFinancialPair>(
                    stocks ?? throw new ArgumentNullException(nameof(stocks))
                    ));

            dataGridControl.InitDataGridControl(Pairs, UpdateInfoAndCharts);
            infoControl.InitInfoControl(Calculate, UpdateInfoAndCharts);
        }

        private void Calculate()
        {
            try
            {
                var checkedPairs = Pairs.Where(i => i.Selected).ToList();

                if (checkedPairs.Count > 0)
                {
                    //preparation
                    foreach (var pair in Pairs)
                    {
                        pair.TradeVolume = 0;
                        pair.X.TradeVolume = 0;
                        pair.Y.TradeVolume = 0;
                    }

                    new RiskManager(checkedPairs.ToArray(), infoControl.balance.GetDouble()).Calculate();

                    infoControl.Update(SelectedPair);
                }
                else
                {
                    WindowHelpers.Display("Pairs are not selected.");
                }
            }
            catch (Exception ex)
            {
                WindowHelpers.Display("CalculateRisk => " + ex.Message);
            }
        }

        private void UpdateInfoAndCharts()
        {
            try
            {
                if (dataGridControl.dataGrid.SelectedItem is ExtFinancialPair extFinancialPair)
                {
                    SelectedPair = extFinancialPair;

                    var SMAValue = infoControl.SMA.GetInt32();

                    if (SMAValue < 0) SMAValue = 0;

                    chartControl.Update(SelectedPair.DeltaValues, SelectedPair.Name, SMAValue);
                    infoControl.Update(SelectedPair);
                }
            }
            catch (Exception ex)
            {
                WindowHelpers.Display($"UpdateInfoAndCharts => {ex.Message}");
            }
        }
    }
}
