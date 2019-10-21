using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzzLogic.Tests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        private const string threes = "Fizz";

        private const string fives = "Buzz";

        private const string threesAndFives = "FizzBuzz";

        [Test]
        public void When_PassOne_ShouldReturnOne()
        {
            var result = FizzBuzzer.GetValueByNumber(1);
            result.Should().Be("1");
        }


        [TestCase(3, ExpectedResult = threes)]
        [TestCase(6, ExpectedResult = threes)]
        [TestCase(9, ExpectedResult = threes)]
        [TestCase(12, ExpectedResult = threes)]
        public string PassNumberDivisibleByThree_returnFizz(int input)
        {
            return FizzBuzzer.GetValueByNumber(input);
            
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void PassFive_returnBuzz(int input)
        {
            var result = FizzBuzzer.GetValueByNumber(input);

            result.Should().Be(fives);
        }

        [TestCase(15, ExpectedResult = threesAndFives)]
        public string PassNumberDivisibleByThreeAndFives_returnFizzBuzz(int input)
        {
            return FizzBuzzer.GetValueByNumber(input);

        }


    }
}