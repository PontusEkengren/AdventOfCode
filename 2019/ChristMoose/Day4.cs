using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChristMoose
{
    public class Day4
    {
        private int _inputFloor = 271973;
        private int _inputRoof = 785961;

        //169974
        //304711
        //134737

        public int CalculateCodes_Part1()
        {
            return CalculateCodes_Part1(_inputFloor, _inputRoof);
        }
        public int CalculateCodes_Part2()
        {
            return CalculateCodes_Part2(_inputFloor, _inputRoof);
        }
        public int CalculateCodes_Part2(int inputFloor, int inputRoof)
        {
            var combinations = GetNumberOfCombinations(inputFloor, inputRoof, false);

            return combinations;
        }

        private static int GetNumberOfCombinations(int inputFloor, int inputRoof, bool allowTriplets = true)
        {
            var combinations = 0;
            for (int i = inputFloor; i <= inputRoof; i++)
            {
                var codeAsString = $"{i}";
                if (codeAsString.Contains('0'))
                {
                    continue;
                }

                if (ValidCode(codeAsString, allowTriplets))
                {
                    combinations++;
                }
            }

            return combinations;
        }

        public int CalculateCodes_Part1(int inputFloor, int inputRoof)
        {
            var combinations = GetNumberOfCombinations(inputFloor, inputRoof);
            return combinations;
        }

        private static bool ValidCode(string codeAsString, bool allowTriplets)
        {
            var valid = false;

            for (var i = 0; i < codeAsString.Length - 1; i++)
            {
                if (codeAsString[i] < codeAsString[i + 1]) continue;
                if (codeAsString[i] == codeAsString[i + 1] &&((codeAsString.Count(x => x == codeAsString[i]) < 3 || allowTriplets)))
                {
                    valid = true;
                }

                if (codeAsString[i] > codeAsString[i + 1])
                {
                    return false;
                }
            }

            return valid;
        }
    }
}