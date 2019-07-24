using System.Collections.Generic;

namespace AnagramLogic
{
    /// <summary>
    /// http://codekata.com/kata/kata06-anagrams/
    /// </summary>
    public interface IAnagramFinder
    {
        IEnumerable<string> GetAnagramsInListForSpecificWord(IEnumerable<string> baseWordList, string targetWord);
    }
}
