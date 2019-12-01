using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristMoose
{
    internal class Day6
    {
        //private static string Input => "158,163\r\n287,68\r\n76,102\r\n84,244\r\n162,55\r\n272,335\r\n345,358\r\n210,211\r\n343,206\r\n219,323\r\n260,238\r\n83,94\r\n137,340\r\n244,172\r\n335,307\r\n52,135\r\n312,109\r\n276,93\r\n288,274\r\n173,211\r\n125,236\r\n200,217\r\n339,56\r\n286,134\r\n310,192\r\n169,192\r\n313,106\r\n331,186\r\n40,236\r\n194,122\r\n244,76\r\n159,282\r\n161,176\r\n262,279\r\n184,93\r\n337,284\r\n346,342\r\n283,90\r\n279,162\r\n112,244\r\n49,254\r\n63,176\r\n268,145\r\n334,336\r\n278,176\r\n353,135\r\n282,312\r\n96,85\r\n90,105\r\n354,312";
        private static string TestInput => "1,1\r\n1,6\r\n8,3\r\n3,4\r\n5,5\r\n8,9";
        private static string Alphabet => "abcdefghijklmnopqrstuvwxyzåäö0123456789!#%&/()=-_^";

        public static string MinimizeDanger()
        {
            var stringInputValues = TestInput.Split("\r\n");
            var values = new Dictionary<string, Coordinate>();
            for (var i = 0; i < stringInputValues.Length; i++)
            {
                var stringInputValue = stringInputValues[i];
                var strings = stringInputValue.Split(",");

                var coordinate = new Coordinate { X = int.Parse(strings[0]), Y = int.Parse(strings[1]) };
                values.Add(Alphabet[i].ToString().ToUpper(), coordinate);
            }

            var maxX = values.Select(x => x.Value.X).Max();
            var maxY = values.Select(x => x.Value.Y).Max();

            var map = new string[maxX, maxY];

            for (var index0 = 0; index0 < map.GetLength(0); index0++)
            {
                for (var index1 = 0; index1 < map.GetLength(1); index1++)
                {
                    var print = ".";
                    var coordinate = values.SingleOrDefault(c => c.Value.X == index1 && c.Value.Y == index0);
                    if (!string.IsNullOrEmpty(coordinate.Key))
                    {
                        print = coordinate.Key;
                    }

                    Console.Write(print);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit..");

            Console.ReadKey();
            return "1337";
        }

        class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}