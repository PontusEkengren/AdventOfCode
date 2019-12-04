using System;

namespace ChristMoose
{
    class SantaWorkShop
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ho Ho Ho!\n");

            var day = new Day4();
            Console.WriteLine($"Done {day.CalculateCodes_Part2()}\n");
            Console.ReadKey();
        }
    }
}
