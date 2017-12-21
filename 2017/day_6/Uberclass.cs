using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_6
{
    public class Uberclass
    {

        public void FirstHalf(string puzzleInput)
        {
            Console.WriteLine("Puzzle 6 50%");

            var valuesArray = puzzleInput.Split(' ', '\t').Select(Int32.Parse).ToList().ToArray();
            Dictionary<int, int> values = new Dictionary<int, int>();

            for (int i = 0; i < valuesArray.Length; i++)
            {
                values.Add(i, valuesArray[i]);
            }

            int numberOfRoundRobins = GoAllKalahaOnThatDictionary(new Dictionary<int, Dictionary<int, int>>(), values, values.Values.Max(), values.First(x => x.Value == values.Values.Max()).Key);

            Console.WriteLine("checksum: " /*+ checksum*/);
            Console.WriteLine();
        }

        private int GoAllKalahaOnThatDictionary(Dictionary<int, Dictionary<int, int>> seenDictionarys, Dictionary<int, int> workingValues, int workingValue, int workingIndex)
        {
            int NumberOfDictKey = seenDictionarys.Keys.Count > 0 ? seenDictionarys.Keys.Count + 1 : 0;
            seenDictionarys.Add(NumberOfDictKey, workingValues);
            workingValues[workingIndex] = 0;

            while (workingValue > 0)
            {
                workingIndex++;
                workingValues[((workingIndex) % workingValues.Keys.Count)]++;
                workingValue--;
            }

            Dictionary<int, int> newValues = new Dictionary<int, int>(workingValues);
            int maxvalue = newValues.Values.Max();
            int maxvalue_index = newValues.First(x => x.Value == maxvalue).Key;

            if (seenDictionarys.Any(x => x.Value == newValues))
            {
                return seenDictionarys.Keys.Count;
            }
            else
            {
                return GoAllKalahaOnThatDictionary(seenDictionarys, newValues, maxvalue, maxvalue_index);
            }
        }

        public void SecondHalf(string puzzleInput)
        {
            Console.WriteLine("Puzzle 6 100%");



            Console.WriteLine("checksum: " /*+ checksum*/);
            Console.ReadKey();
        }

    }
}
