using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This class represents a point, where x > 0, y > 0.
/// For consistency, let the top left be x=0, y=0,
/// let right be positive x
/// and down be positive y
/// </summary>

namespace MazeDemonstration
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        Point()
        {
            x = -1;
            y = -1;
        }
        Point(int X, int Y)
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
        }

    }
}
