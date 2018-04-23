using System;

namespace Task3.Solution
{
    public class StockInfoEventArgs : EventArgs
    {
        public StockInfoEventArgs(int usd, int euro)
        {
            USD = usd;
            Euro = euro;
        }

        public int USD { get; }
        public int Euro { get; }
    }
}
