using System;
using System.IO;
using System.Text.RegularExpressions;

namespace KASDLab26
{
    internal class Program
    {
        static void Main()
        {
            string[] rows = File.ReadAllLines("../../Data/input.txt");

            MyHashSet<string> uniqueWords = new MyHashSet<string>();

            string pattern = @"\b[a-zA-Z]+\b";

            foreach (string row in rows) {
                MatchCollection matches = Regex.Matches(row, pattern);

                foreach (Match match in matches)
                {
                    string word = match.Value.ToLower();
                    uniqueWords.Add(word);
                }
            }

            foreach (string word in uniqueWords.ToArray())
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }

    }
}
