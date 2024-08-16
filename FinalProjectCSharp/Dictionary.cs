using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DictionaryApp
{
    public class Dictionary
    {
        public string Name { get; private set; }
        public List<WordTranslation> Translations { get; private set; }

        public Dictionary(string name)
        {
            Name = name;
            Translations = new List<WordTranslation>();
        }

        public void AddWord(string word, string translation)
        {
            var wordTranslation = Translations.Find(t => t.Word == word);
            if (wordTranslation != null)
            {
                wordTranslation.Translations.Add(translation);
            }
            else
            {
                Translations.Add(new WordTranslation(word, translation));
            }
        }

        public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
        {
            var wordTranslation = Translations.Find(t => t.Word == word);
            if (wordTranslation != null)
            {
                int index = wordTranslation.Translations.IndexOf(oldTranslation);
                if (index != -1)
                {
                    wordTranslation.Translations[index] = newTranslation;
                }
            }
        }

        public void RemoveWord(string word)
        {
            Translations.RemoveAll(t => t.Word == word);
        }

        public void RemoveTranslation(string word, string translation)
        {
            var wordTranslation = Translations.Find(t => t.Word == word);
            if (wordTranslation != null)
            {
                if (wordTranslation.Translations.Count > 1)
                {
                    wordTranslation.Translations.Remove(translation);
                }
            }
        }

        public string SearchTranslation(string word)
        {
            var wordTranslation = Translations.Find(t => t.Word == word);
            if (wordTranslation != null)
            {
                return string.Join(", ", wordTranslation.Translations);
            }
            return "Translation not found.";
        }

        public void SaveToFile()
        {
            using (StreamWriter file = new StreamWriter($"{Name}.txt"))
            {
                var sortedTranslations = Translations.OrderBy(t => t.Word).ToList();
                foreach (var translation in sortedTranslations)
                {
                    file.WriteLine($"{translation.Word}:{string.Join(",", translation.Translations)}");
                }
            }
            Console.WriteLine("Dictionary saved.");
        }

        public void LoadFromFile(string fileName)
        {
            Translations.Clear();
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var word = parts[0];
                    var translations = parts[1].Split(',');
                    Translations.Add(new WordTranslation(word, translations));
                }
            }
        }
    }

    public class WordTranslation
    {
        public string Word { get; private set; }
        public List<string> Translations { get; private set; }

        public WordTranslation(string word, string translation)
        {
            Word = word;
            Translations = new List<string> { translation };
        }

        public WordTranslation(string word, string[] translations)
        {
            Word = word;
            Translations = new List<string>(translations);
        }
    }
}