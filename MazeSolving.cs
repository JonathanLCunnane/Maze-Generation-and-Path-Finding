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
        static Brush currPointColour = new SolidBrush(Color.FromArgb(170, 160, 250));
        static Brush nextPointColour = new SolidBrush(Color.FromArgb(250, 130, 210));
        static Brush pathColour = new SolidBrush(Color.FromArgb(250, 220, 100));
        private static Bitmap drawSquare(Bitmap originalBitmap, Point point, Brush colour)
        {
            using (Graphics bitmapGraphics = Graphics.FromImage(originalBitmap))
            {
                int rectangleX = point.x * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                int rectangleY = point.y * Consts.pixelsPerDimension + (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                int rectangleWidth = Consts.pixelsPerDimension - Consts.wallThickness;
                int rectangleHeight = Consts.pixelsPerDimension - Consts.wallThickness;
                bitmapGraphics.FillRectangle(colour, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            }
            return originalBitmap;
        }
        public static Bitmap changeStartPoint(Bitmap mazeBitmap, Point oldStart, Point newStart, Brush bgColour)
        {
            // Remove Old if prev not null.
            if (oldStart != null)
            {
                mazeBitmap = drawSquare(mazeBitmap, oldStart, bgColour);
            }
            // Add New.
            mazeBitmap = drawSquare(mazeBitmap, newStart, startColour);
            return mazeBitmap;
        }
        public static Bitmap changeFinishPoint(Bitmap mazeBitmap, Point oldStart, Point newStart, Brush bgColour)
        {
            // Remove Old if prev not null.
            if (oldStart != null)
            {
                mazeBitmap = drawSquare(mazeBitmap, oldStart, bgColour);
            }
            // Add New.
            mazeBitmap = drawSquare(mazeBitmap, newStart, finishColour);
            return mazeBitmap;
        }
        
        private static Bitmap notIterativeBacktrace(Point start, Point finish, Dictionary<Point, Point> parent, Bitmap bitmap)
        {
            List<Point> path = new List<Point>() { finish };
            while (!parent[path.Last()].Equals(start))
            {
                path.Add(parent[path.Last()]);
                // Create and yield new bitmap.
                bitmap = drawSquare(bitmap, path.Last(), pathColour);
            }
            return bitmap;
        }
        private static IEnumerable<Bitmap> iterativeBacktrace(Point start, Point finish, Dictionary<Point, Point> parent, Bitmap bitmap)
        {
            List<Point> path = new List<Point>() { finish };
            while (!parent[path.Last()].Equals(start))
            {
                path.Add(parent[path.Last()]);
                // Create and yield new bitmap.
                bitmap = drawSquare(bitmap, path.Last(), pathColour);
                yield return bitmap;
            }
        }
        
        public static Bitmap BFSNoInterval(Maze maze, Point start, Point finish, Bitmap originalBitmap)
        {
            // Firstly reset all of the mazes nodes to not being visited
            maze.unvisitAll();
            // Create initial variables
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(start);

            // Set start to being visited
            maze.nodes[start.x, start.y].Visited = true;
            while (queue.Count > 0)
            {
                // Set current point and draw onto bitmap if it is not the start or finish
                Point currPoint = queue.Dequeue();
                if (!currPoint.Equals(start))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, currPointColour);
                }
                if (currPoint.Equals(finish))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, finishColour);
                    originalBitmap = notIterativeBacktrace(start, finish, parent, originalBitmap);
                    return originalBitmap;
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

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
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

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
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

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                    }
                }
                if (currPoint.x != 0) // West
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].West && !maze.nodes[currPoint.x - 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x - 1, currPoint.y);
                        queue.Enqueue(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                    }
                }
            }
            return originalBitmap;
        }
        public static IEnumerator<Bitmap> BFSInterval(Maze maze, Point start, Point finish, Bitmap originalBitmap)
        {
            // Firstly reset all of the mazes nodes to not being visited
            maze.unvisitAll();
            // Create initial variables
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(start);

            // Set start to being visited
            maze.nodes[start.x, start.y].Visited = true;
            while (queue.Count > 0)
            {
                // Set current point and draw onto bitmap if it is not the start or finish
                Point currPoint = queue.Dequeue();
                if (!currPoint.Equals(start))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, currPointColour);
                }
                if (currPoint.Equals(finish))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, finishColour);
                    foreach (Bitmap step in iterativeBacktrace(start, finish, parent, originalBitmap))
                    {
                        yield return step;
                    }
                    yield break;
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

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
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

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
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

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
                    }
                }
                if (currPoint.x != 0) // West
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].West && !maze.nodes[currPoint.x - 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x - 1, currPoint.y);
                        queue.Enqueue(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
                    }
                }
            }
        }

        public static Bitmap DFSNoInterval(Maze maze, Point start, Point finish, Bitmap originalBitmap)
        {
            // Firstly reset all of the mazes nodes to not being visited
            maze.unvisitAll();
            // Create initial variables
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();
            Stack<Point> stack = new Stack<Point>();
            stack.Push(start);

            // Set start to being visited
            maze.nodes[start.x, start.y].Visited = true;
            while (stack.Count > 0)
            {
                // Set current point and draw onto bitmap if it is not the start or finish
                Point currPoint = stack.Pop();
                if (!currPoint.Equals(start))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, currPointColour);
                }
                if (currPoint.Equals(finish))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, finishColour);
                    originalBitmap = notIterativeBacktrace(start, finish, parent, originalBitmap);
                    return originalBitmap;
                }
                // Check if you can go in any direction
                if (currPoint.y != 0) // North
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].North && !maze.nodes[currPoint.x, currPoint.y - 1].Visited) // North
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x, currPoint.y - 1);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                    }
                }
                if (currPoint.x != maze.dimensions[0] - 1) // East
                {
                    if (!maze.nodes[currPoint.x + 1, currPoint.y].West && !maze.nodes[currPoint.x + 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x + 1, currPoint.y);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                    }
                }
                if (currPoint.y != maze.dimensions[1] - 1) // South
                {
                    if (!maze.nodes[currPoint.x, currPoint.y + 1].North && !maze.nodes[currPoint.x, currPoint.y + 1].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x, currPoint.y + 1);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                    }
                }
                if (currPoint.x != 0) // West
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].West && !maze.nodes[currPoint.x - 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x - 1, currPoint.y);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                    }
                }
            }
            return originalBitmap;
        }
        public static IEnumerator<Bitmap> DFSInterval(Maze maze, Point start, Point finish, Bitmap originalBitmap)
        {
            // Firstly reset all of the mazes nodes to not being visited
            maze.unvisitAll();
            // Create initial variables
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();
            Stack<Point> stack = new Stack<Point>();
            stack.Push(start);

            // Set start to being visited
            maze.nodes[start.x, start.y].Visited = true;
            while (stack.Count > 0)
            {
                // Set current point and draw onto bitmap if it is not the start or finish
                Point currPoint = stack.Pop();
                if (!currPoint.Equals(start))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, currPointColour);
                }
                if (currPoint.Equals(finish))
                {
                    originalBitmap = drawSquare(originalBitmap, currPoint, finishColour);
                    foreach (Bitmap step in iterativeBacktrace(start, finish, parent, originalBitmap))
                    {
                        yield return step;
                    }
                    yield break;
                }
                // Check if you can go in any direction
                if (currPoint.y != 0) // North
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].North && !maze.nodes[currPoint.x, currPoint.y - 1].Visited) // North
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x, currPoint.y - 1);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
                    }
                }
                if (currPoint.x != maze.dimensions[0] - 1) // East
                {
                    if (!maze.nodes[currPoint.x + 1, currPoint.y].West && !maze.nodes[currPoint.x + 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x + 1, currPoint.y);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
                    }
                }
                if (currPoint.y != maze.dimensions[1] - 1) // South
                {
                    if (!maze.nodes[currPoint.x, currPoint.y + 1].North && !maze.nodes[currPoint.x, currPoint.y + 1].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x, currPoint.y + 1);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
                    }
                }
                if (currPoint.x != 0) // West
                {
                    if (!maze.nodes[currPoint.x, currPoint.y].West && !maze.nodes[currPoint.x - 1, currPoint.y].Visited)
                    {
                        // Add next point to the queue and set current as visited
                        Point newPoint = new Point(currPoint.x - 1, currPoint.y);
                        stack.Push(newPoint);
                        maze.nodes[currPoint.x, currPoint.y].Visited = true;

                        // Record the parent for recursion
                        parent.Add(newPoint, currPoint);

                        // Draw to be visited square
                        originalBitmap = drawSquare(originalBitmap, newPoint, nextPointColour);
                        yield return originalBitmap;
                    }
                }
            }
        }
    }
}
