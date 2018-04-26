using System;
<<<<<<< HEAD

namespace Task3.Solution
{
    public class Stock
    {
        private readonly StockInfo stocksInfo;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public virtual event EventHandler<NewMarketEventArgs> NewMarket;
=======
using Task3.Solution;

namespace Task3
{
    public class Stock
    {
        public event EventHandler<StockInfoEventArgs> NewStockInfo = delegate { };
>>>>>>> faab1fb7da84fd609ad27ce7feb22acdfdf0ffa8

        public void Market()
        {
            Random rnd = new Random();
<<<<<<< HEAD
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            NewMarket?.Invoke(this, new NewMarketEventArgs(stocksInfo));
        }
    }

    public class NewMarketEventArgs
    {
        private StockInfo stocksinfo;

        public NewMarketEventArgs(StockInfo stocksInfo)
        {
            this.stocksinfo = stocksInfo;
=======
            
            OnStockUpdate(this, new StockInfoEventArgs(rnd.Next(20, 40), rnd.Next(30, 50)));
        }

        private void OnStockUpdate(object sender, StockInfoEventArgs e)
        {
            EventHandler<StockInfoEventArgs> tempHandler = NewStockInfo;
            tempHandler?.Invoke(sender, e);
>>>>>>> faab1fb7da84fd609ad27ce7feb22acdfdf0ffa8
        }
    }
}
