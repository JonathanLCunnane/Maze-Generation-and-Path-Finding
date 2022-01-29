using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeDemonstration
{
    public partial class MazeGeneratorSolverForm : Form
    {
        Maze maze = new Maze();
        public MazeGeneratorSolverForm()
        {
            InitializeComponent();
            Bitmap mazeBitmap = GetMazeBitmap(maze);
            DisplayMazeBitmap(maze, mazeBitmap);
        }

        private void GenerateMaze_Click(object sender, EventArgs e)
        {
            maze.
        }

        private void Dimensions_Click(object sender, EventArgs e)
        {
            DimensionsDialogue dimensionsDialogue = new DimensionsDialogue();
            DialogResult dialogueResult = dimensionsDialogue.ShowDialog();
            // If 'Set Dimensions' was clicked, then set the dimensions.
            if (dialogueResult == DialogResult.OK)
            {
                // Change dimensions label.
                dimensionsLabel.Text = "Dimensions (x, y) - (" + dimensionsDialogue.x.ToString() + ", " + dimensionsDialogue.y.ToString() + ")";
                // Create new blank maze.
                maze = new Maze(dimensionsDialogue.x, dimensionsDialogue.y);
                Bitmap mazeBitmap = GetMazeBitmap(maze);
                DisplayMazeBitmap(maze, mazeBitmap);
            }
            // If 'Cancel' was clicked, do nothing
        }

        private void TimeInterval_Click(object sender, EventArgs e)
        {
            TimeIntervalDialogue timeIntervalDialogue = new TimeIntervalDialogue();
            DialogResult dialogueResult = timeIntervalDialogue.ShowDialog();
            // If 'Set Time Interval' was clicked, set the time interval to whatever was on the track bar.
            if (dialogueResult == DialogResult.OK)
            {
                timeIntervalLabel.Text = "Interval Between Steps - " + timeIntervalDialogue.timeInterval + "ms";
            }
            // If 'Cancel' was clicked, do nothing
        }

        private Bitmap GetMazeBitmap(Maze maze)
        {
            Bitmap mazeBitmap = new Bitmap(maze.dimensions[0] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels, maze.dimensions[1] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels);
            Graphics mazeBitmapGraphics = Graphics.FromImage(mazeBitmap);
            int rectangleX;
            int rectangleY;
            int rectangleWidth;
            int rectangleHeight;
            for (int x = 0; x < maze.dimensions[0]; x++)
            {
                for (int y = 0; y < maze.dimensions[1]; y++)
                {
                    MazeNode currentNode = maze.nodes[x, y];
                    Console.Write(x);
                    Console.Write(y);
                    Console.Write(":  ");
                    if (currentNode.North)
                    {
                        Console.WriteLine("north");
                        rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.pixelsPerDimension + Consts.wallThickness;
                        rectangleHeight = Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    if (currentNode.East)
                    {
                        Console.WriteLine("east");
                        rectangleX = ((x + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.wallThickness;
                        rectangleHeight = Consts.pixelsPerDimension + Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    if (currentNode.South)
                    {
                        Console.WriteLine("south");
                        rectangleX = (x * Consts.pixelsPerDimension) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = ((y + 1) * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.pixelsPerDimension;
                        rectangleHeight = Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                    if (currentNode.West)
                    {
                        Console.WriteLine("west");
                        rectangleX = (x * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleY = (y * Consts.pixelsPerDimension) - (Consts.wallThickness / 2) + (Consts.pictureBoxPaddingPixels / 2);
                        rectangleWidth = Consts.wallThickness;
                        rectangleHeight = Consts.pixelsPerDimension + Consts.wallThickness;
                        mazeBitmapGraphics.FillRectangle(Brushes.Black, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                    }
                }
            }
            return mazeBitmap;
        }

        private void DisplayMazeBitmap(Maze maze, Bitmap mazeBitmap)
        {
            int pictureBoxWidth = maze.dimensions[0] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels;
            int pictureBoxHeight = maze.dimensions[1] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels;
            mazePictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            mazePictureBox.Image = mazeBitmap;
        }
    }
}
