using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemonstration
{
    public class AStarHeuristicValuePair : IComparable<AStarHeuristicValuePair>
    {
        public int f { get; }
        public int g { get; }
        private int sum;
        public AStarHeuristicValuePair(int _f, int _g)
        {
            f = _f;
            g = _g;
            sum = f + g;
        }
        public int CompareTo(AStarHeuristicValuePair that)
        {
            if (sum < that.sum) return -1;
            if (sum == that.sum) return 0;
            return 1;
        }
    }
}
