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
                    newCellToReturn.Neighbours.Add(previousCell);
                    break;
                case direction.UP:
                    newCellToReturn = new Cell(previousCell.x, previousCell. y- 1, previousCell.value + 1, nextDirection);
                    newCellToReturn.Neighbours.Add(previousCell);
                    break;
                case direction.DOWN:
                    newCellToReturn = new Cell(previousCell.x, previousCell.y + 1, previousCell.value + 1, nextDirection);
                    newCellToReturn.Neighbours.Add(previousCell);
                    break;
                case direction.LEFT:
                    newCellToReturn = new Cell(previousCell.x - 1, previousCell.y, previousCell.value + 1, nextDirection);
                    newCellToReturn.Neighbours.Add(previousCell);
                    break;
            }

            return newCellToReturn;
        }

        private direction CalculateNextDirection(Cell previousCell)
        {
            switch (previousCell.direction)
            {
                case direction.RIGHT:
                    if (Occupied(previousCell) == false && GetAllCells(new List<Cell>(), previousCell).Count>=1)
                    {
                        return direction.UP;
                    }
                    return direction.RIGHT;
                case direction.UP:
                    if (Occupied(previousCell) == false)
                    {
                        return direction.LEFT;
                    }
                    return direction.UP;
                case direction.LEFT:
                    if (Occupied(previousCell) == false)
                    {
                        return direction.DOWN;
                    }
                    return direction.LEFT;
                case direction.DOWN:
                    if (Occupied(previousCell) == false)
                    {
                        return direction.RIGHT;
                    }
                    return direction.DOWN;
            }

            throw new InvalidOperationException("How the hell?");
        }

        private bool Occupied(Cell cell)
        {
            List<Cell> allCells = new List<Cell>();
            allCells = GetAllCells(allCells, cell);

            foreach (Cell neighbour in cell.Neighbours)
            {
                switch (cell.direction)
                {
                    case direction.RIGHT:
                        if(allCells.Any(n => n.x == cell.x && n.y-1 == cell.y)) { return true; }
                        return false;
                    case direction.UP:
                        if (allCells.Any(n => n.x-1== cell.x && n.y == cell.y)) { return true; }
                        return false;
                    case direction.LEFT:
                        if (allCells.Any(n => n.x == cell.x && n.y+1 == cell.y)) { return true; }
                        return false;
                    case direction.DOWN:
                        if (allCells.Any(n => n.x+1 == cell.x && n.y + 1 == cell.y)) { return true; }
                        return false;
                }
            }

            return false;
        }

        //private List<Cell> GetAllCells(Cell cell)
        //{
        //    List<Cell> AllCells = new List<Cell>();
        //    Cell currentCell = cell;

        //    while(currentCell.Neighbours.Count>0)
        //    {
        //        AllCells.Add(currentCell);
        //        currentCell = NextCell(currentCell);
        //    }
        //    return AllCells;
        //}

        //private Cell NextCell(Cell currentCell)
        //{
        //    return currentCell.Neighbours.FirstOrDefault();
        //}

        private List<Cell> GetAllCells(List<Cell> allCells, Cell cell)
        {
            if(cell.Neighbours != null && cell.Neighbours.Count > 0)
            {
                allCells.Add(cell.Neighbours.FirstOrDefault());
                GetAllCells(allCells, cell.Neighbours.FirstOrDefault());
            }

            return allCells;
        }

        private bool Occupied(Cell previousCell, direction lEFT)
        {
            throw new NotImplementedException();
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

