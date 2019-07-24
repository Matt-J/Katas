using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AnagramLogic.Tests
{
    [TestFixture]
    public class FileHelperTests
    {
        [Test]
        public void GetAllFilesShouldReturnShortList()
        {
            var wordList = FileHelper.GetAllWordsFromFile("ShortWordList");

            wordList.ToList().Count.Should().Be(380);
        }

        //Commented as its a fat file to load into memory constantly
        //[Test]
        //public void GetAllFilesShouldReturnBigList()
        //{
        //    var wordList = FileHelper.GetAllWordsFromFile("WordList");

        //    wordList.ToList().Count.Should().Be(338882);
        //}
    }
}
