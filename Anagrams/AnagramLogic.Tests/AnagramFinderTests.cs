using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AnagramLogic.Tests
{
    [TestFixture]
    public class AnagramFinderTests
    {
        private IAnagramFinder anagramFinder = new AnagramFinder();
        string[] list = new[] { "god", "dog" };
        
        [NUnit.Framework.Test]
        public void GetAnagramsInListForSpecificWordShouldFindNoAnagrams()
        {
            //var list = new[] {"god", "dog"};
            var word = "beans";
            var matches = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            matches.Count().Should().Be(0);

        }
        [NUnit.Framework.Test]
        public void GetAnagramsInListForSpecificWordShouldFindOneAnagrams()
        {
            var word = "dog";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            match.Count().Should().Be(1);
        }
        [NUnit.Framework.Test]
        public void GetAnagramsInListForDifferentSpecificWordShouldFindTwoAnagrams()
        {
            var wordList = list.ToList();

            wordList.Add("odg");
            var word = "god";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, word);
            match.Should().BeEquivalentTo(new[] { "dog", "odg" });
            
        }

        [NUnit.Framework.Test]
        public void GetAnagramsInListForDifferentSpecificWordShouldFindOneAnagrams()
        {
            var word = "god";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            match.Should().BeEquivalentTo(new[] { "dog" });
        }

        [NUnit.Framework.Test]
        public void GetAnagramsInListForDifferentSpecificWordShouldFindOneAnagramsblah()
        {
            var word = "god";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            match.Should().BeEquivalentTo(new[] { "dog" });
        }


    }
}
