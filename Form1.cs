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
        Bitmap mazeBitmap;
        int timeIntervalBetweenGenerationSteps = 250;
        int timerTick = 0;
        Brush bgColourBrush;
        public MazeGeneratorSolverForm()
        {
            InitializeComponent();
            mazeBitmap = maze.GetMazeBitmap();
            DisplayMazeBitmap(maze, mazeBitmap);
            bgColourBrush = new SolidBrush(DefaultBackColor);
        }

        private void GenerateMaze_Click(object sender, EventArgs e)
        {
            // Get Images
            Point startPoint = new Point(0, 0);
            mazeGenerationStepTimer.Tag = maze.StepGeneration(startPoint);

            // Initiate Timer
            mazeGenerationStepTimer.Interval = timeIntervalBetweenGenerationSteps;
            mazeGenerationStepTimer.Start();
        }

        private void mazeGenerationStepTimer_Tick(object sender, EventArgs e)
        {
            ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).MoveNext();
            MazeDelta currChange = ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).Current;
            mazeBitmap = maze.AlterMazeBitmap(mazeBitmap, currChange, bgColourBrush);
            DisplayMazeBitmap(maze, mazeBitmap);
            timerTick++;
            if (timerTick == maze.dimensions[0] * maze.dimensions[0] - 1)
            {
                ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).Dispose();
                mazeGenerationStepTimer.Tag = null;
                mazeGenerationStepTimer.Stop();
                timerTick = 0;
            }
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
                mazeBitmap = maze.GetMazeBitmap();
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
                timeIntervalBetweenGenerationSteps = timeIntervalDialogue.timeInterval;
            }
            // If 'Cancel' was clicked, do nothing
        }

        

        private void DisplayMazeBitmap(Maze maze, Bitmap mazeBitmap)
        {
            int pictureBoxWidth = maze.dimensions[0] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels;
            int pictureBoxHeight = maze.dimensions[1] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels;
            mazePictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            mazePictureBox.Image = mazeBitmap;
            mazePictureBox.Invalidate();
        }
    }
}
