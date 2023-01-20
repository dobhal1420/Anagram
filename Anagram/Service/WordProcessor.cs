using Anagram.Helper;
using Anagram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram.Service
{
    public class WordProcessor
    {
        private Dictionary<char, int> _deconstructedWordToAnalyse;
        private int _minLength;
        private List<TextFragment> _potentialTextFragments;
        public WordProcessor(string wordToAnalyse, int minLength)
        {
            _deconstructedWordToAnalyse = DeconstructWord(wordToAnalyse);
            _minLength = minLength;
            _potentialTextFragments = new List<TextFragment>();

        }

        public bool ProcessWord(string word)
        {
            if (word.Length <= _minLength)
                return false;

            var lowerCaseWord = word.ToLowerInvariant();

            StringBuilder matchedWord = new StringBuilder();

            Dictionary<char, int> remainingUnmatched = new Dictionary<char, int>(_deconstructedWordToAnalyse);

            foreach (char c in lowerCaseWord)
            {
                if (!remainingUnmatched.TryGetValue(c, out var count))
                {
                    return false;
                }

                if (count == 1)
                {
                    remainingUnmatched.Remove(c);
                }
                else
                {
                    remainingUnmatched[c] -= 1;
                }

                matchedWord.Append(c);

            }

            int totalUnMatchedCharacterLeft = remainingUnmatched.Values.Sum();
            if (totalUnMatchedCharacterLeft <= _minLength)
                return false;

            string matchedWordStr = matchedWord.ToString();
            SearchForExistingPotentialMatch(matchedWordStr);


            AddPotentialMatch(new List<string>() { matchedWordStr }, remainingUnmatched);


            return true;


        }

        public List<string> GetAllAnagrams()
        {
            var allAnagrams = _potentialTextFragments.Where(x => x.isAnagram).ToList();
            var result = allAnagrams.Select(x => string.Join(" ", x.MatchedWords));
            return result.OrderBy(o=>o).ToList();
        }

        private void SearchForExistingPotentialMatch(string word)
        {
            var nonAnagramPotentialTextFragments = _potentialTextFragments.Where(x => !x.isAnagram).ToList();
            foreach (var potentialTextFragment in nonAnagramPotentialTextFragments)
                CheckPotentialAndAnagrams(word, potentialTextFragment);
        }

        private void CheckPotentialAndAnagrams(string word, TextFragment potentialTextFragment)
        {
            Dictionary<char, int> remainingUnmatched = new Dictionary<char, int>(potentialTextFragment.UnMatchedSegment);
            StringBuilder matchedWord = new StringBuilder();
            foreach (char c in word)
            {
                if (!remainingUnmatched.TryGetValue(c, out var count))
                {
                    return;
                }

                if (count == 1)
                {
                    remainingUnmatched.Remove(c);
                }
                else
                {
                    remainingUnmatched[c] -= 1;
                }

                matchedWord.Append(c);

            }

            int totalUnMatchedCharacterLeft = remainingUnmatched.Values.Sum();
            List<string> matchedWords = new List<string>(potentialTextFragment.MatchedWords);
            matchedWords.Add(matchedWord.ToString());
            if (totalUnMatchedCharacterLeft < _minLength)
            {
                if (totalUnMatchedCharacterLeft == 0)
                {
                    AddPotentialMatch(matchedWords, remainingUnmatched);
                }
                else
                {
                    return;
                }
            }
            else
            {
                AddPotentialMatch(matchedWords, remainingUnmatched);
            }
        }

        private void AddPotentialMatch(List<string> matchedwords, Dictionary<char, int> remainingUnmatched)
        {

            var potentialMatch = new TextFragment();
            potentialMatch.MatchedWords.AddRange(matchedwords);
            potentialMatch.UnMatchedSegment = remainingUnmatched;
            potentialMatch.isAnagram = remainingUnmatched.Count == 0 ? true : false;

            _potentialTextFragments.Add(potentialMatch);


        }

        private Dictionary<char, int> DeconstructWord(string wordToAnalyse)
        {
            var filteredWord = StringHelper.RemoveSpecialCharacters(wordToAnalyse).ToLowerInvariant();
            Dictionary<char, int> deconstructedWord = new Dictionary<char, int>();

            foreach (var c in filteredWord)
            {
                if (deconstructedWord.TryGetValue(c, out int value))
                {
                    value++;
                    deconstructedWord[c] = value;
                }
                else
                {
                    deconstructedWord.Add(c, 1);
                }

            }

            return deconstructedWord;

        }
    }
}
