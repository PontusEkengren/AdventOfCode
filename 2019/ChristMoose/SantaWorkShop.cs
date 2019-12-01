using System;

namespace ChristMoose
{
    class SantaWorkShop
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ho Ho Ho!\n");

            var day = new Day1();
            //day.CalculateFuel_Part1();
            day.CalculateFuel_Part2();

            Console.ReadKey();
        }
    }
}
