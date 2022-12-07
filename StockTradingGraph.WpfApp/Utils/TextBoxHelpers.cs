using System;
using System.Globalization;
using System.Windows.Controls;

namespace StockTradingGraph.WpfApp
{
    public static class TextBoxHelpers
    {
        public static int GetInt32(this TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out int result))
            {
                throw new Exception($"{textBox.Name} has incorrect value.");
            }
            return result;
        }

        public static double GetDouble(this TextBox textBox)
        {
            if (!double.TryParse(textBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double result))
            {
                throw new Exception($"{textBox.Name} has incorrect value.");
            }
            return result;
        }
    }
}
