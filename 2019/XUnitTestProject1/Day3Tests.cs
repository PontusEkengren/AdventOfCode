using ChristMoose;
using FluentAssertions;
using Xunit;

namespace PresentQualityControll
{
    public class Day3Tests
    {
        [Fact]
        public void Test_file_1()
        {
            var day3 = new Day3();

            var distance = day3.CalculateManhattanDistance_Part1("day3_test1.txt");
            var steps = day3.CalculateManhattanDistance_Part2("day3_test1.txt");
            distance.Should().Be(159);
            steps.Should().Be(610);
        }

        [Fact]
        public void Test_file_2()
        {
            var day3 = new Day3();

            var distance = day3.CalculateManhattanDistance_Part1("day3_test2.txt");
            var steps = day3.CalculateManhattanDistance_Part2("day3_test2.txt");
            distance.Should().Be(135);
            steps.Should().Be(410);
        }

        [Fact]
        public void Test_file_3()
        {
            var day3 = new Day3();

            var distance = day3.CalculateManhattanDistance_Part1("day3_test3.txt");
            var steps = day3.CalculateManhattanDistance_Part2("day3_test3.txt");
            distance.Should().Be(6);
            steps.Should().Be(30);
        }
    }
}