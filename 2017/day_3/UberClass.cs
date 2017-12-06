using System;
using System.Collections.Generic;
using System.Linq;

namespace day_3
{
    public class UberClass
    {
        static int mapsize = 30;
        int[,] maze = new int[mapsize, mapsize];
        List<Cell> AllCellsTest;
        int ringNumber = 1;
        direction previousDirection = direction.RIGHT;
        int input = 361527;//real

        public UberClass()
        {
            //input = 304;
            AllCellsTest = new List<Cell>();
            Calculate(input);
        }

        private void Calculate(int input)
        {
            int iterations = 0;
            int startingpoint_x = 15;
            int startingpoint_y = 15;
            var startingCell = new Cell(startingpoint_x, startingpoint_y, 1, direction.RIGHT, 1);
            var previousCell = startingCell;
            AllCellsTest.Add(previousCell);
            //Stack<Cell> Cells = new Stack<Cell>();

            while (previousCell.value<= input)
            {
                iterations++;
                previousCell = nextmove(previousCell);
            }

            ////previousCell = nextmove(previousCell);
            Console.WriteLine("Solution: " + previousCell.value);//too high: 535694
            
            //Print all
            List<Cell> gac = new List<Cell>();
            gac = GetAllCells(gac, previousCell);

            int[,] map = new int[mapsize, mapsize];

            foreach (Cell cell in gac)
            {
                Console.WriteLine("Solution: " + cell.value);//535694
                //break;
                map[cell.y, cell.x] = cell.value;//4,468|698,234->932
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] != 0)
                    {
                        Console.Write("\t" + map[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private Cell nextmove(Cell previousCell)
        {
            direction nextDirection = CalculateNextDirection(previousCell);
            Cell newCellToReturn = null;
            switch (nextDirection)
            {
                case direction.RIGHT:
                    newCellToReturn = new Cell(previousCell.x + 1, previousCell.y, ValueAdder(AllCellsTest, previousCell.x + 1, previousCell.y), nextDirection, ringNumber);
                    newCellToReturn.Neighbours.Add(previousCell);
                    AllCellsTest.Add(newCellToReturn);
                    break;
                case direction.UP:
                    newCellToReturn = new Cell(previousCell.x, previousCell.y - 1, ValueAdder(AllCellsTest, previousCell.x, previousCell.y - 1), nextDirection, ringNumber);
                    newCellToReturn.Neighbours.Add(previousCell);
                    AllCellsTest.Add(newCellToReturn);
                    break;
                case direction.DOWN:
                    newCellToReturn = new Cell(previousCell.x, previousCell.y + 1, ValueAdder(AllCellsTest, previousCell.x, previousCell.y + 1), nextDirection, ringNumber);
                    newCellToReturn.Neighbours.Add(previousCell);
                    AllCellsTest.Add(newCellToReturn);
                    break;
                case direction.LEFT:
                    newCellToReturn = new Cell(previousCell.x - 1, previousCell.y, ValueAdder(AllCellsTest, previousCell.x - 1, previousCell.y), nextDirection, ringNumber);
                    newCellToReturn.Neighbours.Add(previousCell);
                    AllCellsTest.Add(newCellToReturn);
                    break;
            }

            return newCellToReturn;
        }

        private int ValueAdder(List<Cell> allCellsTest,int x, int y)
        {
            int sum = 0;

            foreach (Cell cellAround in allCellsTest)
            {
                sum += Surround(cellAround, x,y);
            }

            return sum;
        }

        private int Surround(Cell cellAround, int x, int y)
        {
            if (Math.Abs(cellAround.x - x) <= 1 && Math.Abs(cellAround.y - y) <= 1)
            {
                return cellAround.value;
            }

            return 0;
        }

        private direction CalculateNextDirection(Cell previousCell)
        {
            switch (previousCell.direction)
            {
                case direction.RIGHT:
                    if (Occupied(previousCell) == false && GetAllCells(new List<Cell>(), previousCell).Count >= 1)
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
            if (BottomRightCorner(AllCellsTest, cell))
            {
                AllCellsTest = AllCellsTest.Where(x => x.ringValue > ringNumber - 3).ToList();
            }
            allCells = AllCellsTest;

            //allCells = GetAllCells(allCells, cell);
            //AllCellsTest = allCells; 
            //Console.WriteLine("Loading.. "+((double)cell.value/ (double)input *100) +"%");
            foreach (Cell neighbour in cell.Neighbours)
            {
                switch (cell.direction)
                {
                    case direction.RIGHT:
                        if (allCells.Any(n => n.x == cell.x && n.y == cell.y - 1)) { return true; }
                        return false;
                    case direction.UP:
                        if (allCells.Any(n => n.x == cell.x - 1 && n.y == cell.y)) { return true; }
                        return false;
                    case direction.LEFT:
                        if (allCells.Any(n => n.x == cell.x && n.y == cell.y + 1)) { return true; }
                        return false;
                    case direction.DOWN:
                        if (allCells.Any(n => n.x == cell.x + 1 && n.y == cell.y)) { return true; }
                        return false;
                }
            }

            return false;
        }

        private bool BottomRightCorner(List<Cell> rings, Cell cell)
        {
            if (cell.direction == direction.RIGHT && (rings.Any(ringCell => ringCell.x == cell.x && ringCell.y == cell.y - 1) == false) && cell.value > 1)
            {
                ringNumber++;
                return true;
            }
            return false;
        }

        private List<Cell> GetAllCells(List<Cell> allCells, Cell cell)
        {
            allCells = new List<Cell>();

            while (cell.Neighbours != null && cell.Neighbours.Count > 0)
            {
                Cell neighbour = cell.Neighbours.First();
                allCells.Add(neighbour);
                cell = neighbour;
            }

            return allCells;
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
        public int ringValue;

        public Cell(int x, int y, int value, direction direction, int ringValue)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.Neighbours = new List<Cell>();
            this.direction = direction;
            this.ringValue = ringValue;
        }
    }
}

