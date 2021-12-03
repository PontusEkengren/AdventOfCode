using System;
using System.Linq;

namespace ChristMoose
{
    public class Day1
    {
        public static int Increases(int[] seaFloor)
        {
            var increases = 0;
            for (var i = 1; i < seaFloor.Length; i++)
            {
                if (seaFloor[i - 1] < seaFloor[i])
                {
                    increases++;
                }
            }

            return increases;
        }

        public static int IncreasesSum(int[] seaFloor)
        {
            var increases = 0;
            for (var i = 2; i < seaFloor.Length-1; i++)
            {
                int currentPosVal = seaFloor[i - 2] + seaFloor[i - 1] + seaFloor[i];
                int nextPosVal = seaFloor[i - 1] + seaFloor[i] + seaFloor[i+1];

                if (currentPosVal<nextPosVal)
                {
                    increases++;
                }
            }

            return increases;
        }
    }
}
