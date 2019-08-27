using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramLogic.Tests
{
    [TestFixture]
    public class AnagramFinderTests
    {
        private IAnagramFinder anagramFinder;
        string[] list = { "god", "dog" };

        [SetUp]
        public void SetupTests()
        {
            anagramFinder = new AnagramFinder();
        }

        [TearDown]
        public void TearDownTest()
        {
            
        }

        [Test]
        public void GetAnagramsInListForSpecificWordShouldFindNoAnagrams()
        {
            var word = "beans";
            var matches = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            matches.Count().Should().Be(0);
        }

        [Test]
        public void GetAnagramsInListForSpecificWordShouldFindOneAnagrams()
        {
            var word = "dog";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            match.Count().Should().Be(1);
        }

        [Test]
        public void GetAnagramsInListForDifferentSpecificWordShouldFindTwoAnagrams()
        {
            var wordList = list.ToList();

            wordList.Add("odg");
            var word = "god";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, word);
            match.Should().BeEquivalentTo("dog", "odg");
        }

        [Test]
        public void GetAnagramsInListForDifferentSpecificWordShouldFindOneAnagrams()
        {
            var word = "god";
            var match = anagramFinder.GetAnagramsInListForSpecificWord(list, word);
            match.Should().BeEquivalentTo("dog");
        }

        [Test]
        public void GetAnagramsInListIsApostropheInsensitive()
        {
            var word = "dogs";
            string[] wordList = new[] {"god's", "gods", "dog"};
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, word);
            match.Should().BeEquivalentTo("gods", "god's");
        }

        [Test]
        public void GetAnagramsInListIsApostropheInsensitiveForTargetWithApostrophe()
        {
            var word = "dogs''";
            string[] wordList = new[] { "god's", "gods", "dog" };
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, word);
            match.Should().BeEquivalentTo("gods", "god's");
        }

        [Test]
        public void GetAnagramsInListWorksForWordsWithRepeatedLetters()
        {
            var word = "cool";
            string[] wordList = new[] { "col", "cool", "coool", "looc" };
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, word);
            match.Should().BeEquivalentTo("looc");
        }


        [Test]
        public void GetAnagramsInListCaseInsensitiveLetters()
        {
            var word = "COOL";
            string[] wordList = new[] { "col", "cool", "coool", "looc" };
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, word);
            match.Should().BeEquivalentTo("looc");
        }

        [Test]
        public void GetAllFilesShouldReturnBigList()
        {
            var wordList = FileHelper.GetAllWordsFromFile("WordList").ToList();

            var targetWord = "kinship";
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var match = anagramFinder.GetAnagramsInListForSpecificWord(wordList, targetWord);
            stopwatch.Stop();

            var elapsedTimeMessage = $"Elapsed Time: {stopwatch.ElapsedMilliseconds}ms";
            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= 1500, elapsedTimeMessage);
            Console.Write(elapsedTimeMessage);
            
        }


        [Test]
        public void GetAllAnagramsInSmallList()
        {
            var wordList = new List<string> {"god", "dog", "cool", "loco", "fish", "beef"};
            
            var match = anagramFinder.GetAllAnagramsInList(wordList);

            // Get lists in same order.
            foreach (var list in match)
                list.Sort();
            match.Sort((a, b) => a[0].CompareTo(b[0]));

            var expectedResult = new List<List<string>>
            {
                new List<string>
                {
                    "cool",
                    "loco"
                },
                new List<string>
                {
                    "dog",
                    "god",
                },
            };

            match.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void CanGetTotalAnagramsInFile()
        {
            var wordList = FileHelper.GetAllWordsFromFile("WordList").ToList();
            var match = anagramFinder.GetAllAnagramsInList(wordList);
            match.Count.Should().Be(20683);
        }
    }
}
