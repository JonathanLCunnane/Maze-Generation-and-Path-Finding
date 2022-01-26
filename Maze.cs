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
            // When creating a new maze, we will create a blank square with a border of walls all around it
            nodes = new MazeNode[x,y];
            for (int currX = 0; currX < x; currX++)
            {
                nodes[currX, 0] = new MazeNode(true, false, false, false);
                nodes[currX, y - 1] = new MazeNode(false, false, true, false);
            }
            for (int currY = 0; currY < y; currY++)
            {
                nodes[0, currY] = new MazeNode(false, false, false, true);
                nodes[x - 1, currY] = new MazeNode(false, true, false, false);
            }
            return nodes;
        }
    }
}
