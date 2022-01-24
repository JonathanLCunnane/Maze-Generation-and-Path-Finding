using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Each Maze Node will have a simple structure:
/// Each of the Cardinal Directions will be used to represent if there is a wall in that direction
/// True - Wall is in that direction
/// False - Wall is not in that direction (i.e. Path is in that direction)
/// e.g. North = True, East = False, South = True, West = True
/// this will, when displayed, look like a C shape:
///  _
/// |
///  ‾
/// </summary>

namespace MazeDemonstration
{
    class MazeNode
    {
        public bool North { get; set; }
        public bool East { get; set; }
        public bool South { get; set; }
        public bool West { get; set; }
        MazeNode()
        {
            North = false;
            East = false;
            South = false;
            West = false;
        }
        MazeNode(bool north, bool east, bool south, bool west)
        {
            North = north;
            East = east;
            South = south;
            West = west;
        }
    }
}