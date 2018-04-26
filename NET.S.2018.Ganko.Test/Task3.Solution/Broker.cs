using System;

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
    }
}
