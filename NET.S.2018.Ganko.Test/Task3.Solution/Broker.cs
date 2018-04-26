using System;
<<<<<<< HEAD

namespace Task3.Solution
{
    public class Broker
    {

        public string Name { get; set; }

        public Broker(string name)
        {
            this.Name = name;
        }

        public void Update(object info)
        {
            StockInfo sInfo = (StockInfo)info;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }

        public void StopTrade()
        {
        }
=======
using Task3.Solution;

namespace Task3
{
    public class Broker
    {
        public string Name { get; set; }

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            stock.NewStockInfo += Update;
        }

        public void Update(object sender, StockInfoEventArgs e)
        {
            if (e.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, e.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, e.USD);
        }

        public void StopTrade(Stock stock) => stock.NewStockInfo -= Update;

        public void StartTrade(Stock stock) => stock.NewStockInfo += Update;
>>>>>>> faab1fb7da84fd609ad27ce7feb22acdfdf0ffa8
    }
}
