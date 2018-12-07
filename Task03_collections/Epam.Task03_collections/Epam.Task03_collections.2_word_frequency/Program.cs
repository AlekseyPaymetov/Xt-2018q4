using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03_collections._2_word_frequency
{
    public class Program
    {
        private const string SomeText = "Abc is abc and ABC. Qwerta is not abc.";
        private static string[] words;
        private static Dictionary<string, int> dictionary = new Dictionary<string, int>();

        public static void Main(string[] args)
        {
            ShowDefaultText();
            TextToArray();
            Array.Sort(words);
            CreateDictionaryOfWordsFromText();
            ShowDictionaryOnConsole();
        }

        private static void ShowDefaultText()
        {
            Console.WriteLine("Default text:");
            Console.WriteLine(SomeText);
        }

        private static void TextToArray()
        {
            words = SomeText.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
        }

        private static void CreateDictionaryOfWordsFromText()
        {
            string currentWord = words[0];
            int countOfWord = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == currentWord)
                {
                    countOfWord++;
                }
                else
                {
                    dictionary.Add(currentWord, countOfWord);
                    currentWord = words[i];
                    countOfWord = 1;
                }
            }

            dictionary.Add(currentWord, countOfWord);
        }

        private static void ShowDictionaryOnConsole()
        {
            Console.WriteLine();
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
