using System;
using System.Threading;

namespace _12_ExtensionmetodsEvents
{
    public class PriceChangedEventArgs : EventArgs
    {
        public decimal NewPrice { get; }
        public PriceChangedEventArgs(decimal newPrice)
        {
            NewPrice = newPrice;
        }
    }

    public class Exchange
    {
        private decimal currentPrice;
        private decimal maxPrice;
        private decimal minPrice;

        private Timer priceChangeTimer;
        private Random random;
        private AutoResetEvent autoEvent;

        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        public event EventHandler<PriceChangedEventArgs> MaxPriceReached;
        public event EventHandler<PriceChangedEventArgs> MinPriceReached;

        public Exchange(decimal initialPrice, decimal maxPrice, decimal minPrice)
        {
            currentPrice = initialPrice;
            this.maxPrice = maxPrice;
            this.minPrice = minPrice;
            random = new Random();
            autoEvent = new AutoResetEvent(true);
            priceChangeTimer = new Timer(OnPriceChange, autoEvent, 0, 1000);
        }

        private void OnPriceChange(object state)
        {
            autoEvent.WaitOne();

            currentPrice += (decimal)(random.NextDouble() * 2 - 1);
            currentPrice = Math.Round(currentPrice, 2);

            PriceChanged?.Invoke(this, new PriceChangedEventArgs(currentPrice));

            if (currentPrice >= maxPrice)
            {
                MaxPriceReached?.Invoke(this, new PriceChangedEventArgs(currentPrice));
            }

            if (currentPrice <= minPrice)
            {
                MinPriceReached?.Invoke(this, new PriceChangedEventArgs(currentPrice));
            }
        }
        public void Stop()
        {
            priceChangeTimer?.Change(Timeout.Infinite, 0);
        }
        public void Pause()
        {
            autoEvent.Reset();
        }
        public void Resume()
        {
            autoEvent.Set();
        }
    }

    public class Trader
    {
        public string Name { get; }
        public decimal CurrencyAmount { get; private set; }
        public decimal Cash { get; private set; }

        public Trader(string name, decimal initialCurrencyAmount, decimal initialCash)
        {
            Name = name;
            CurrencyAmount = initialCurrencyAmount;
            Cash = initialCash;
        }

        public void Subscribe(Exchange exchange)
        {
            exchange.PriceChanged += OnPriceChanged;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            exchange.MaxPriceReached += OnMaxPriceReached;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            exchange.MinPriceReached += OnMinPriceReached;
        }

        private void OnPriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine($"{Name} observed price change to {e.NewPrice}");
        }

        private void OnMaxPriceReached(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine($"{Name} observed max price reached : {e.NewPrice}");
            Sell(e.NewPrice);
        }

        private void OnMinPriceReached(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine($"{Name} observed min price reached : {e.NewPrice}");
            Buy(e.NewPrice);
        }

        private void Buy(decimal price)
        {
            decimal amountToBuy = Cash / price;
            CurrencyAmount += amountToBuy;
            Cash -= amountToBuy * price;
            Console.WriteLine($"{Name} bought {amountToBuy} currency at {price}, new balance: {CurrencyAmount} currency, {Cash} cash");
        }

        private void Sell(decimal price)
        {
            decimal amountToSell = CurrencyAmount;
            Cash += amountToSell * price;
            CurrencyAmount = 0;
            Console.WriteLine($"{Name} sold {amountToSell} currency at {price}, new balance: {CurrencyAmount} currency, {Cash} cash");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange(initialPrice: 50m, maxPrice: 55m, minPrice: 45m);

            Trader trader1 = new Trader(name: "Trader1", initialCurrencyAmount: 10m, initialCash: 500m);
            Trader trader2 = new Trader(name: "Trader2", initialCurrencyAmount: 20m, initialCash: 1000m);

            trader1.Subscribe(exchange);
            trader2.Subscribe(exchange);

            while (true)
            {
                ShowControlMenu();
                int controlChoice = GetValidInput(1, 3);

                if (controlChoice == 1)
                {
                    exchange.Pause();
                    Console.WriteLine("Exchange paused.");
                }
                else if (controlChoice == 2)
                {
                    exchange.Resume();
                    Console.WriteLine("Exchange resumed.");
                }
                else if (controlChoice == 3)
                {
                    exchange.Stop();
                    Console.WriteLine("Exchange stopped. Press Enter to exit...");
                    break;
                }
            }
            Console.ReadLine();
        }

        static void ShowControlMenu()
        {
            Console.WriteLine(" Choose an action : ");
            Console.WriteLine("1. Pause the exchange");
            Console.WriteLine("2. Resume the exchange");
            Console.WriteLine("3. Stop the exchange");
        }

        static int GetValidInput(int min, int max)
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
            return choice;
        }
    }
}
