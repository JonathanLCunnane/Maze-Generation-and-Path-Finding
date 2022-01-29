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
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point()
        {
            x = -1;
            y = -1;
        }
        public Point(int X, int Y)
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
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            Point point = (Point)obj;
            return point.x == x & point.y == y;
        }
    }
}
