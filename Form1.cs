using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace MazeDemonstration
{
    public partial class MazeGeneratorSolverForm : Form
    {
        Maze maze = new Maze();
        Bitmap mazeBitmap;
        int timeIntervalBetweenGenerationSteps = 250;
        int timerTick = 0;
        Brush bgColourBrush = new SolidBrush(DefaultBackColor);
        Stopwatch sw = Stopwatch.StartNew();
        long moveNext = 0;
        long current = 0;
        long alterMazeBitmap = 0;
        long displayBitmap = 0;
        public MazeGeneratorSolverForm()
        {
            InitializeComponent();
            mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
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
            sw.Restart();
            ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).MoveNext();
            sw.Stop();
            moveNext += sw.ElapsedTicks;
            sw.Restart();
            MazeDelta currChange = ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).Current;
            sw.Stop();
            current += sw.ElapsedTicks;
            sw.Restart();
            mazeBitmap = maze.AlterMazeBitmap(mazeBitmap, currChange, bgColourBrush);
            sw.Stop();
            alterMazeBitmap += sw.ElapsedTicks;
            sw.Restart();
            DisplayMazeBitmap(maze, mazeBitmap);
            sw.Stop();
            displayBitmap += sw.ElapsedTicks;
            timerTick++;
            if (timerTick == maze.dimensions[0] * maze.dimensions[0] - 1)
            {
                Console.WriteLine($"Move Next: {moveNext/(timerTick+1)} ticks");
                Console.WriteLine($"Current: {current / (timerTick + 1)} ticks");
                Console.WriteLine($"Alter Maze Bitmap: {alterMazeBitmap / (timerTick + 1)} ticks");
                Console.WriteLine($"Display Bitmap: {displayBitmap / (timerTick + 1)} ticks");
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
                mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
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

        private void saveCurrentImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg";
            DialogResult dialogResult = saveFileDialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileEXT = System.IO.Path.GetExtension(saveFileDialogue.FileName);
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
