using System;
using System.Linq;

namespace AdventOfXmas2019Logic
{
    public class AdventLogic
    {
        public int GetFuelRequirements(int masses)
        {
            return (masses / 3) - 2;
        }

        public int GetInclusiveFuel(int masses)
        {
            int additionalFuel = GetFuelRequirements(masses);
            int total = 0;
            while (additionalFuel > 0 )
            {
                total += additionalFuel;

                additionalFuel = GetFuelRequirements(additionalFuel);

                
            }

            
            return total;
        }

        public string GetOptCodeResult(string input)
        {
            var codes = input.Split(',').Select(x => int.Parse(x)).ToArray();

            return GetOptCodeResults(codes);
        }

        public int GetSingleOptCodeResult(int[] input, int positionToReturn)
        {
            var strings = GetOptCodeResults(input).Split(',');
            var s = strings[positionToReturn];
            return int.Parse(s);
        }


        private static string GetOptCodeResults(int[] codes)
        {
            for (int i = 0; i < codes.Length; i += 4)
            {
                try
                {
                    switch (codes[i])
                    {
                        case 99:
                            return string.Join(',', codes);
                        case 1:
                            var res = codes[codes[i + 1]] + codes[codes[i + 2]];
                            codes[codes[i + 3]] = res;
                            break;

                        case 2:
                            res = codes[codes[i + 1]] * codes[codes[i + 2]];
                            codes[codes[i + 3]] = res;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Popped on {i} and ");
                }
                
            }

            return string.Empty;
        }
    }
}
