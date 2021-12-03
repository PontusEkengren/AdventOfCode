using ChristMoose;
using FluentAssertions;
using Xunit;

namespace PresentQualityControll
{
    public class Day3Tests
    {
        [Fact]
        public void Testing_part_1()
        {

            Day3.Calculate("day3_test1.txt").Should().Be(198);
        }

        [Fact]
        public void Running_part_1()
        {
            Day3.Calculate("day3.txt").Should().Be(2595824);
        }

        [Fact]
        public void Testing_part_2()
        {

            Day3.Calculate("day3_test1.txt").Should().Be(230);
        }

        //[Fact]
        //public void Running_part_2()
        //{
        //    Day3.Calculate("day3.txt").Should().Be(2595824);
        //}
    }
}