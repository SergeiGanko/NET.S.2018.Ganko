using System;
<<<<<<< HEAD

namespace Task3.Solution
=======
using Task3.Solution;

namespace Task3
>>>>>>> faab1fb7da84fd609ad27ce7feb22acdfdf0ffa8
{
    public class Bank
    {
        public string Name { get; set; }

<<<<<<< HEAD
        public Bank(string name)
        {
            this.Name = name;
        }

        public void Update(object info)
        {
            StockInfo sInfo = (StockInfo)info;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
=======
        public Bank(string name, Stock stock)
        {
            this.Name = name;
            stock.NewStockInfo += Update;
        }

        public void Update(object sender, StockInfoEventArgs e)
        {
            if (e.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, e.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, e.Euro);
>>>>>>> faab1fb7da84fd609ad27ce7feb22acdfdf0ffa8
        }
    }
}
