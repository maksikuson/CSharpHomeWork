using System.Text;

namespace _03_String
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region task1

            string original = "hello world";
            Console.WriteLine("The original string: '{0}'", original);
            string modified = original.Insert(6, "all ");
            Console.WriteLine("The modified string: '{0}'", modified);

            #endregion

            #region task2

            string originals = "tot";
            string reversed = new string(originals.Reverse().ToArray());
            var polidrom = originals == reversed;
            Console.WriteLine($"String polidrome : {polidrom} ");

            #endregion

            #region task3

            string text = "Bigaye Po poly veselo Kabanchik";
            int totalChars = text.Length;
            int lowerCaseCount = 0;
            int upperCaseCount = 0;

            foreach (char c in text)
            {
                if (char.IsLower(c))
                {
                    lowerCaseCount++;
                }
                else if (char.IsUpper(c))
                {
                    upperCaseCount++;
                }
            }

            double lowerCasePercentage = (double)lowerCaseCount / totalChars * 100;
            double upperCasePercentage = (double)upperCaseCount / totalChars * 100;

            Console.WriteLine($"Total characters: {totalChars}");
            Console.WriteLine($"Lowercase letters: {lowerCaseCount} ({lowerCasePercentage:F2}%)");
            Console.WriteLine($"Uppercase letters: {upperCaseCount} ({upperCasePercentage:F2}%)");

            #endregion

            #region task4

            string[] array = { "Maxim", "Family", "Car", "House", "Cat", "Telegram", "PC", "Basketboll" };
            int targetLenght = 8;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length >= targetLenght)
                {
                    if(array[i].Length >= targetLenght)
                    {
                        array[i] = new string('$', array[i].Length);
                    }
                    else
                    {
                        array[i] = array[i].Substring(0, array[i].Length - 3) + "$";
                    }
                }
            }
            foreach (var word in array)
            {
                Console.WriteLine(word); 
            }

            #endregion

            #region task5

            string loremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed volutpat orci. Nunc dapibus tellus vitae nulla venenatis pharetra. Sed interdum ultricies risus non lacinia. Aliquam erat volutpat. Duis suscipit sodales massa id condimentum. Donec sed sodales ante, a porttitor leo. Morbi cursus tincidunt magna, ac vulputate arcu gravida vulputate. Nam sollicitudin elementum nisl, a lacinia sapien pellentesque quis. Curabitur ut luctus orci, vel congue nisi.";
            int number;
            Console.WriteLine("Enter number : ");
            int num = int.Parse(Console.ReadLine()!);
            string[] words = loremText.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            if (num < 0 || num > words.Length)
            {
                Console.WriteLine("There is no word at this position in the text.");
            }
            else
            {
                Console.WriteLine("The word at position " + num + " is: " + words[num - 1]);
            }

            #endregion

            #region task6

            string texts = "Bigaye    Po    poly  veselo    Kabanchik";

            Console.WriteLine("Original string:");
            Console.WriteLine($"'{texts}'");

            texts = texts.Trim();
            string[] word1 = texts.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join("*", word1);

            Console.WriteLine("Formatted string:");
            Console.WriteLine($"'{result}'");

            #endregion

            #region task6

            StringBuilder sb = new StringBuilder();
            string input;
            bool endInput = false;

            Console.WriteLine("Enter words. Input stops when a word ends with a period ('.')");

            while (!endInput)
            {
                input = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input.EndsWith('.'))
                    {
                        endInput = true;
                    }
                    if (sb.Length > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append(input);
                }
            }
            string results = sb.ToString();

            Console.WriteLine("Resulting string: " + results);

            #endregion
        }
    }
}
