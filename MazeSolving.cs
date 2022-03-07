using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeDemonstration
{
    public static class MazeSolving
    {
        static Brush startColour = new SolidBrush(Color.FromArgb(0, 176, 80));
        static Brush finishColour = new SolidBrush(Color.FromArgb(255, 0, 0));
        public static Bitmap changeStartPoint(Bitmap mazeBitmap, Point oldStart, Point newStart, Brush bgColour)
        {
            using (Graphics bitmapGraphics = Graphics.FromImage(mazeBitmap))
            {
                int rectangleX;
                int rectangleY;
                int rectangleWidth = Consts.pixelsPerDimension - Consts.wallThickness;
                int rectangleHeight = Consts.pixelsPerDimension - Consts.wallThickness;
                // Remove Old if prev not null.
                if (oldStart != null)
                {
                    rectangleX = oldStart.x * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = oldStart.y * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    bitmapGraphics.FillRectangle(bgColour, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                }
                // Add New.
                rectangleX = newStart.x * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                rectangleY = newStart.y * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                bitmapGraphics.FillRectangle(startColour, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            }
            return mazeBitmap;
        }
        public static Bitmap changeFinishPoint(Bitmap mazeBitmap, Point oldStart, Point newStart, Brush bgColour)
        {
            using (Graphics bitmapGraphics = Graphics.FromImage(mazeBitmap))
            {
                int rectangleX;
                int rectangleY;
                int rectangleWidth = Consts.pixelsPerDimension - Consts.wallThickness;
                int rectangleHeight = Consts.pixelsPerDimension - Consts.wallThickness;
                // Remove Old if prev not null.
                if (oldStart != null)
                {
                    rectangleX = oldStart.x * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    rectangleY = oldStart.y * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                    bitmapGraphics.FillRectangle(bgColour, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                }
                // Add New.
                rectangleX = newStart.x * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                rectangleY = newStart.y * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                bitmapGraphics.FillRectangle(finishColour, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            }
            return mazeBitmap;
        }
        
        public static IEnumerable<Bitmap> iterativeBacktrace(Point start, Point finish, Dictionary<Point, Point> parent)
        {
            List<Point> path = new List<Point>() { finish };
            while (path.Last() != start)
            {
                path.Add(parent[path.Last()]);
                // Create and yield new bitmap.
                yield return new Bitmap(1, 1);
            }
        }
        public static IEnumerable<Bitmap> BFS(Maze maze, Point start, Point finish)
        {
            // Firstly reset all of the mazes nodes to not being visited
            maze.unvisitAll();
            // Create initial variables
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                Point currPoint = queue.Dequeue();
                if (currPoint == finish)
                {
                    foreach (Bitmap step in iterativeBacktrace(start, finish, parent))
                    {
                        yield return step;
                    }
                }
                // Check if you can go in any direction
                if (currPoint.y != 0) // North
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].North && !maze.nodes[currPoint.x, currPoint.y - 1].Visited) // North
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x, currPoint.y - 1);
                        queue.Enqueue(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);
                    }
                }
                if (currPoint.x != maze.dimensions[0] - 1) // East
                {
                    if (!maze.nodes[currPoint.x + 1, currPoint.y].West && !maze.nodes[currPoint.x + 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x + 1, currPoint.y);
                        queue.Enqueue(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);
                    }
                }
                if (currPoint.y != maze.dimensions[1] - 1) // South
                {
                    if (!maze.nodes[currPoint.x, currPoint.y + 1].North && !maze.nodes[currPoint.x, currPoint.y + 1].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x, currPoint.y + 1);
                        queue.Enqueue(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);
                    }
                }
                if (currPoint.x != 0) // West
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].West && !maze.nodes[currPoint.x - 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x - 1, currPoint.y);
                        queue.Enqueue(new Point(currPoint.x - 1, currPoint.y));
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);
                    }
                }
            }

            yield return new Bitmap(1, 1);
        }
    }
}
