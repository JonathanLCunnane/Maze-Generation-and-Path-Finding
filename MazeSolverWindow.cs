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
    public partial class MazeSolverWindow : Form
    {
        Maze maze { get; set; }
        PictureBox picturebox { get; set; }
        Bitmap currBitmap { get; set; }
        Brush bgBrush = new SolidBrush(DefaultBackColor);
        public MazeSolverWindow(Maze _maze, PictureBox _picturebox)
        {
            // Get previous maze and bitmap
            maze = _maze;
            picturebox = _picturebox;
            currBitmap = (Bitmap)_picturebox.Image;
            // Initialise Component
            InitializeComponent();
            // Set Tags to default values
            startPointLabel.Tag = new Point(0, 0);
            finishPointLabel.Tag = new Point(maze.dimensions[0] - 1, maze.dimensions[1] - 1);
            // Set up the current window with the maze not yet solved and other information.
            mazePictureBox.Size = picturebox.Size;
            mazePictureBox.Image = picturebox.Image;

            dimensionsLabel.Text = $"Dimensions - ({maze.dimensions[0]}, {maze.dimensions[1]})";
            finishPointLabel.Text = $"Finish - ({maze.dimensions[0] - 1}, {maze.dimensions[1] - 1})";

            // Draw Initial start and finish
            mazePictureBox.Image = MazeSolving.changeStartPoint(currBitmap, null, (Point)startPointLabel.Tag, bgBrush);
            mazePictureBox.Image = MazeSolving.changeFinishPoint(currBitmap, null, (Point)finishPointLabel.Tag, bgBrush);
        }

        private void exitSolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setStart_Click(object sender, EventArgs e)
        {
            Point max = new Point(maze.dimensions[0] - 1, maze.dimensions[1] - 1);
            StartPointDialogue startPointDiag = new StartPointDialogue(((Point)startPointLabel.Tag).x, ((Point)startPointLabel.Tag).y, max);
            DialogResult startPointDiagResult = startPointDiag.ShowDialog();

            if (startPointDiagResult == DialogResult.OK)
            {
                Point prev = new Point(((Point)startPointLabel.Tag).x, ((Point)startPointLabel.Tag).y);
                // Change start point label.
                startPointLabel.Text = $"Start - ({startPointDiag.x}, {startPointDiag.y})";
                Point next = new Point(startPointDiag.x, startPointDiag.y);
                startPointLabel.Tag = next;
                // Set location of start on the maze.
                mazePictureBox.Image = MazeSolving.changeStartPoint(currBitmap, prev, next, bgBrush);
            }
        }

        private void setFinish_Click(object sender, EventArgs e)
        {
            Point max = new Point(maze.dimensions[0] - 1, maze.dimensions[1] - 1);
            FinishPointDialogue finishPointDiag = new FinishPointDialogue(((Point)finishPointLabel.Tag).x, ((Point)finishPointLabel.Tag).y, max);
            DialogResult finishPointDiagResult = finishPointDiag.ShowDialog();

            if (finishPointDiagResult == DialogResult.OK)
            {
                Point prev = new Point(((Point)finishPointLabel.Tag).x, ((Point)finishPointLabel.Tag).y);
                // Change start point label.
                finishPointLabel.Text = $"Finish - ({finishPointDiag.x}, {finishPointDiag.y})";
                Point next = new Point(finishPointDiag.x, finishPointDiag.y);
                finishPointLabel.Tag = next;
                // Set location of start on the maze.
                mazePictureBox.Image = MazeSolving.changeFinishPoint(currBitmap, prev, next, bgBrush);
            }
        }
    }
}
