using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            currBitmap = new Bitmap ((Bitmap)_picturebox.Image);
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

            algorithmTypeLabel.Tag = "A*";
            timeIntervalLabel.Tag = 25;

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

        private void setPathfindingAlgorithmAStar_Click(object sender, EventArgs e)
        {
            // Change the pathfinding algorithm label and tag first.
            algorithmTypeLabel.Text = "Pathfinding Algorithm Type - A*";
            algorithmTypeLabel.Tag = "A*";
        }

        private void setPathfindingAlgorithmBFS_Click(object sender, EventArgs e)
        {
            // Change the pathfinding algorithm label and tag first.
            algorithmTypeLabel.Text = "Pathfinding Algorithm Type - BFS";
            algorithmTypeLabel.Tag = "BFS";
        }

        private void setPathfindingAlgorithmDijkstra_Click(object sender, EventArgs e)
        {
            // Change the pathfinding algorithm label and tag first.
            algorithmTypeLabel.Text = "Pathfinding Algorithm Type - Dijkstra";
            algorithmTypeLabel.Tag = "Dijkstra";
        }

        private void setPathfindingAlgorithmDFS_Click(object sender, EventArgs e)
        {
            // Change the pathfinding algorithm label and tag first.
            algorithmTypeLabel.Text = "Pathfinding Algorithm Type - DFS";
            algorithmTypeLabel.Tag = "DFS";
        }

        private void startSolver_Click(object sender, EventArgs e)
        {
            // Carry out the correct algorithm based on the algorithm currently selected.
            switch (algorithmTypeLabel.Tag)
            {
                case "A*":
                    // If instant generation not required.
                    if (!instantCheckBox.Checked)
                    {
                        break;
                    }
                    // Else instant generation
                    break;
                case "BFS":
                    // If instant generation not required.
                    if (!instantCheckBox.Checked)
                    {
                        mazeSolvingStepTimer.Tag = MazeSolving.BFSInterval(maze, (Point)startPointLabel.Tag, (Point)finishPointLabel.Tag, currBitmap);
                    }
                    // Else instant generation
                    else
                    {
                        mazeSolvingStepTimer.Tag = MazeSolving.BFSNoInterval(maze, (Point)startPointLabel.Tag, (Point)finishPointLabel.Tag, currBitmap);
                    }
                    mazeSolvingStepTimer.Start();
                    break;
                case "Dijkstra":
                    // If instant generation not required.
                    if (!instantCheckBox.Checked)
                    {
                        break;
                    }
                    // Else instant generation
                    break;
                case "DFS":
                    // If instant generation not required.
                    if (!instantCheckBox.Checked)
                    {
                        break;
                    }
                    // Else instant generation
                    break;
            }
        }

        private void timeInterval_Click(object sender, EventArgs e)
        {
            TimeIntervalDialogue timeIntervalDialogue = new TimeIntervalDialogue((int)timeIntervalLabel.Tag);
            DialogResult dialogueResult = timeIntervalDialogue.ShowDialog();
            // If 'Set Time Interval' was clicked, set the time interval to whatever was on the track bar.
            if (dialogueResult == DialogResult.OK)
            {
                mazeSolvingStepTimer.Interval = timeIntervalDialogue.timeInterval;
                timeIntervalLabel.Tag = timeIntervalDialogue.timeInterval;
                timeIntervalLabel.Text = $"Interval Between Steps - {timeIntervalDialogue.timeInterval}ms";
            }
            // If 'Cancel' was clicked, do nothing
        }

        private void instantCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (instantCheckBox.Checked)
            {
                timeInterval.Available = false;
                timeIntervalLabel.Text = "Interval Between Steps - None";
                return;
            }
            timeInterval.Available = true;
            timeIntervalLabel.Text = $"Interval Between Steps - {(int)timeIntervalLabel.Tag}ms";
        }

        private void mazeSolvingStepTimer_Tick(object sender, EventArgs e)
        {
            // If the tag is an iterator, iterate over the bitmaps within that iterator.
            if (mazeSolvingStepTimer.Tag is IEnumerator<Bitmap>)
            {
                // If there are Bitmaps left then display them, otherwise stop the timer
                if (((IEnumerator<Bitmap>)mazeSolvingStepTimer.Tag).MoveNext())
                {
                    mazePictureBox.Image = ((IEnumerator<Bitmap>)mazeSolvingStepTimer.Tag).Current;
                }
                else
                {
                    mazeSolvingStepTimer.Stop();
                    ((IEnumerator<Bitmap>)mazeSolvingStepTimer.Tag).Dispose();
                }
            }
            else
            {
                mazePictureBox.Image = new Bitmap ((Bitmap)mazeSolvingStepTimer.Tag);
                mazeSolvingStepTimer.Stop();
                ((Bitmap)mazeSolvingStepTimer.Tag).Dispose();
            }
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg";
            saveFileDialogue.RestoreDirectory = true;
            DialogResult dialogResult = saveFileDialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileEXT = Path.GetExtension(saveFileDialogue.FileName);
                ImageFormat format;
                switch (fileEXT)
                {
                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    default:
                        format = ImageFormat.Png;
                        break;
                }
                mazePictureBox.Image.Save(saveFileDialogue.FileName, format);
            }
        }
    }
}
