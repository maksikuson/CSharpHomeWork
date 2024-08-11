using System.Text.RegularExpressions;
using System.Text;

namespace _17_Regex
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string filePath = "file.txt";
            if (!File.Exists(filePath))
            {
                string testContent = "16 12.86 -13 44 66 88,3 100 13 -20";
                File.WriteAllText(filePath, testContent);
                Console.WriteLine("The file was created with test content.");
            }

            string content = File.ReadAllText(filePath);
            Regex fractionalRegex = new Regex(@"\b\d+(\.\d+|,\d+)\b");
            MatchCollection fractionalMatches = fractionalRegex.Matches(content);
            List<string> fractionalNumbers = new List<string>();

            foreach (Match match in fractionalMatches)
            {
                fractionalNumbers.Add(match.Value);
            }
            Console.WriteLine("Fractional numbers :");
            foreach (string number in fractionalNumbers)
            {
                Console.WriteLine(number);
            }
            Regex integerRegex = new Regex(@"\b\d+\b");
            MatchCollection integerMatches = integerRegex.Matches(content);
            List<int> integerNumbers = new List<int>();

            foreach (Match match in integerMatches)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    integerNumbers.Add(number);
                }
            }
            Console.WriteLine("\nInteger numbers :");
            foreach (int number in integerNumbers)
            {
                Console.WriteLine(number);
            }
            var positiveNumbers = integerNumbers.Where(n => n > 0).OrderBy(n => n);

            Console.WriteLine("\nPositive numbers sorted by growth :");
            foreach (int number in positiveNumbers)
            {
                Console.WriteLine(number);
            }
            var twoDigitPositives = integerNumbers.Where(n => n >= 10 && n < 100);
            int count = twoDigitPositives.Count();
            double average = twoDigitPositives.Any() ? twoDigitPositives.Average() : 0;
            Console.WriteLine($"\nNumber of positive two-digit numbers : {count}");
            Console.WriteLine($"The arithmetic mean of positive two-digit numbers : {average}");
        }
    }
}
