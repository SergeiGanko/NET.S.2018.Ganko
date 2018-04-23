using System;
using Task3.Solution;

namespace Task3
{
    public class Stock
    {
        public event EventHandler<StockInfoEventArgs> NewStockInfo = delegate { };

        public void Market()
        {
            Random rnd = new Random();
            
            OnStockUpdate(this, new StockInfoEventArgs(rnd.Next(20, 40), rnd.Next(30, 50)));
        }

        private void OnStockUpdate(object sender, StockInfoEventArgs e)
        {
            EventHandler<StockInfoEventArgs> tempHandler = NewStockInfo;
            tempHandler?.Invoke(sender, e);
        }
    }
}
