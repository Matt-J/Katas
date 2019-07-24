using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramLogic
{
    public class AnagramFinder : IAnagramFinder
    {
        public IEnumerable<string> GetAnagramsInListForSpecificWord(IEnumerable<string> baseWordList, string targetWord)
        {
            string sortedTargetWord = SortLetters(targetWord);
        
            var wordList = baseWordList
                .Select(v => new {key = SortLetters(v), value = v})
                .ToList();
            
            return wordList
                .Where(v=>v.key.Equals(sortedTargetWord, StringComparison.OrdinalIgnoreCase))
                .Where(w=>!w.value.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
                .Select(s=>s.value);
        }

        private string SortLetters(string word)
        {
            return new String(word.ToCharArray().OrderBy(v => v).ToArray());
        }
    }
}
