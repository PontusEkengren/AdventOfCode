using System;

namespace ChristMoose.SantasLittleHelpers
{
    public class SantasBoilerPlate
    {
        public static string[] ReadFileAsStringArray(string fileName)
        {
            var text = System.IO.File.ReadAllText($@"C:\GIT\AdventOfCode\2021\ChristMoose\InputFiles\{fileName}");
            var lines = text.Split(new[] { ',', '\r', '\n' },StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        public static string ReadFileAsString(string fileName)
        {
            var text = System.IO.File.ReadAllText($@"C:\GIT\AdventOfCode\2021\ChristMoose\InputFiles\{fileName}");
            return text;
        }
    }
}