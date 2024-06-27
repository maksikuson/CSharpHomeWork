namespace _04_IntroToOOP
{
    partial class Freezer
    {
        private string nameModel;
        private int graduationYear;
        private int serialNumber;
        private int price;
        private int popularity;

        public static int StandardWarrantyYears;
        public static int TotalFreezersCreated;
        static Freezer()
        {

            StandardWarrantyYears = 2;
            TotalFreezersCreated = 0;
        }

        public string NameModel
        {
            get { return nameModel; }
            set { nameModel = value; }
        }
        public int GraduationYear
        {
            get { return graduationYear; }
            set
            {
                if (value > 2018 && value < 2024)
                {
                    graduationYear = value;
                }
            }
        }
        public int SerialNumber
        {
            get { return serialNumber; }
            set
            {
                if (value > 0)
                {
                    serialNumber = value;
                }
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0 && value < 50000)
                {
                    price = value;
                }
            }
        }

        public int Popularity
        {
            get { return popularity; }
            set
            {
                if (value > 0 && value <= 5)
                {
                    popularity = value;
                }
            }
        }

        public Freezer() : this("Unknown Model", 2022, 0, 0, 1) { }

        public Freezer(string nameModel) : this(nameModel, 2022, 0, 0, 1) { }

        public Freezer(string nameModel, int graduationYear) : this(nameModel, graduationYear, 0, 0, 1) { }

        public Freezer(string nameModel, int graduationYear, int serialNumber, int price, int popularity)
        {
            this.nameModel = nameModel;
            this.graduationYear = graduationYear;
            this.serialNumber = serialNumber;
            this.price = price;
            this.popularity = popularity;
            TotalFreezersCreated++;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Freezer Name: " + nameModel);
            Console.WriteLine("Freezer Price: $" + price);
            Console.WriteLine("Freezer Popularity: " + popularity);
            Console.WriteLine("Standard Warranty: " + StandardWarrantyYears + " years");
        }

        public void IncreasePopularity()
        {
            if (popularity < 5)
            {
                popularity++;
            }
        }

        public void DecreasePrice(int amount)
        {
            if (price - amount > 0)
            {
                price -= amount;
            }
        }

        public void UpdatePrice(ref int newPrice)
        {
            if (newPrice > 0 && newPrice < 50000)
            {
                price = newPrice;
            }
        }

        public override string ToString()
        {
            return $"Freezer Name : {nameModel}, Graduation Year: {graduationYear}, Serial Number: {serialNumber}, Price: ${price}, Popularity:{popularity}, Standard Warranty: {StandardWarrantyYears} years";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer[] freezers = new Freezer[]
            {
                new Freezer("Samsung", 2019, 12345, 1500, 4),
                new Freezer("LG", 2020, 67890, 2000, 3),
                new Freezer("Vestfrost", 2018, 11111, 1000, 5),
                new Freezer("Beko", 2021, 16555, 2500, 2),
                new Freezer("Haier", 2022, 33333, 3000, 1)
            };

            Console.WriteLine("Freezer Menu Information:");
            Console.WriteLine();

            foreach (var freezer in freezers)
            {
                Console.WriteLine(freezer.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("Total Freezers Created: " + Freezer.TotalFreezersCreated);
        }
    }
}