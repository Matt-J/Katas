using System.Collections.Generic;

namespace AnagramLogic
{
    /// <summary>
    /// http://codekata.com/kata/kata06-anagrams/
    /// </summary>
    public interface IAnagramFinder
    {
        List<string> GetAnagramsInListForSpecificWord(IEnumerable<string> baseWordList, string targetWord);
        List<List<string>> GetAllAnagramsInList(IEnumerable<string> baseWordList);
    }
}
