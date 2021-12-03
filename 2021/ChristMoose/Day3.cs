using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ChristMoose.SantasLittleHelpers;

namespace ChristMoose
{
    public class Day3
    {
        public static int Calculate(string fileName)
        {
            var input = SantasBoilerPlate.ReadFileAsString(fileName);
            var inputArray = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var lengthOfInputs = inputArray[0].Length;
            var no_of_zeros = new int[lengthOfInputs];
            var no_of_ones = new int[lengthOfInputs];
            foreach (var line in inputArray)
            {
                var intArray = line.Select(c => int.Parse(c.ToString())).ToArray();
                for (var bitPosition = 0; bitPosition < intArray.Count(); bitPosition++)
                {
                    var bitValue = intArray[bitPosition];

                    if (bitValue == 1)
                    {
                        no_of_ones[bitPosition] += 1;
                    }
                    else
                    {
                        no_of_zeros[bitPosition] += 1;
                    }
                }
            }

            var gamma = new int[lengthOfInputs];
            var epsilon  = new int[lengthOfInputs];
            for (var position = 0; position < lengthOfInputs; position++)
            {
                if (no_of_ones[position] > no_of_zeros[position])
                {
                    gamma[position] = 1;
                    epsilon[position] = 0;
                }
                else
                {
                    gamma[position] = 0;
                    epsilon[position] = 1;
                }
            }

            var gammaInt = GetIntFromBitArray(gamma);
            var epsilonInt = GetIntFromBitArray(epsilon);



            return gammaInt*epsilonInt;
        }

        private static int GetIntFromBitArray(int[] bitAsIntArray)
        {
            var bitArray = new BitArray(bitAsIntArray.Select(x => x == 1).ToArray());
            Reverse(bitArray);
            var value = 0;

            for (var i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i])
                    value += Convert.ToInt16(Math.Pow(2, i));
            }

            return value;
        }

        private static void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
    }
    
}