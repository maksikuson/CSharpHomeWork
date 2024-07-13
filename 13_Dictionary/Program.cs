using System.Text.RegularExpressions;

namespace _13_Dictionary
{
    class PhoneBook
    {
        Dictionary<string, string> phoneNum;

        public PhoneBook()
        {
            phoneNum = new Dictionary<string, string>();
        }

        public void AddUser(string username, string phoneNumber)
        {
            phoneNum.Add(username, phoneNumber);
        }

        public void DeleteUser(string username)
        {
            phoneNum.Remove(username);
        }

        public void ChangeUser(string username, string phoneNumber)
        {
            if (phoneNum.ContainsKey(username))
            {
                phoneNum[username] = phoneNumber;
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        public void SearchUser(string username)
        {
            if (phoneNum.ContainsKey(username))
            {
                Console.WriteLine($"{username}: {phoneNum[username]}");
            }
            else
            {
                Console.WriteLine($"User not found");
            }
        }

        public void Show()
        {
            foreach (var phoneNumber in phoneNum)
            {
                Console.WriteLine($"{phoneNumber.Key}: {phoneNumber.Value}");
            }
        }
    }
    public class WordCounter
    {
        public Dictionary<string, int> CountWords(string text)
        {
            var words = Regex.Matches(text.ToLower(), @"\b[\w']+\b");

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (Match match in words)
            {
                string word = match.Value;

                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            return wordCounts;
        }

        public void PrintWordCounts(Dictionary<string, int> wordCounts)
        {
            Console.WriteLine("Word\t\tQuantity");

            foreach (var entry in wordCounts.OrderByDescending(e => e.Value))
            {
                Console.WriteLine($"{entry.Key}\t\t{entry.Value}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Task1();*/
            Task2();
        }

        static void Task1()
        {
            PhoneBook phoneBook = new PhoneBook();

            phoneBook.AddUser("John Doe", "123-456-7890");
            phoneBook.AddUser("Jane Smith", "987-654-3210");

            phoneBook.SearchUser("John Doe");

            phoneBook.ChangeUser("John Doe", "111-222-3333");
            phoneBook.SearchUser("John Doe");

            phoneBook.Show();

            phoneBook.DeleteUser("Jane Smith");
            phoneBook.Show();
        }

        static void Task2()
        {
            string text = "This is the house that Jack built. And this is wheat, which\r\nin the dark pantry is stored in the house that\r\nJack built. And this is a cheerful tit bird that often steals\r\nshenitsa, which is stored in a dark pantry in the house ,\r\nwhich was built by Jack.";

            WordCounter wordCounter = new WordCounter();
            var wordCounts = wordCounter.CountWords(text);
            wordCounter.PrintWordCounts(wordCounts);
        }
    }
}
