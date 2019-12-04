using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChristMoose.SantasLittleHelpers;

namespace ChristMoose
{
    public class Day3
    {
        private string _textFile = "day3.txt";

        public int CalculateManhattanDistance_Part1(string textFile = null)
        {
            var board = WireCircuitBoard(textFile);
            return board.SelectMany(x => x.Value).Where(x => x.Id == -1).Min(x => x.ManhattanLength);
        }
        public int CalculateManhattanDistance_Part2(string textFile = null)
        {
            var board = WireCircuitBoard(textFile);
            return board
                .Where(x => x.Value.Any(wire => wire.Id == -1))
                .Select(x => x.Value.Where(wire => wire.Id != -1))
                .Select(wireGroup => wireGroup.Sum(x => x.Steps)).Concat(new[] { int.MaxValue }).Min();
        }

        private Dictionary<string, List<Wire>> WireCircuitBoard(string textFile)
        {
            var input = SantasBoilerPlate.ReadFileAsString(textFile ?? _textFile);
            var wires = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var board = new Dictionary<string, List<Wire>>();

            for (var wireId = 0; wireId < wires.Length; wireId++)
            {
                var wireMap = wires[wireId].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var currentLocation = new Point(0, 0);
                var wire = new Wire { Id = wireId + 1, ManhattanLength = Int32.MaxValue };
                foreach (var direction in wireMap)
                {
                    currentLocation = Populate(board, direction, new Point(currentLocation.X, currentLocation.Y), wire);
                }
            }

            return board;
        }

        private Point Populate(Dictionary<string, List<Wire>> board, string direction, Point location, Wire wire)
        {
            var length = int.Parse(direction.Substring(1));
            var newX = location.X;
            var newY = location.Y;

            for (var i = 1; i < length + 1; i++)
            {
                switch (direction[0])
                {
                    case 'R':
                        newX = location.X + i;
                        break;
                    case 'L':
                        newX = location.X - i;
                        break;
                    case 'U':
                        newY = location.Y + i;
                        break;
                    case 'D':
                        newY = location.Y - i;
                        break;
                    default:
                        throw new Exception("Oh Ho No...");
                }

                wire.Steps++;
                var key = $"{newX},{newY}";
                var wires = board.ContainsKey(key) ? board[key] : new List<Wire>();
                if (board.ContainsKey(key) && wires.Any(x => x.Id != 0 && x.Id != wire.Id))
                {
                    wires.Add(new Wire { Id = wire.Id, ManhattanLength = wire.ManhattanLength = wire.ManhattanLength, Steps = wire.Steps });
                    wires.Add(new Wire { Id = -1, ManhattanLength = wire.ManhattanLength = Math.Abs(newX) + Math.Abs(newY), Steps = wire.Steps });
                    board[key] = wires;
                    continue;
                }

                wires.Add(new Wire { Id = wire.Id, ManhattanLength = wire.ManhattanLength = wire.ManhattanLength, Steps = wire.Steps });
                board[key] = wires;
            }

            return new Point(newX, newY);
        }
    }

    public class Wire
    {
        public int Id { get; set; }
        public int Steps { get; set; }
        public int ManhattanLength { get; set; }
    }
}