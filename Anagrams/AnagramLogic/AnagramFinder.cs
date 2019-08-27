using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramLogic
{
    public class AnagramFinder : IAnagramFinder
    {
        public List<string> GetAnagramsInListForSpecificWord(IEnumerable<string> baseWordList, string targetWord)
        {
            targetWord = WithoutIgnoredChars(targetWord);

            string sortedTargetWord = SortLetters(targetWord);

            var anagramsByKey = AnagramsByKey(baseWordList);

            return anagramsByKey
                .Where(v => WithoutIgnoredChars(v.Key).Equals(sortedTargetWord, StringComparison.OrdinalIgnoreCase))
                .SelectMany(s => s.Value)
                .Where(w => !w.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        Dictionary<string, List<string>> AnagramsByKey(IEnumerable<string> baseWordList)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var word in baseWordList)
            {
                var key = SortLetters(word);
                if (dict.ContainsKey(key))
                    dict[key].Add(word);
                else
                {
                    dict[key] = new List<string>{ word };
                }
            }
            return dict;
        }

        public List<List<string>> GetAllAnagramsInList(IEnumerable<string> baseWordList)
        {
            var anagramsByKey = AnagramsByKey(baseWordList);
            return anagramsByKey.Select(kvp => kvp.Value.ToList()).Where(l => l.Count > 1).ToList();
        }

        public List<List<string>> GetAllAnagramsInList2(IEnumerable<string> baseWordList)
        {
            var result = new List<List<string>> { new List<string>() };

            foreach (var word in baseWordList)
            {
                var individualResult = GetAnagramsInListForSpecificWord(baseWordList, word);
                bool addword = true;

                if (individualResult.Any())
                {
                    individualResult.Add(word);

                    foreach (var item in result)
                    {
                        if (item.Contains(word))
                        {
                            addword = false;
                        }
                    }

                    if (addword)
                    {
                        result.Add(individualResult);
                    }

                }

            }

            result.RemoveAll(x => !x.Any());

            return result;
        }

        private string WithoutIgnoredChars(string word)
        {
            return word.Replace("\'", string.Empty);
            //            return new String(word.ToCharArray().Where(v => v != '\'').ToArray());
        }

        private string SortLetters(string word)
        {
            var sortedWord = word.ToCharArray();
            Array.Sort(sortedWord);
            return new string(sortedWord);
        }
    }
}
