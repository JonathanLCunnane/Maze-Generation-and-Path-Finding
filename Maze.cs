using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;
using ProtoBuf;

/// <summary>
/// 
/// </summary>


namespace MazeDemonstration
{
    [ProtoContract(SkipConstructor=true)]
    public class Maze
    {
        // Maze Initialisation
        [ProtoMember(1)]
        public int[] dimensions { get; }
        [ProtoIgnore]
        public MazeNode[,] nodes { get; set; }
        
        [ProtoMember(2), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private MazeNode[] nodesFlatten
        {
            get
            {
                if (nodes == null) { return null;  }
                MazeNode[] flattenedNodes = new MazeNode[dimensions[0]*dimensions[1]];
                int count = 0;
                foreach (MazeNode node in nodes)
                {
                    flattenedNodes[count] = node;
                    count++;
                }
                return flattenedNodes;
            }
            set
            {
                nodes = new MazeNode[dimensions[0], dimensions[1]];
                for(int x = 0; x < dimensions[0]; x++)
                {
                    for(int y = 0; y < dimensions[1]; y++)
                    {
                        nodes[x, y] = value[x * dimensions[0] + y];
                    }
                }
            }
        }
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
        public Maze(int x, int y, MazeNode[,] _nodes)
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

        public void GenerateUnstepped(Point start)
        {
            // Initialise variables
            Stack<Point> stack = new Stack<Point>();
            Random randGen = new Random();
            stack.Push(start);
            int counted = 0;
            Point nextPoint;
            while (counted < dimensions[0] * dimensions[1] - 1)
            {
                // Generate Steps
                Point currPoint = stack.Peek();
                nodes[currPoint.x, currPoint.y].Visited = true;
                List<int> cardinalDirections = new List<int>(); // {NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3}
                if (nodes[currPoint.x, currPoint.y].North)
                {
                    if (currPoint.y != 0)
                    {
                        if (!nodes[currPoint.x, currPoint.y - 1].Visited)
                        {
                            cardinalDirections.Add(0);
                        }
                    }
                }
                if (currPoint.x != (dimensions[0] - 1))
                {
                    if (nodes[currPoint.x + 1, currPoint.y].West)
                    {
                        if (!nodes[currPoint.x + 1, currPoint.y].Visited)
                        {
                            cardinalDirections.Add(1);
                        }
                    }
                }
                if (currPoint.y != (dimensions[1] - 1))
                {
                    if (nodes[currPoint.x, currPoint.y + 1].North)
                    {
                        if (!nodes[currPoint.x, currPoint.y + 1].Visited)
                        {
                            cardinalDirections.Add(2);
                        }
                    }
                }
                if (nodes[currPoint.x, currPoint.y].West)
                {
                    if (currPoint.x != 0)
                    {
                        if (!nodes[currPoint.x - 1, currPoint.y].Visited)
                        {
                            cardinalDirections.Add(3);
                        }
                    }
                }
                if (cardinalDirections.Count == 0)
                {
                    stack.Pop();
                    continue;
                }
                // Beginning the random selection of a direction and blocking off the other directions apart from the walls with 
                int direction = cardinalDirections[randGen.Next(0, cardinalDirections.Count)];
                switch (direction)
                {
                    case 0: // Going North -> Remove North wall of current node
                        nodes[currPoint.x, currPoint.y].North = false;
                        nextPoint = new Point(currPoint.x, currPoint.y - 1);
                        stack.Push(nextPoint);
                        break;
                    case 1: // Going East -> Remove West wall of node to the right
                        nodes[currPoint.x + 1, currPoint.y].West = false;
                        nextPoint = new Point(currPoint.x + 1, currPoint.y);
                        stack.Push(nextPoint);
                        break;
                    case 2: // Going South -> Remove Noth wall of node below
                        nodes[currPoint.x, currPoint.y + 1].North = false;
                        nextPoint = new Point(currPoint.x, currPoint.y + 1);
                        stack.Push(nextPoint);
                        break;
                    case 3: // Going West -> Remove West wall of current node
                        nodes[currPoint.x, currPoint.y].West = false;
                        nextPoint = new Point(currPoint.x - 1, currPoint.y);
                        stack.Push(nextPoint);
                        break;
                }
                counted++;
            }
        }

        public IEnumerator<MazeDelta> StepGeneration(Point start)
        {
            // Initialise variables
            Stack<Point> stack = new Stack<Point>();
            Random randGen = new Random();
            stack.Push(start);
            int counted = 0;
            Point nextPoint;
            while (counted < dimensions[0] * dimensions[1] - 1)
            {
                // Generate Steps
                Point currPoint = stack.Peek();
                nodes[currPoint.x, currPoint.y].Visited = true;
                List<int> cardinalDirections = new List<int>(); // {NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3}
                if (nodes[currPoint.x, currPoint.y].North)
                {
                    if (currPoint.y != 0)
                    {
                        if (!nodes[currPoint.x, currPoint.y - 1].Visited)
                        {
                            cardinalDirections.Add(0);
                        }
                    }
                }
                if (currPoint.x != (dimensions[0] - 1))
                {
                    if (nodes[currPoint.x + 1, currPoint.y].West)
                    {
                        if (!nodes[currPoint.x + 1, currPoint.y].Visited)
                        {
                            cardinalDirections.Add(1);
                        }
                    }
                }
                if (currPoint.y != (dimensions[1] - 1))
                {
                    if (nodes[currPoint.x, currPoint.y + 1].North)
                    {
                        if (!nodes[currPoint.x, currPoint.y + 1].Visited)
                        {
                            cardinalDirections.Add(2);
                        }
                    }
                }
                if (nodes[currPoint.x, currPoint.y].West)
                {
                    if (currPoint.x != 0)
                    {
                        if (!nodes[currPoint.x - 1, currPoint.y].Visited)
                        {
                            cardinalDirections.Add(3);
                        }
                    }
                }
                if (cardinalDirections.Count == 0)
                {
                    stack.Pop();
                    continue;
                }
                // Beginning the random selection of a direction and blocking off the other directions apart from the walls with 
                int direction = cardinalDirections[randGen.Next(0, cardinalDirections.Count)];
                switch (direction)
                {
                    case 0: // Going North -> Remove North wall of current node
                        nodes[currPoint.x, currPoint.y].North = false;
                        nextPoint = new Point(currPoint.x, currPoint.y - 1);
                        stack.Push(nextPoint);
                        break;
                    case 1: // Going East -> Remove West wall of node to the right
                        nodes[currPoint.x + 1, currPoint.y].West = false;
                        nextPoint = new Point(currPoint.x + 1, currPoint.y);
                        stack.Push(nextPoint);
                        break;
                    case 2: // Going South -> Remove Noth wall of node below
                        nodes[currPoint.x, currPoint.y + 1].North = false;
                        nextPoint = new Point(currPoint.x, currPoint.y + 1);
                        stack.Push(nextPoint);
                        break;
                    case 3: // Going West -> Remove West wall of current node
                        nodes[currPoint.x, currPoint.y].West = false;
                        nextPoint = new Point(currPoint.x - 1, currPoint.y);
                        stack.Push(nextPoint);
                        break;
                }
                yield return new MazeDelta(currPoint.x, currPoint.y, direction);
                counted++;
            }
        }

        public static Bitmap GetMazeBitmap(Maze maze, Brush bgBrush)
        {
            Bitmap mazeBitmap = new Bitmap(maze.dimensions[0] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels, maze.dimensions[1] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics mazeBitmapGraphics = Graphics.FromImage(mazeBitmap);
            mazeBitmapGraphics.FillRectangle(bgBrush, 0, 0, mazeBitmap.Width, mazeBitmap.Height);
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
                    if (currentNode.West)
                    {
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleHeight, rectangleWidth);
                    }
                }
            }
            // West Wall
            rectangleX = ((maze.dimensions[0]) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
            rectangleY = (Consts.pictureBoxPaddingPixels / 2) - (Consts.wallThickness / 2);
            rectangleWidth = Consts.wallThickness;
            rectangleHeight = (Consts.pixelsPerDimension * maze.dimensions[1]) + Consts.wallThickness;
            mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            // South Wall
            rectangleX = (Consts.pictureBoxPaddingPixels / 2) - (Consts.wallThickness / 2);
            rectangleY = ((maze.dimensions[1]) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
            rectangleWidth = (Consts.pixelsPerDimension * maze.dimensions[0]) + Consts.wallThickness;
            rectangleHeight = Consts.wallThickness;
            mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
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
            switch (mazeDelta.directionChanged)
            {
                case 0:
                    nodes[mazeDelta.x, mazeDelta.y].North = false;
                    break;
                case 1:
                    nodes[mazeDelta.x + 1, mazeDelta.y].West = false;
                    break;
                case 2:
                    nodes[mazeDelta.x, mazeDelta.y + 1].North = false;
                    break;
                case 3:
                    nodes[mazeDelta.x, mazeDelta.y].West = false;
                    break;
            }
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
