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
    class Maze
    {
        // Maze Initialisation
        int[] dimensions { get; }
        MazeNode[,] nodes { get; set; }
        Maze()
        {
            dimensions = new int[2] { 20, 20 };
            nodes = InitialMaze(20, 20);
        }
        Maze(int x, int y)
        {
            dimensions = new int[2] { x, y };
            nodes = InitialMaze(x, y);
        }
        MazeNode[,] InitialMaze(int x, int y)
        {
            // When creating a new maze, we will create a blank square with a border of walls all around it
            nodes = new MazeNode[x,y];
            for (int currX = 0; currX < x; currX++)
            {
                nodes[currX, 0].North = true;
                nodes[currX, y - 1].South = true;
            }
            for (int currY = 0; currY < y; currY++)
            {
                nodes[0, currY].West = true;
                nodes[x - 1, currY].East = true;
            }
            return nodes;
        }
    }
}
