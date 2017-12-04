using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class day_3
    {
        static void Main(string[] args)
        {
            int puzzleInput = 361527;

            FirstHalf(puzzleInput);
            SecondHalf(puzzleInput);
        }

        public enum direction
        {
            EAST, NORTH, WEST, SOUTH
        }

        private static void FirstHalf(int puzzleInput)
        {
            Console.WriteLine("Puzzle 3 50%");
            int iterations = 1;
            int[,] maze = new int[,] { { 1 } };
            Cell location = new Cell(0,0,1);

            //firstmove
            move(iterations, location, maze, direction.EAST);

            while (iterations < puzzleInput)
            {
                
                iterations++;
            }

            Console.WriteLine();
        }

        private static void SecondHalf(int puzzleInput)
        {
            Console.WriteLine("Puzzle 3 100%");
            
            Console.ReadKey();
        }
        
        private static Cell move(int iterations, Cell locaiton, int[,] maze, direction direction)
        {
            Cell newLocation = null;

            switch (direction)
            {
                case direction.EAST:
                    Console.WriteLine("East");
                    if (inBounds(locaiton.x + 1, maze) == false)
                    {
                        maze = rezise(maze, direction.EAST);
                        newLocation = new Cell(locaiton.x + 1,locaiton.y,locaiton.value+1);
                        newLocation.Neighbours.Add(locaiton);
                    }



                    break;
                case direction.NORTH:
                    Console.WriteLine("North");
                    break;
                case direction.WEST:
                    Console.WriteLine("West");
                    break;
                case direction.SOUTH:
                    Console.WriteLine("South");
                    break;
            }

            if (newLocation == null) { throw new InvalidOperationException("nämen va fan"); }

            return newLocation;
        }

        private static int[,] rezise(int[,] maze, direction east)
        {
            int[,] tempMaze = new int[maze.Length+1, maze.Length + 1];
            Array.Copy(maze, tempMaze,maze.Length);
            maze = tempMaze;
            return maze;
        }

        private static bool inBounds(int index, int[,] array)
        {
            return (index >= 0) && (index < array.Length);
        }
    }


    //Help Class
    internal class Cell
    {
        public int x;
        public int y;
        public List<Cell> Neighbours;
        public int value;

        public Cell(int x, int y, int value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.Neighbours = new List<Cell>();
        }
    }
}
