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
        public MazeSolverWindow(Maze _maze, PictureBox _picturebox)
        {
            // Get previous maze and bitmap
            maze = _maze;
            picturebox = _picturebox;
            // Initialise Component
            InitializeComponent();
            // Set Tags to default values
            startPointLabel.Tag = new Point(0, 0);
            finishPointLabel.Tag = new Point(maze.dimensions[0], maze.dimensions[1]);
            // Set up the current window with the maze not yet solved and other information.
            mazePictureBox.Size = picturebox.Size;
            mazePictureBox.Image = picturebox.Image;

            dimensionsLabel.Text = $"Dimensions ({maze.dimensions[0]}, {maze.dimensions[1]})";
            finishPointLabel.Text = $"Finish ({maze.dimensions[0]}, {maze.dimensions[1]})";


        }

        private void exitSolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setStart_Click(object sender, EventArgs e)
        {
            Point max = new Point(maze.dimensions[0], maze.dimensions[1]);
            StartPointDialogue startPointDiag = new StartPointDialogue(((Point)startPointLabel.Tag).x, ((Point)startPointLabel.Tag).y, max);
            DialogResult startPointDiagResult = startPointDiag.ShowDialog();

            if (startPointDiagResult == DialogResult.OK)
            {
                // Change start point label.
                startPointLabel.Text = $"Start - ({startPointDiag.x}, {startPointDiag.y})";
                startPointLabel.Tag = new Point(startPointDiag.x, startPointDiag.y);
                // Set location of start on the maze.
            }
        }

        private void setFinish_Click(object sender, EventArgs e)
        {
            Point max = new Point(maze.dimensions[0], maze.dimensions[1]);
            FinishPointDialogue finishPointDiag = new FinishPointDialogue(((Point)finishPointLabel.Tag).x, ((Point)finishPointLabel.Tag).y, max);
            DialogResult finishPointDiagResult = finishPointDiag.ShowDialog();

            if (finishPointDiagResult == DialogResult.OK)
            {
                // Change start point label.
                startPointLabel.Text = $"Start - ({finishPointDiag.x}, {finishPointDiag.y})";
                startPointLabel.Tag = new Point(finishPointDiag.x, finishPointDiag.y);
                // Set location of start on the maze.
            }
        }
    }
}
