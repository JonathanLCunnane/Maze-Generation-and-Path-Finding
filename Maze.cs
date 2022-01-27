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
    }
}
