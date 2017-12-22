using day_6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class day_6
    {
        static void Main(string[] args)
        {
            Uberclass uc = new Uberclass();

            string puzzleInput = @"14	0	15	12	11	11	3	5	1	6	8	4	9	1	8	4";
            //uc.FirstHalf(puzzleInput);
            uc.SecondHalf(puzzleInput);
        }
    }
}
