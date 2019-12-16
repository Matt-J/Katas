using System;
using System.IO;
using System.Linq;
using AdventOfXmas2019Logic;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfXmas2019LogicTests
{
    [TestFixture]
    public class AdventLogicTests
    {
        private AdventLogic logic = new AdventLogic();

        [Test]
        [TestCase(14,2)]
        [TestCase(12,2)]
        [TestCase(1969,654)]
        [TestCase(100756,33583)]
        public void ShouldCalculateFuel(int input, int expected)
        {
            var mass = input;
            var result = logic.GetFuelRequirements(mass);
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldSumAllFuel()
        {
            var masses = File.ReadAllLines(@"D:\NonProd\AdventOfXmas2019\AdventOfXmas2019LogicTests\FuelMasses.txt");
            int result = 0;
            foreach (var mass in masses)
            {
                result += logic.GetFuelRequirements(int.Parse(mass));
            }
            
            result.Should().Be(3497399);
        }


        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]

        public void ShouldSumInclusiveFuel(int input, int expected)
        {
            var mass = input;
            var result = logic.GetInclusiveFuel(mass);
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldSumAllFuelInclusive()
        {
            var masses = File.ReadAllLines(@"D:\NonProd\AdventOfXmas2019\AdventOfXmas2019LogicTests\FuelMasses.txt");
            int result = 0;
            foreach (var mass in masses)
            {
                result += logic.GetInclusiveFuel(int.Parse(mass));
            }

            result.Should().Be(5243207);
        }


        [TestCase("1,0,0,0,99", "2,0,0,0,99")]
        [TestCase("2,3,0,3,99", "2,3,0,6,99")]
        [TestCase("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [TestCase("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        [TestCase("1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,2,27,13,31,1,10,31,35,1,10,35,39,2,39,6,43,1,43,5,47,2,10,47,51,1,5,51,55,1,55,13,59,1,59,9,63,2,9,63,67,1,6,67,71,1,71,13,75,1,75,10,79,1,5,79,83,1,10,83,87,1,5,87,91,1,91,9,95,2,13,95,99,1,5,99,103,2,103,9,107,1,5,107,111,2,111,9,115,1,115,6,119,2,13,119,123,1,123,5,127,1,127,9,131,1,131,10,135,1,13,135,139,2,9,139,143,1,5,143,147,1,13,147,151,1,151,2,155,1,10,155,0,99,2,14,0,0", "4462686,12,2,2,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,48,1,19,9,51,1,23,6,53,2,27,13,265,1,10,31,269,1,10,35,273,2,39,6,546,1,43,5,547,2,10,47,2188,1,5,51,2189,1,55,13,2194,1,59,9,2197,2,9,63,6591,1,6,67,6593,1,71,13,6598,1,75,10,6602,1,5,79,6603,1,10,83,6607,1,5,87,6608,1,91,9,6611,2,13,95,33055,1,5,99,33056,2,103,9,99168,1,5,107,99169,2,111,9,297507,1,115,6,297509,2,13,119,1487545,1,123,5,1487546,1,127,9,1487549,1,131,10,1487553,1,13,135,1487558,2,9,139,4462674,1,5,143,4462675,1,13,147,4462680,1,151,2,4462682,1,10,155,0,99,2,14,0,0")]
        [TestCase("1,9,10,3,2,3,11,0,99,30,40,50", "3500,9,10,70,2,3,11,0,99,30,40,50")]
        public void ShouldWorkOutOptCodeResult(string input, string output)
        {
            var result = logic.GetOptCodeResult(input);

            result.Should().Be(output);
        }

        [Test]
        public void ShouldOutput_19690720()
        {
            var baseInput =
                "1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,2,27,13,31,1,10,31,35,1,10,35,39,2,39,6,43,1,43,5,47,2,10,47,51,1,5,51,55,1,55,13,59,1,59,9,63,2,9,63,67,1,6,67,71,1,71,13,75,1,75,10,79,1,5,79,83,1,10,83,87,1,5,87,91,1,91,9,95,2,13,95,99,1,5,99,103,2,103,9,107,1,5,107,111,2,111,9,115,1,115,6,119,2,13,119,123,1,123,5,127,1,127,9,131,1,131,10,135,1,13,135,139,2,9,139,143,1,5,143,147,1,13,147,151,1,151,2,155,1,10,155,0,99,2,14,0,0";

            var baseInputArray = baseInput.Split(',').Select(x => int.Parse(x)).ToArray();

            bool isDone = false;

            Tuple<int, int> theAnswer = new Tuple<int, int>(0, 0);

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    baseInputArray[1] = i;
                    baseInputArray[2] = j;

                    var result = logic.GetSingleOptCodeResult(baseInputArray, 0);
                    Console.WriteLine($"{i} and {j} give {result}");
                    if (result == 19690720)
                    {
                        theAnswer = new Tuple<int, int>(i, j);
                        isDone = true;
                        break;
                    }

                    baseInputArray = baseInput.Split(',').Select(x => int.Parse(x)).ToArray();
                }
                
                if (isDone)
                {
                    break;
                }
            }

            theAnswer?.Should().NotBeNull();
            theAnswer.Item1.Should().Be(59);
            theAnswer.Item2.Should().Be(36);

        }
    }
}
