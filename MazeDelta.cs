using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A maze delta represents the **removal** of a wall within the maze.
/// </summary>

namespace MazeDemonstration
{
    public class MazeDelta
    {
        public int x { get; }
        public int y { get; }
        public int directionChanged { get; } // 0 is NORTH, 1 is EAST, 2 is SOUTH, 3 is WEST
        public MazeDelta(int X, int Y, int _directionChanged)
        {
            if (x < 0 | y < 0)
            {
                throw new ArgumentException("Ensure that the point has values of X and Y above zero.", "X or Y");
            }
            else
            {
                x = X;
                y = Y;
            }
            directionChanged = _directionChanged;
        }
    }
}
