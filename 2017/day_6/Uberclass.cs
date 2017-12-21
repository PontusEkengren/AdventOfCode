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

            int numberOfRoundRobins = GoAllKalahaOnThatDictionary(new Dictionary<string, Dictionary<int, int>>(), values, values.Values.Max(), values.First(x => x.Value == values.Values.Max()).Key);

            Console.WriteLine("checksum: " + numberOfRoundRobins/*+ checksum*/);
            Console.WriteLine();
        }

        private int GoAllKalahaOnThatDictionary(Dictionary<string, Dictionary<int, int>> seenDictionarys, Dictionary<int, int> workingValues, int workingValue, int workingIndex)
        {
            while (true)
            {
                Dictionary<int, int> newValues = new Dictionary<int, int>(workingValues);
                var stuff = newValues.Values.GetHashCode();

                if (seenDictionarys.Any(x => x.Key == GetStringFromDictionaryValues(newValues.Values)))
                    break;

                seenDictionarys.Add(GetStringFromDictionaryValues(workingValues.Values), workingValues);
                workingValues[workingIndex] = 0;

                while (workingValue > 0)
                {
                    workingIndex++;
                    workingValues[((workingIndex) % workingValues.Keys.Count)]++;
                    workingValue--;
                }

                workingValues = new Dictionary<int, int>(workingValues);
                workingValue = workingValues.Values.Max();
                workingIndex = workingValues.First(x => x.Value == workingValue).Key;
            }

            return seenDictionarys.Keys.Count;
        }

        private string GetStringFromDictionaryValues(Dictionary<int, int>.ValueCollection values)
        {
            string result = "";

            foreach(int v in values)
            {
                result += v;
            }

            return result;
        }

        public void SecondHalf(string puzzleInput)
        {
            Console.WriteLine("Puzzle 6 100%");



            Console.WriteLine("checksum: " /*+ checksum*/);
            Console.ReadKey();
        }

    }
}
