using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;


/// <summary>
/// 
/// </summary>


namespace MazeDemonstration
{
    public class Maze
    {
        // Maze Initialisation
        public int[] dimensions { get; }
        public MazeNode[,] nodes { get; set; }
        public Maze()
        {
            dimensions = new int[2] { 3, 3 };
            nodes = InitialMaze(3, 3);
        }
        public Maze(int x, int y)
        {
            dimensions = new int[2] { x, y };
            nodes = InitialMaze(x, y);
        }
        Maze(int x, int y, MazeNode[,] _nodes)
        {
            dimensions = new int[2] { x, y };
            nodes = _nodes;
        }
        MazeNode[,] InitialMaze(int x, int y)
        {
            // When creating a new maze, we will create a blank square with a border of walls all around
            nodes = new MazeNode[x, y];
            for (int xNode = 0; xNode < x; xNode++)
            {
                for (int yNode = 0; yNode < y; yNode++)
                {
                    nodes[xNode, yNode] = new MazeNode(true, true, true, true);
                }
            }
            return nodes;
        }

        public Maze[] StepGeneration(Point start)
        {
            Stack<Point> stack = new Stack<Point>();
            List<Point> visited = new List<Point>();
            Random randGen = new Random();
            stack.Push(start);
            int counted = 0;
            Point nextPoint;
            Maze[] steps = new Maze[dimensions[0] * dimensions[1] - 1];
            while (counted < dimensions[0] * dimensions[1] - 1)
            {
                // Generate Steps
                Point currPoint = stack.Peek();
                visited.Add(currPoint);
                MazeNode currNode = nodes[currPoint.x, currPoint.y];
                List<int> cardinalDirections = new List<int>(); // {NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3}
                if (currNode.North & currPoint.y != 0 & visited.Contains(new Point(currPoint.x, currPoint.y - 1)) != true)
                {
                    cardinalDirections.Add(0);
                }
                if (currNode.East & currPoint.x != (dimensions[0] - 1) & visited.Contains(new Point(currPoint.x + 1, currPoint.y)) != true)
                {
                    cardinalDirections.Add(1);
                }
                if (currNode.South & currPoint.y != (dimensions[1] - 1) & visited.Contains(new Point(currPoint.x, currPoint.y + 1)) != true)
                {
                    cardinalDirections.Add(2);
                }
                if (currNode.West & currPoint.x != 0 & visited.Contains(new Point(currPoint.x - 1, currPoint.y)) != true)
                {
                    cardinalDirections.Add(3);
                }
                if (cardinalDirections.Count == 0)
                {
                    stack.Pop();
                    continue;
                }
                // Beginning the random selection of a direction and blocking off the other directions apart from the walls with 
                int directionIndex = randGen.Next(0, cardinalDirections.Count);
                int direction = cardinalDirections[directionIndex];
                switch (direction)
                {
                    case 0: // Going North -> Remove North wall of currNode and South wall of next node
                        currNode.North = false;
                        nodes[currPoint.x, currPoint.y - 1].South = false;
                        nextPoint = new Point(currPoint.x, currPoint.y - 1);
                        stack.Push(nextPoint);
                        break;
                    case 1: // Going East -> Remove East wall of currNode and West wall of next node
                        currNode.East = false;
                        nodes[currPoint.x + 1, currPoint.y].West = false;
                        nextPoint = new Point(currPoint.x + 1, currPoint.y);
                        stack.Push(nextPoint);
                        break;
                    case 2: // Going South -> Remove South wall of currNode and North wall of next node
                        currNode.South = false;
                        nodes[currPoint.x, currPoint.y + 1].North = false;
                        nextPoint = new Point(currPoint.x, currPoint.y + 1);
                        stack.Push(nextPoint);
                        break;
                    case 3: // Going West -> Remove West wall of currNode and East wall of next node
                        currNode.West = false;
                        nodes[currPoint.x - 1, currPoint.y].East = false;
                        nextPoint = new Point(currPoint.x - 1, currPoint.y);
                        stack.Push(nextPoint);
                        break;
                }
                MazeNode[,] newMazeNodes = new MazeNode[dimensions[0], dimensions[1]];
                for (int x = 0; x < dimensions[0]; x++)
                {
                    for (int y = 0; y < dimensions[1]; y++)
                    {
                        newMazeNodes[x, y] = new MazeNode(nodes[x, y].North, nodes[x, y].East, nodes[x, y].South, nodes[x, y].West);
                    }
                }
                steps[counted] = new Maze(dimensions[0], dimensions[1], newMazeNodes);
                counted++;
            }
            return steps;
        }

        public Bitmap GetMazeBitmap(Maze maze)
        {
            Bitmap mazeBitmap = new Bitmap(maze.dimensions[0] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels, maze.dimensions[1] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels);
            Graphics mazeBitmapGraphics = Graphics.FromImage(mazeBitmap);
            int rectangleX;
            int rectangleY;
            int rectangleWidth;
            int rectangleHeight;
            for (int x = 0; x < maze.dimensions[0]; x++)
            {
                for (int y = 0; y < maze.dimensions[1]; y++)
                {
                    MazeNode currentNode = maze.nodes[x, y];
                    if (currentNode.North)
                    {
                        rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.pixelsPerDimension + Consts.wallThickness;
                        rectangleHeight = Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    if (currentNode.East)
                    {
                        rectangleX = ((x + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.wallThickness;
                        rectangleHeight = Consts.pixelsPerDimension + Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    if (currentNode.South)
                    {
                        rectangleX = (x * Consts.pixelsPerDimension) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = ((y + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.pixelsPerDimension;
                        rectangleHeight = Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    if (currentNode.West)
                    {
                        rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.wallThickness;
                        rectangleHeight = Consts.pixelsPerDimension + Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                }
            }
            mazeBitmapGraphics.Dispose();
            return mazeBitmap;
        }

        public Bitmap GetMazeBitmap()
        {
            return GetMazeBitmap(this);
        }
    }
}
