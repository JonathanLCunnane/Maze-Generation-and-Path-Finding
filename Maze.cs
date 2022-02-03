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
                    nodes[xNode, yNode] = new MazeNode(true, true);
                }
            }
            return nodes;
        }

        public IEnumerator<MazeDelta> StepGeneration(Point start)
        {
            // Generate a deep copy of the nodes first, and initialise variables
            Stack<Point> stack = new Stack<Point>();
            List<Point> visited = new List<Point>();
            Random randGen = new Random();
            stack.Push(start);
            int counted = 0;
            Point nextPoint;
            yield return new MazeDelta(0, 0, 0);
            /*
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
                yield return new MazeDelta(currPoint.x, currPoint.y, direction);
                counted++;
            }*/
        }

        public static Bitmap GetMazeBitmap(Maze maze, Brush bgBrush)
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
                    rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.pixelsPerDimension + Consts.wallThickness;
                    rectangleHeight = Consts.wallThickness;
                    if (currentNode.North)
                    {
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    else
                    {
                        mazeBitmapGraphics.FillRectangle(bgBrush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.wallThickness;
                    rectangleHeight = Consts.pixelsPerDimension + Consts.wallThickness;
                    if (currentNode.West)
                    {
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    else
                    {
                        mazeBitmapGraphics.FillRectangle(bgBrush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    rectangleX = (x * Consts.pixelsPerDimension) + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = (y * Consts.pixelsPerDimension) + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.pixelsPerDimension - Consts.wallThickness;
                    rectangleHeight = Consts.pixelsPerDimension - Consts.wallThickness;
                    mazeBitmapGraphics.FillRectangle(bgBrush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                }
            }
            rectangleX = ((maze.dimensions[0] + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2) + 100;
            rectangleY = Consts.pixelsPerDimension - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
            rectangleWidth = Consts.wallThickness;
            rectangleHeight = (Consts.pixelsPerDimension * maze.dimensions[0]) + Consts.wallThickness;
            mazeBitmapGraphics.FillRectangle(Brushes.Red, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            return mazeBitmap;
        }

        public Bitmap GetMazeBitmap(Brush bgBrush)
        {
            return GetMazeBitmap(this, bgBrush);
        }

        public Bitmap AlterMazeBitmap(Bitmap mazeBitmap, MazeDelta mazeDelta, Brush brush)
        {
            Graphics mazeBitmapGraphics = Graphics.FromImage(mazeBitmap);
            int rectangleX;
            int rectangleY;
            int rectangleWidth;
            int rectangleHeight;
            int x = mazeDelta.x;
            int y = mazeDelta.y;
            switch (mazeDelta.directionChanged)
            {
                case 0:
                    rectangleX = (x * Consts.pixelsPerDimension) + (Consts.pictureBoxPaddingPixels / 2) + (Consts.wallThickness / 2);
                    rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.pixelsPerDimension - Consts.wallThickness;
                    rectangleHeight = Consts.wallThickness;
                    mazeBitmapGraphics.FillRectangle(brush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    break;
                case 1:
                    rectangleX = ((x + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = (y * Consts.pixelsPerDimension) + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.wallThickness;
                    rectangleHeight = Consts.pixelsPerDimension - Consts.wallThickness;
                    mazeBitmapGraphics.FillRectangle(brush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    break;
                case 2:
                    rectangleX = (x * Consts.pixelsPerDimension) + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = ((y + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.pixelsPerDimension - Consts.wallThickness;
                    rectangleHeight = Consts.wallThickness;
                    mazeBitmapGraphics.FillRectangle(brush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    break;
                case 3:
                    rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = (y * Consts.pixelsPerDimension) + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleWidth = Consts.wallThickness;
                    rectangleHeight = Consts.pixelsPerDimension - Consts.wallThickness;
                    mazeBitmapGraphics.FillRectangle(brush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    break;
            }
            return mazeBitmap;
        }
        public void ApplyMazeDelta(MazeDelta mazeDelta)
        {
            /*
            switch (mazeDelta.directionChanged)
            {
                case 0:
                    nodes[mazeDelta.x, mazeDelta.y].North = false;
                    nodes[mazeDelta.x, mazeDelta.y - 1].South = false;
                    break;
                case 1:
                    nodes[mazeDelta.x, mazeDelta.y].East = false;
                    nodes[mazeDelta.x + 1, mazeDelta.y].West = false;
                    break;
                case 2:
                    break;
            }*/
        }
        /*
        private Maze Copy()
        {
            MazeNode[,] copiedNodes = new MazeNode[dimensions[0], dimensions[1]];
            for (int xNode = 0; xNode < dimensions[0]; xNode++)
            {
                for (int yNode = 0; yNode < dimensions[1]; yNode++)
                {
                    copiedNodes[xNode, yNode] = new MazeNode(nodes[xNode, yNode].North, nodes[xNode, yNode].East, nodes[xNode, yNode].South, nodes[xNode, yNode].West);
                }
            }
            Maze copiedMaze = new Maze(dimensions[0], dimensions[1], copiedNodes);
            return copiedMaze;
        }
        */
    }
}
