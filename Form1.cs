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
        int pixelsPerDimension = 20;
        int pictureBoxPaddingPixels = 20;
        public MazeGeneratorSolverForm()
        {
            InitializeComponent();
            Bitmap mazeBitmap = GetMazeBitmap(maze);
            DisplayMazeBitmap(maze, mazeBitmap);
        }

        private void GenerateMaze_Click(object sender, EventArgs e)
        {

        }

        private void Dimensions_Click(object sender, EventArgs e)
        {
            DimensionsDialogue dimensionsDialogue = new DimensionsDialogue();
            DialogResult dialogResult = dimensionsDialogue.ShowDialog();
            // If 'Set Dimensions' was clicked, then set the dimensions.
            if (dialogResult == DialogResult.OK)
            {
                maze = new Maze(dimensionsDialogue.x, dimensionsDialogue.y);
                Bitmap mazeBitmap = GetMazeBitmap(maze);
                DisplayMazeBitmap(maze, mazeBitmap);
            }
            // If 'Cancel' was clicked, do nothing
        }

        private Bitmap GetMazeBitmap(Maze maze)
        {
            Bitmap mazeBitmap = new Bitmap(maze.dimensions[0] * pixelsPerDimension, maze.dimensions[1] * pixelsPerDimension);
            Graphics mazeBitmapGraphics = Graphics.FromImage(mazeBitmap);
            int rectangleX;
            int rectangleY;
            int rectangleWidth;
            int rectangleHeight;
            for (int x = 0; x < maze.dimensions[0]; x++)
            {
                for (int y = 0; y < maze.dimensions[1]; y++)
                {
                    rectangleX = (x * pixelsPerDimension + (pixelsPerDimension / 4));
                    rectangleY = (y * pixelsPerDimension + (pixelsPerDimension / 4));
                    rectangleWidth = (pixelsPerDimension / 2);
                    rectangleHeight = (pixelsPerDimension / 2);
                    mazeBitmapGraphics.FillRectangle(Brushes.Red, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                }
            }
            return mazeBitmap;
        }

        private void DisplayMazeBitmap(Maze maze, Bitmap mazeBitmap)
        {
            int pictureBoxWidth = (maze.dimensions[0] * pixelsPerDimension + pictureBoxPaddingPixels);
            int pictureBoxHeight = (maze.dimensions[1] * pixelsPerDimension + pictureBoxPaddingPixels);
            mazePictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            mazePictureBox.Image = GetMazeBitmap(maze);
        }
    }
}
