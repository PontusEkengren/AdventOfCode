using System;

namespace ChristMoose
{
    class SantaWorkShop
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ho Ho Ho!\n");

            var day3 = new Day3();
            Console.WriteLine($"Done {day3.CalculateManhattanDistance_Part2()}\n");
            Console.ReadKey();
        }
    }
}
