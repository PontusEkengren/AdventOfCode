using System;
using System.Collections.Generic;
using System.Linq;
using ChristMoose.WorkShop;
using Microsoft.VisualBasic.CompilerServices;

namespace ChristMoose
{
    public class Day2
    {
        private static string _forward => "forward";
        private static string _depth => "depth";

        public static int Position(IEnumerable<Navigation> map)
        {
            var result = new Dictionary<string, int>
            {
                { _depth, 0 },
                { _forward, 0 },
            };

            foreach (var nav in map)
            {
                if (nav.Direction == _forward)
                {
                    result[_forward] += nav.Value;
                    var keyValuePair = result.Single(r => r.Key == _forward);
                }
                else
                {
                    result[_depth] += nav.Direction == "down" ? nav.Value : nav.Value * -1;
                }
            }

            return result[_depth] * result[_forward];
        }

        public static int PositionAim(List<Navigation> map)
        {
            var result = new Dictionary<string, int>
            {
                { _depth, 0 },
                { _forward, 0 },
            };
            var currentAim = 0;
            foreach (var nav in map)
            {
                if (nav.Direction == _forward)
                {
                    result[_forward] += nav.Value;
                    if (currentAim != 0)
                        result[_depth] += nav.Value * currentAim;
                }
                else
                {
                    var navValue = nav.Direction == "down" ? nav.Value : nav.Value * -1;
                    currentAim += navValue;
                }
            }

            return result[_depth] * result[_forward];
        }
    }
}