using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

/// <summary>
/// Each Maze Node will have a simple structure:
/// Half of the Cardinal Directions will be used to represent if there is a wall in that direction
/// True - Wall is in that direction
/// False - Wall is not in that direction (i.e. Path is in that direction)‾
/// </summary>

namespace MazeDemonstration
{
    [ProtoContract(SkipConstructor = true)]
    public class MazeNode
    {
        [ProtoMember(1)]
        public bool North { get; set; }
        [ProtoMember(2)]
        public bool West { get; set; }
        [ProtoIgnore]
        public bool Visited { get; set; }
        public MazeNode()
        {
            North = false;
            West = false;
            Visited = false;
        }
        public MazeNode(bool north, bool west)
        {
            North = north;
            West = west;
            Visited = false;
        }
    }
}