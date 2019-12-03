using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace ChristMoose
{
    public class Day2
    {
        private static readonly int[] Integers =
        {
            1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,5,19,23,1,23,5,27,2,27,10,31,1,5,31,35,2,35,6,39,1,6,39,43,2,13,43,47,2,9,47,51,1,6,51,55,1,55,9,59,2,6,59,63,1,5,63,67,2,67,13,71,1,9,71,75,1,75,9,79,2,79,10,83,1,6,83,87,1,5,87,91,1,6,91,95,1,95,13,99,1,10,99,103,2,6,103,107,1,107,5,111,1,111,13,115,1,115,13,119,1,13,119,123,2,123,13,127,1,127,6,131,1,131,9,135,1,5,135,139,2,139,6,143,2,6,143,147,1,5,147,151,1,151,2,155,1,9,155,0,99,2,14,0,0
        };

        public static int[] Calculate1202_Part1()
        {
            return Calculate1202_Part1(Integers);
        }

        public static int[] Calculate1202_Part1(int[] integers)
        {
            for (int i = 0; i + 3 < integers.Length; i = i + 4)
            {
                var firstLocation = integers[i + 1];
                var secondLocation = integers[i + 2];
                var outPutPosition = integers[i + 3];

                switch (integers[i])
                {
                    case 1:
                        integers[outPutPosition] = integers[firstLocation] + integers[secondLocation];
                        break;
                    case 2:
                        integers[outPutPosition] = integers[firstLocation] * integers[secondLocation];
                        break;
                    case 99:
                        return integers;
                }
            }

            return integers;
        }

        public static int Calculate1202_Part2()
        {
            return Calculate1202_Part2(Integers);
        }

        public static int Calculate1202_Part2(int[] integers)
        {
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    var integersClone = Integers.ToArray();
                    integersClone[1] = noun;
                    integersClone[2] = verb;

                    var result = Calculate1202_Part1(integersClone)[0];

                    if (result == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return -1;
        }
    }
}