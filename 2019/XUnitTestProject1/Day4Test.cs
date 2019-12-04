using ChristMoose;
using FluentAssertions;
using Xunit;

namespace PresentQualityControll
{
    public class Day4Tests
    {
        [Fact]
        public void Test_1()
        {
            var day = new Day4();

            day.CalculateCodes_Part1(122345, 122345).Should().Be(1);
        }
        [Fact]
        public void Test_2()
        {
            var day = new Day4();

            day.CalculateCodes_Part1(122325, 122325).Should().Be(0);
        }
        [Fact]
        public void Test_3()
        {
            var day = new Day4();

            day.CalculateCodes_Part2(122234, 122234).Should().Be(0);
        }
        [Fact]
        public void Test_4()
        {
            var day = new Day4();

            day.CalculateCodes_Part2(13444, 13444).Should().Be(0);
        }
    }
}