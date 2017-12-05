using System;
using System.Collections.Generic;
using System.Linq;

namespace day_3
{
    public class UberClass
    {
        int[,] maze;
        List<Cell> locations = new List<Cell>();

        public UberClass()
        {
            maze = new int[,] { { 1 } };
            int puzzleInput = 361527;

            FirstHalf(puzzleInput);
            SecondHalf(puzzleInput);
        }

        private void FirstHalf(int puzzleInput)
        {
            Console.WriteLine("Puzzle 3 50%");
            int iterations = 1;
            Cell location = new Cell(0, 0, 1);
            location.maze = maze;
            locations.Add(location);

            //firstmove
            var newLocation = move(iterations, location, maze, direction.EAST);
            locations.Add(newLocation);
            maze = newLocation.maze;//:(
            location = newLocation;


            while (iterations < puzzleInput)
            {
                PrintMaze(location);
                direction validDirection = findValidDirection(location, maze);
                newLocation = move(iterations, location, maze, validDirection);

                iterations++;
            }

            Console.WriteLine();
        }

        private void PrintMaze(Cell location)
        {
            var maze = location.maze;
            Console.WriteLine();
            Console.WriteLine("Printing maze");

            var rowCount = maze.GetLength(0);
            var colCount = maze.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    Console.Write(String.Format("{0}\t", maze[row, col]));
                Console.WriteLine();
            }

        }

        private direction findValidDirection(Cell location, int[,] maze)
        {
            if (location.Neighbours.Count > 0)
            {
                    if(location.Neighbours.Any(neighbour => (neighbour.x == location.x - 1 && neighbour.y == location.y)))
                {
                    //go up or right
                    if(location.Neighbours.Any(neighbour => (neighbour.x == location.x&& neighbour.y == location.y-1)))
                    {
                        //go right
                        return direction.EAST;
                    }
                    else
                    {
                        //go up
                        return direction.NORTH;
                    }

                }
                else
                {
                    //go down or left
                    if(location.Neighbours.Any(neighbour => (neighbour.x == location.x+1 && neighbour.y == location.y)))
                    {
                        //go down
                        return direction.SOUTH;
                    }
                    else
                    {
                        //go left
                        return direction.WEST;
                    }
                }

            }

            return 0;
        }


        private Cell move(int iterations, Cell locaiton, int[,] maze, direction direction)
        {
            Cell newLocation = locaiton;

            switch (direction)
            {
                case direction.EAST:
                    Console.WriteLine("East");
                    if (inBounds(locaiton.x + 1, maze) == false)
                    {
                        maze = rezise(maze, direction.EAST);
                        newLocation = new Cell(locaiton.x + 1, locaiton.y, locaiton.value + 1);
                        newLocation.Neighbours.Add(locaiton);
                        newLocation.maze = maze;
                    }
                    newLocation.maze[locaiton.y, locaiton.x + 1] = locaiton.value + 1;
                    break;
                case direction.NORTH:
                    Console.WriteLine("North");
                    if (inBounds(locaiton.y - 1, maze) == false)
                    {
                        maze = rezise(maze, direction.NORTH);
                        newLocation = new Cell(locaiton.x, locaiton.y-1, locaiton.value + 1);
                        newLocation.Neighbours.Add(locaiton);
                        newLocation.maze = maze;
                    }
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

        private int[,] rezise(int[,] maze, direction direction)
        {
            int[,] tempMaze;
            switch (direction)
            {
                case direction.EAST:
                    tempMaze = new int[maze.Length + 1, maze.Length + 1];
                    Array.Copy(maze, tempMaze, maze.Length);
                    maze = tempMaze;
                    return maze;
                case direction.SOUTH:
                    tempMaze = new int[maze.Length + 1, maze.Length + 1];
                    Array.Copy(maze, tempMaze, maze.Length);
                    maze = tempMaze;
                    return maze;
                case direction.NORTH:
                    tempMaze = new int[maze.Length + 1, maze.Length + 1];
                    Array.Copy(maze, tempMaze, maze.Length);
                    maze = tempMaze;
                    return maze;
                case direction.WEST:
                    tempMaze = new int[maze.Length + 1, maze.Length + 1];
                    Array.Copy(maze, tempMaze, maze.Length);
                    maze = tempMaze;
                    return maze;
            }

            return maze;
        }

        private bool inBounds(int index, int[,] array)
        {
            return (index >= 0) && (index < array.Length);
        }
        private void SecondHalf(int puzzleInput)
        {
            Console.WriteLine("Puzzle 3 100%");

            Console.ReadKey();
        }
        public enum direction
        {
            EAST, NORTH, WEST, SOUTH
        }
    }

    //Help Class
    internal class Cell
    {
        public int x;
        public int y;
        public List<Cell> Neighbours;
        public int value;
        public int[,] maze;//Dont do this.. ever

        public Cell(int x, int y, int value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.Neighbours = new List<Cell>();
        }
    }
}

