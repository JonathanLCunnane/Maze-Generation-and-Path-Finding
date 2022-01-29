using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        MazeNode[,] InitialMaze(int x, int y)
        {
            // When creating a new maze, we will create a blank square with a border of walls all around
            nodes = new MazeNode[x, y];
            for (int xNode = 0; xNode < x; xNode++)
            {
                for (int yNode = 0; yNode < y; yNode++)
                {
                    nodes[xNode, yNode] = new MazeNode();
                    if (xNode == 0)
                    {
                        nodes[xNode, yNode].West = true;
                        nodes[xNode, yNode].East = false;
                    }
                    else if (xNode == x - 1)
                    {
                        nodes[xNode, yNode].East = true;
                        nodes[xNode, yNode].West = false;
                    }
                    else
                    {
                        nodes[xNode, yNode].East = false;
                        nodes[xNode, yNode].West = false;
                    }
                    if (yNode == 0)
                    {
                        nodes[xNode, yNode].North = true;
                        nodes[xNode, yNode].South = false;
                    }
                    else if (yNode == y - 1)
                    {
                        nodes[xNode, yNode].South = true;
                        nodes[xNode, yNode].North = false;
                    }
                    else
                    {
                        nodes[xNode, yNode].South = false;
                        nodes[xNode, yNode].North = false;
                    }
                }
            }
            return nodes;
        }

        IEnumerable<MazeNode[,]> StepGeneration(MazeNode[,] nodes, Point start)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(0, 0));
            Point comingFrom = new Point();
            int counted = 1;
            while (counted < (dimensions[0] * dimensions[1]))
            {
                Point currPoint = stack.Peek();
                MazeNode currNode = nodes[currPoint.x, currPoint.y];
                List<int> cardinalDirections = new List<int>(); // {NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3}
                if (!currNode.North & !(comingFrom.y == currPoint.y - 1 & comingFrom.x == currPoint.x))
                {
                    cardinalDirections.Add(0);
                }
                if (!currNode.East & !(comingFrom.y == currPoint.y & comingFrom.x == currPoint.x + 1))
                {
                    cardinalDirections.Add(1);
                }
                if (currNode.South & comingFrom != 2)
                {
                    cardinalDirections.Add(2);
                }
                if (currNode.West)
                {
                    cardinalDirections.Add(3);
                }
                if (cardinalDirections.Count == 0)
                {
                    stack.Pop();
                    continue;
                }
                // Beginning the random selection of a direction and blocking off the other directions apart from the walls with 
                Random randGen = new Random();
                int directionIndex = randGen.Next(0, cardinalDirections.Count);
                int direction = cardinalDirections[directionIndex];
                cardinalDirections.Remove(prevDirection);
                switch (direction)
                {
                    case 0:
                        currNode
                        break;
                    case 1:
                        currNode  = new MazeNode(true, false, true, 

                }
            }
        }
    }
}
