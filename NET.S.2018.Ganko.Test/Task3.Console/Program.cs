namespace Task3.Console
{
    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock();
            var bank = new Bank("Belarusbank", stock);
            var broker = new Broker("Vasya", stock);

            stock.Market();

            Console.WriteLine($"\nBroker {broker.Name} stopped trading");
            broker.StopTrade(stock);

            stock.Market();
        }
    }
}
