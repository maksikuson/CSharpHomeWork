namespace _05_ClassStructRef
{
    internal class Worker
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }


        private int age;
        public int Age
        {
            get { return age; }
            set { age = (value >= 18 && value < 65) ? value : throw new Exception(); }
        }
        private int salary;
        public int Salary
        {
            get { return salary; }
            set { salary =  (value > 0) ? value : throw new Exception(); }
        }

        private DateTime hireDate;
        public DateTime HireDate
        {
            get { return hireDate; }
            set {  hireDate = (value <= DateTime.Now) ? value : throw new Exception(); }
        }
        public Worker() : this("Default", "Default", 18, 1, DateTime.Now) { }
        public Worker(string name, string surName, int age, int salary, DateTime hireDate)
        {
            Name = name;
            SurName = surName;
            Age = age;
            Salary = salary;
            HireDate = hireDate;

        }
        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Last name: {SurName}");
            Console.WriteLine($"Age: {Age}");
        }
    }
    class Calculator
    {
        public int num1 { set; get; }
        public int num2 { set; get; }
        public void Addition()
        {
            Console.WriteLine($"Addition:{num1}+{num2}={num1 + num2} ");
        }

        public void Subtraction()
        {
            Console.WriteLine($"Addition:{num1}-{num2}={num1 - num2} ");

        }

        public void Multiplication()
        {
            Console.WriteLine($"Addition:{num1}*{num2}={num1 * num2} ");

        }
        public void Division()
        {
            if (num2 == 0)
            {
                Console.WriteLine("Division: Division by zero is not allowed.");
            }
            else
            {
                Console.WriteLine($"Division: {num1} / {num2} = {num1 / num2}");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();
                Console.Write("Enter name : ");
                workers[i].Name = Console.ReadLine();
                Console.Write("Enter last name : ");
                workers[i].SurName = Console.ReadLine();
                Console.Write("Enter age : ");
                try
                {
                    workers[i].Age = int.Parse(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect age");
                }
                Console.WriteLine("Enter salary");
                try
                {
                    workers[i].Salary = int.Parse(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect salary");
                }
                Console.WriteLine("Enter Hire date");
                try
                {
                    workers[i].HireDate = DateTime.Parse(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect hire date");
                }

                Calculator c = new Calculator();
                Console.Write("Enter the first number: ");
                c.num1 = int.Parse(Console.ReadLine()!);
                Console.Write("Enter the second number: ");
                c.num2 = int.Parse(Console.ReadLine()!);
                c.Addition();
                c.Subtraction();
                c.Multiplication();
                c.Division();

            }
        }
    }
}
