using Anagram.Service;
using System;
using System.IO;

namespace Anagram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var anagramText = args[1];
            var path = args[0];
            var now = DateTime.Now;

            WordProcessor wordProcessor = new WordProcessor(anagramText,2);


            foreach (var word in File.ReadAllLines(path))
            {
                wordProcessor.ProcessWord(word);
            }


            var duration = DateTime.Now - now;

            var allAnagrams = wordProcessor.GetAllAnagrams();

            Console.WriteLine($"Execution time: {duration.TotalSeconds:0.###} seconds");
        }
    }
}
