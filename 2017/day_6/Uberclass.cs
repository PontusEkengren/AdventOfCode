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

                if (seenDictionarys.Any(x => x.Key == String.Join("-", newValues.Values)))
                    break;

                seenDictionarys.Add(String.Join("-", workingValues.Values), workingValues);
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
        private int GoAllKalahaOnThatDictionary(Dictionary<string, int> seenDictionarys, Dictionary<int, int> workingValues, int workingValue, int workingIndex, string stopstring)
        {
            while (true)
            {
                Dictionary<int, int> newValues = new Dictionary<int, int>(workingValues);

                if (seenDictionarys.Any(x => x.Key == String.Join("-", newValues.Values)))
                {
                    if(seenDictionarys.Any(x => x.Key == stopstring)){
                        break;
                    }
                    seenDictionarys.Remove(String.Join("-", newValues.Values));
                }

                seenDictionarys.Add(String.Join("-", newValues.Values), seenDictionarys.Count()+1);
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

        public void SecondHalf(string puzzleInput)
        {
            Console.WriteLine("Puzzle 6 100%");

            var valuesArray = puzzleInput.Split(' ', '\t').Select(Int32.Parse).ToList().ToArray();
            Dictionary<int, int> values = new Dictionary<int, int>();

            for (int i = 0; i < valuesArray.Length; i++)
            {
                values.Add(i, valuesArray[i]);
            }

            int numberOfRoundRobins = GoAllKalahaOnThatDictionary(new Dictionary<string, int>(), values, values.Values.Max(), values.First(x => x.Value == values.Values.Max()).Key, "14-0-15-12-11-11-3-5-1-6-8-4-9-1-8-4");


            Console.WriteLine("Result: "+ numberOfRoundRobins /*+ checksum*/);
            Console.ReadKey();
        }

    }
}
