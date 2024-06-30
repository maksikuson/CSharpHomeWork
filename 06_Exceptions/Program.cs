namespace _06_Exceptions
{
    //2
    class CreditCard
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }

        private string? cardNumber;
        public string? CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value.Length != 16 ? throw new Exception("Enter correct number") : value; }
        }

        private int? cvv;
        public int? CVV
        { 
            get { return cvv; }
            set { cvv = (value >= 100 && value <= 999) ? value : throw new Exception("Enter correct CVV"); }
        }
        
        private DateTime dateEnd;
        public DateTime DateEnd
        { 
            get { return dateEnd; }
            set { dateEnd = (value >= DateTime.Now) ? value : throw new Exception("Incorrect expiry date"); }
        }

        public CreditCard(string? name, string? surName, string? cardNumber, int? cvv, DateTime dateEnd)
        {
            Name = name;
            SurName = surName;
            CardNumber = cardNumber;
            this.cvv = cvv;
            CVV = cvv;
            DateEnd = dateEnd;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Info user credit card : ");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"SurName : {SurName}");
            Console.WriteLine($"Card Number : {CardNumber}");
            Console.WriteLine($"CVV : {cvv}");
            Console.WriteLine($"Expiry Date : {dateEnd.ToShortDateString()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            /*Console.WriteLine("Enter string(0-9)");
            string str = Console.ReadLine()!;
            try
            {
                int number = int.Parse(str);
                Console.WriteLine(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR. Enter correct number");
                
            }*/

            //2
            try
            {
                CreditCard card = new CreditCard("Maxim", "Suprunets", "1123456789101112", 468, new DateTime(2023, 12, 31));
                card.ShowInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //3
            Console.WriteLine();
        }
    }
}
