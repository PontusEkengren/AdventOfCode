using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class day_6
    {
        static void Main(string[] args)
        {
            string puzzleInput = @"14	0	15	12	11	11	3	5	1	6	8	4	9	1	8	4";

            FirstHalf(puzzleInput);
            SecondHalf(puzzleInput);
        }


        private static void FirstHalf(string puzzleInput)
        {
            Console.WriteLine("Puzzle 6 50%");

            var valuesArray = puzzleInput.Split(' ', '\t').Select(Int32.Parse).ToList().ToArray();
            Dictionary<int, int> values = new Dictionary<int, int>();

            for (int i = 0; i < valuesArray.Length; i++)
            {
                values.Add(i, valuesArray[i]);
            }

            int maxvalue = values.Values.Max();
            int maxvalue_index = values.First(x => x.Value == maxvalue).Key;


            int numberOfRoundRobins = GoAllKalahaOnThatDictionary(new Dictionary<int, Dictionary<int, int>>(), values, maxvalue, maxvalue_index);

            Console.WriteLine("checksum: " /*+ checksum*/);
            Console.WriteLine();
        }

        private static int GoAllKalahaOnThatDictionary(Dictionary<int, Dictionary<int, int>> seenDictionarys, Dictionary<int, int> workingValues, int workingValue, int workingIndex)
        {
            int numberOfDicts = 0;

            //workingDictionary = workingDictionary.Any() ? workingDictionary : initialValues;
            seenDictionarys.Add(numberOfDicts++, workingValues);
            Dictionary<int, int> newValues = new Dictionary<int, int>();

            for (int i = 0; i < workingValue; i++)
            {
                workingValues[]++;
                workingIndex = (workingIndex % workingValues.Keys.Max())
                workingIndex++;
            }

            if (SeenThisDictBefore(seenDictionarys, newValues))
            {
                return numberOfDicts;
            }
            else
            {
                return GoAllKalahaOnThatDictionary(seenDictionarys, newValues);
            }

        } }

        private static bool SeenThisDictBefore(Dictionary<int, Dictionary<int, int>> seenDictionarys, Dictionary<int, int> newValues)
        {
            throw new NotImplementedException();
        }

        private static void SecondHalf(string puzzleInput)
        {
            Console.WriteLine("Puzzle 6 100%");



            Console.WriteLine("checksum: " /*+ checksum*/);
            Console.ReadKey();
        }
        
    }
}
