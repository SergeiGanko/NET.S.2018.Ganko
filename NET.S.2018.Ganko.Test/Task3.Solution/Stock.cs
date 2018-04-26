using System;

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

        public void Market()
        {
            Random rnd = new Random();
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
        }
    }
}
