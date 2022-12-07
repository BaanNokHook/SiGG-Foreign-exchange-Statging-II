using System;
using System.Windows;
using System.Windows.Controls;

namespace StockTradingGraph.WpfApp.Utils
{
    public static class WindowHelpers
    {
        public static void Display(string message)
        {
            MessageBox.Show(message);
        }

        public static void Display(this UserControl control, string message)
        {
            control.Dispatcher.BeginInvoke((Action)(() => { MessageBox.Show(message); }));
        }

        public static void Display(this Window control, string message)
        {
            control.Dispatcher.BeginInvoke((Action)(() => { MessageBox.Show(message); }));
        }
    }
}
