using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DictionaryApp
{
    class Translation
    {
        public string Word { get; set; }
        public List<string> Translations { get; set; }

        public Translation(string word)
        {
            Word = word;
            Translations = new List<string>();
        }

        public void AddTranslation(string translation)
        {
            if (!Translations.Contains(translation))
            {
                Translations.Add(translation);
            }
        }

        public void RemoveTranslation(string translation)
        {
            if (Translations.Count > 1)
            {
                Translations.Remove(translation);
            }
            else
            {
                Console.WriteLine("Cannot remove the last translation for a word.");
            }
        }

        public override string ToString()
        {
            return $"{Word}: {string.Join(", ", Translations)}";
        }
    }
}