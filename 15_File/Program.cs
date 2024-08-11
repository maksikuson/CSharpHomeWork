using System.Text;

namespace _15_File
{
    internal class Program
    {
        private static void EnterArrayAndSaveToFile()
        {
            Console.WriteLine("Enter the number of elements in the array:");
            int n = int.Parse(Console.ReadLine()!);

            int[] array = new int[n];
            Console.WriteLine("Enter the elements of the array:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine()!);
            }

            Console.WriteLine("Enter the path to the file to save the array:");
            string filePath = Console.ReadLine()!;

            try
            {
                SaveArrayToFile(array, filePath);
                Console.WriteLine("Array has been successfully saved to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }
        }

        private static void LoadArrayFromFile()
        {
            Console.WriteLine("Enter the path to the file to load the array:");
            string filePath = Console.ReadLine()!;

            try
            {
                int[] array = LoadArrayFromFile(filePath);
                Console.WriteLine("Array has been successfully loaded from the file. Elements:");
                foreach (int item in array)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
            }
        }

        public static void SaveArrayToFile(int[] array, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int item in array)
                {
                    writer.WriteLine(item);
                }
            }
        }

        public static int[] LoadArrayFromFile(string filePath)
        {
            List<int> arrayList = new List<int>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()!) != null)
                {
                    arrayList.Add(int.Parse(line));
                }
            }
            return arrayList.ToArray();
        }

        public static void SaveNumbersToFile(int[] numbers, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }
        static void SearchWord(string content, string word)
        {
            int index = content.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                Console.WriteLine($"The word is found in the position{index}.");
            }
            else
            {
                Console.WriteLine("The word is not found ");
            }
        }

        static void CountWordOccurrences(string content, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = content.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            Console.WriteLine($"The number of occurrences of the word \"{word}\": {count}.");
        }

        static void CountReverseWordOccurrences(string content, string word)
        {
            string reversedWord = new string(word.ToCharArray().Reverse().ToArray());
            int count = 0;
            int index = 0;

            while ((index = content.IndexOf(reversedWord, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += reversedWord.Length;
            }

            Console.WriteLine($"The number of occurrences of the word in reverse \"{reversedWord}\": {count}.");
        }
        static int CountSentences(string content)
        {
            char[] sentenceEndings = { '.', '!', '?' };
            return content.Count(c => sentenceEndings.Contains(c));
        }

        static int CountUpperCaseLetters(string content)
        {
            return content.Count(char.IsUpper);
        }

        static int CountLowerCaseLetters(string content)
        {
            return content.Count(char.IsLower);
        }

        static int CountVowels(string content)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return content.Count(c => vowels.Contains(c));
        }

        static int CountConsonants(string content)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return content.Count(c => char.IsLetter(c) && !vowels.Contains(c));
        }

        static int CountDigits(string content)
        {
            return content.Count(char.IsDigit);
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            //Task1
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine()!;

            if (File.Exists(filePath))
            {
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    Console.WriteLine("File content:");
                    Console.WriteLine(fileContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Error: The file does not exist.");
            }

            //Task 2,3
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Enter array and save to file");
                Console.WriteLine("2. Load array from file");

                int choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        EnterArrayAndSaveToFile();
                        break;
                    case 2:
                        LoadArrayFromFile();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            //Task4
            const int numberOfRandomNumbers = 1000;
            const string evenNumbersFilePath = "even_numbers.txt";
            const string oddNumbersFilePath = "odd_numbers.txt";

            Random random = new Random();
            int[] randomNumbers = new int[numberOfRandomNumbers];
            for (int i = 0; i < numberOfRandomNumbers; i++)
            {
                randomNumbers[i] = random.Next()!;
            }
            var evenNumbers = randomNumbers.Where(n => n % 2 == 0).ToArray();
            var oddNumbers = randomNumbers.Where(n => n % 2 != 0).ToArray();
            SaveNumbersToFile(evenNumbers, evenNumbersFilePath);
            SaveNumbersToFile(oddNumbers, oddNumbersFilePath);
            Console.WriteLine($"Generated {numberOfRandomNumbers} random numbers.");
            Console.WriteLine($"Even numbers: {evenNumbers.Length}");
            Console.WriteLine($"Odd numbers: {oddNumbers.Length}");

            //Task5
            Console.WriteLine("Enter the file path:");
            string filePath0 = Console.ReadLine()!;

            if (!File.Exists(filePath0))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string fileContent0 = File.ReadAllText(filePath0);

            Console.WriteLine("Enter a word to search for:");
            string searchWord = Console.ReadLine()!;

            SearchWord(fileContent0, searchWord);
            CountWordOccurrences(fileContent0, searchWord);
            CountReverseWordOccurrences(fileContent0, searchWord);

            //Task6
            Console.WriteLine("Enter file path :");
            string filePath3 = Console.ReadLine()!;

            if (!File.Exists(filePath3))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string fileContentt = File.ReadAllText(filePath3);

            int sentenceCount = CountSentences(fileContentt);
            int upperCaseCount = CountUpperCaseLetters(fileContentt);
            int lowerCaseCount = CountLowerCaseLetters(fileContentt);
            int vowelCount = CountVowels(fileContentt);
            int consonantCount = CountConsonants(fileContentt);
            int digitCount = CountDigits(fileContentt);

            Console.WriteLine($"Number of sentences : {sentenceCount}");
            Console.WriteLine($"Number of capital letters : {upperCaseCount}");
            Console.WriteLine($"Number of small letters : {lowerCaseCount}");
            Console.WriteLine($"Number of vowels : {vowelCount}");
            Console.WriteLine($"Number of consonants : {consonantCount}");
            Console.WriteLine($"Number of digits : {digitCount}");

           
        }
    }
}
