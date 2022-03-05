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
    }
}
