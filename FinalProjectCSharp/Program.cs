using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DictionaryApp
{
    class Program
    {
        static List<Dictionary> dictionaries = new List<Dictionary>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Create Dictionary");
                Console.WriteLine("2. Select Dictionary");
                Console.WriteLine("3. Load Dictionary from File");
                Console.WriteLine("4. View All Dictionaries");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateDictionary();
                        break;
                    case "2":
                        SelectDictionary();
                        break;
                    case "3":
                        LoadDictionaryFromFile();
                        break;
                    case "4":
                        ViewAllDictionaries();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using the Dictionary App!");
                        Console.Write("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CreateDictionary()
        {
            Console.Write("Enter the name of the dictionary (e.g., English-Ukrainian): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                dictionaries.Add(new Dictionary(name));
                Console.WriteLine($"Dictionary '{name}' created.");
            }
            else
            {
                Console.WriteLine("Invalid dictionary name. Please try again.");
            }
            Console.Write("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void SelectDictionary()
        {
            if (dictionaries.Count == 0)
            {
                Console.WriteLine("Dictionaries not yet created.");
                Console.Write("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Available dictionaries:");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].Name}");
            }

            Console.Write("Select a dictionary by number: ");
            if (int.TryParse(Console.ReadLine(), out int dictNumber) && dictNumber > 0 && dictNumber <= dictionaries.Count)
            {
                DictionaryMenu(dictionaries[dictNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                Console.Write("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void DictionaryMenu(Dictionary selectedDictionary)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Dictionary: {selectedDictionary.Name}");
                Console.WriteLine("1. Add Word and Translation");
                Console.WriteLine("2. Replace Word Translation");
                Console.WriteLine("3. Remove Word");
                Console.WriteLine("4. Remove Word Translation");
                Console.WriteLine("5. Search for Translation");
                Console.WriteLine("6. Save Dictionary to File");
                Console.WriteLine("7. View All Words and Translations");
                Console.WriteLine("8. Go Back");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddWord(selectedDictionary);
                        break;
                    case "2":
                        ReplaceTranslation(selectedDictionary);
                        break;
                    case "3":
                        RemoveWord(selectedDictionary);
                        break;
                    case "4":
                        RemoveTranslation(selectedDictionary);
                        break;
                    case "5":
                        SearchTranslation(selectedDictionary);
                        break;
                    case "6":
                        selectedDictionary.SaveToFile();
                        Console.WriteLine("Dictionary saved.");
                        Console.Write("Press any key to return to the dictionary menu...");
                        Console.ReadKey();
                        break;
                    case "7":
                        ViewAllWordsAndTranslations(selectedDictionary);
                        break;
                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid selection.");
                        Console.Write("Press any key to return to the dictionary menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ViewAllWordsAndTranslations(Dictionary dictionary)
        {
            Console.Clear();
            Console.WriteLine($"All words and translations in dictionary: {dictionary.Name}");

            foreach (var translation in dictionary.Translations)
            {
                Console.WriteLine($"Word: {translation.Word}");
                Console.WriteLine("Translations: " + string.Join(", ", translation.Translations));
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void LoadDictionaryFromFile()
        {
            Console.Write("Enter the name of the dictionary to load (e.g., English-Ukrainian): ");
            var name = Console.ReadLine();
            var fileName = name.EndsWith(".txt") ? name : $"{name}.txt";

            Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");

            if (File.Exists(fileName))
            {
                var dictionary = new Dictionary(name);
                dictionary.LoadFromFile(fileName);
                dictionaries.Add(dictionary);
                Console.WriteLine($"Dictionary '{name}' loaded from file.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist.");
            }

            Console.Write("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void AddWord(Dictionary dictionary)
        {
            Console.Write("Enter the word: ");
            var word = Console.ReadLine();
            Console.Write("Enter the translation: ");
            var translation = Console.ReadLine();
            dictionary.AddWord(word, translation);
            Console.WriteLine("Word and translation added.");
            Console.ReadKey();
        }

        static void ReplaceTranslation(Dictionary dictionary)
        {
            Console.Write("Enter the word: ");
            var word = Console.ReadLine();
            Console.Write("Enter the old translation: ");
            var oldTranslation = Console.ReadLine();
            Console.Write("Enter the new translation: ");
            var newTranslation = Console.ReadLine();
            dictionary.ReplaceTranslation(word, oldTranslation, newTranslation);
            Console.WriteLine("Translation replaced.");
            Console.ReadKey();
        }

        static void RemoveWord(Dictionary dictionary)
        {
            Console.Write("Enter the word to remove: ");
            var word = Console.ReadLine();
            dictionary.RemoveWord(word);
            Console.WriteLine("Word removed.");
            Console.ReadKey();
        }

        static void RemoveTranslation(Dictionary dictionary)
        {
            Console.Write("Enter the word: ");
            var word = Console.ReadLine();
            Console.Write("Enter the translation to remove: ");
            var translation = Console.ReadLine();
            dictionary.ReplaceTranslation(word, translation, "");
            Console.WriteLine("Translation removed.");
            Console.ReadKey();
        }

        static void SearchTranslation(Dictionary dictionary)
        {
            Console.Write("Enter the word to search: ");
            var word = Console.ReadLine();
            Console.WriteLine(dictionary.SearchTranslation(word));
            Console.ReadKey();
        }
        static void ViewAllDictionaries()
        {
            Console.Clear();
            if (dictionaries.Count == 0)
            {
                Console.WriteLine("No dictionaries available.");
            }
            else
            {
                foreach (var dictionary in dictionaries)
                {
                    Console.WriteLine($"Dictionary: {dictionary.Name}");
                }
            }
            Console.Write("Press any key to return to the main menu...");
            Console.ReadKey();
        }

    }
}