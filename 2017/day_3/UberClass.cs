using System;
using System.Collections.Generic;
using System.Linq;

namespace day_3
{
    public class UberClass
    {
        int[,] maze = new int[100,100];
        int input = 1337;
        public UberClass()
        {
            Calculate(input);
        }

        private void Calculate(int input)
        {
            int iterations = 0;
            int startingpoint_x = 1500;
            int startingpoint_y = 1500;
            var startingCell = new Cell(startingpoint_x, startingpoint_y, ++iterations, direction.RIGHT);
            var previousCell = startingCell;
            Stack<Cell> Cells = new Stack<Cell>();

            while(iterations < input)
            {
                iterations++;
                Cells.Push(previousCell);
                previousCell = nextmove(previousCell);
            }
        }

        private Cell nextmove(Cell previousCell)
        {
            direction nextDirection = CalculateNextDirection(previousCell);
            Cell newCellToReturn = null;
            switch (nextDirection)
            {
                case direction.RIGHT:
                    newCellToReturn = new Cell(previousCell.x+1,previousCell.y,previousCell.value+1,nextDirection);
                    break;
                case direction.UP:
                    newCellToReturn = new Cell(previousCell.x, previousCell. y- 1, previousCell.value + 1, nextDirection);
                    break;
                case direction.DOWN:
                    newCellToReturn = new Cell(previousCell.x, previousCell.y + 1, previousCell.value + 1, nextDirection);
                    break;
                case direction.LEFT:
                    newCellToReturn = new Cell(previousCell.x - 1, previousCell.y, previousCell.value + 1, nextDirection);
                    break;
            }

            return newCellToReturn;
        }

        private direction CalculateNextDirection(Cell previousCell)
        {
            int mathResult = -1337;
            switch (previousCell.direction)
            {
                case direction.RIGHT:
                    if (previousCell.value == Math.Pow((2 * previousCell.value - 1),2))
                    {
                        return direction.UP;
                    }
                    return direction.RIGHT;
                case direction.UP:
                    if (previousCell.value == ((4 * Math.Pow(previousCell.value,2)-10*previousCell.value) + 7 ))
                    {
                        return direction.LEFT;
                    }
                    return direction.UP;
                case direction.LEFT:
                    mathResult = (int)(((Math.Pow(previousCell.value, 2))*4 + 1));
                    if (previousCell.value == mathResult)
                    {
                        return direction.DOWN;
                    }
                    return direction.LEFT;
                case direction.DOWN:
                    if (previousCell.value == (((4 * Math.Pow(previousCell.value,2))-(6*previousCell.value+3))))
                    {
                        return direction.RIGHT;
                    }
                    return direction.DOWN;
            }

            throw new InvalidOperationException("How the hell?");
        }
    }
    enum direction
    {
        RIGHT, LEFT, UP, DOWN
    }

    //Help Class
    internal class Cell
    {
        public int x;
        public int y;
        public List<Cell> Neighbours;
        public int value;
        public direction direction;

        public Cell(int x, int y, int value, direction direction)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.Neighbours = new List<Cell>();
            this.direction = direction;
        }


    }
}

