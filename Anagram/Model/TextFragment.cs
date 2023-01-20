using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Model
{
    public class TextFragment
    {
        public List<string> MatchedWords { get; set; }

        public Dictionary<char, int> UnMatchedSegment { get; set; }

        public bool isAnagram { get; set; }

        public TextFragment()
        {
            MatchedWords = new List<string>();
            UnMatchedSegment = new Dictionary<char, int>();
            isAnagram = false;
        }
        

    }
}
