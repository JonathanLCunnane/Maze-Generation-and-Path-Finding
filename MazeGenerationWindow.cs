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
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ProtoBuf;

namespace MazeDemonstration
{
    public partial class MazeGeneratorSolverForm : Form
    {
        Maze maze;
        Bitmap mazeBitmap;
        int timeIntervalBetweenGenerationSteps = 25;
        int timerTick = 0;
        Brush bgColourBrush = new SolidBrush(DefaultBackColor);
        PointF imageStartPoint = new PointF(15, 60);
        public MazeGeneratorSolverForm()
        {
            // Initialise the component
            InitializeComponent();
            // Set Default Tags
            dimensionsLabel.Tag = new Point(3, 3);
            timeIntervalLabel.Tag = 25;
            // Get Default Maze
            maze = new Maze();
            mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
            //DisplayMazeBitmap(maze, mazeBitmap);
            using (Graphics graphics = )
            {
                this.Paint
                graphics.DrawImage(mazeBitmap, imageStartPoint);
            }
            bgColourBrush = new SolidBrush(DefaultBackColor);
        }

        private void GenerateMaze_Click(object sender, EventArgs e)
        {
            // Disable and Enable Components. Also, start showing the progress bar.
            instantCheckBox.Enabled = false;
            Dimensions.Enabled = false;
            TimeInterval.Enabled = false;
            GenerateMaze.Enabled = false;
            ResetMaze.Enabled = true;
            if (!instantCheckBox.Checked)
            {
                openMazeFile.Enabled = false;

                // Start Generation
                Point startPoint = new Point(0, 0);
                mazeGenerationStepTimer.Tag = maze.StepGeneration(startPoint);

                // Initiate Timer
                mazeGenerationStepTimer.Interval = timeIntervalBetweenGenerationSteps;
                mazeGenerationStepTimer.Start();
            }
            else
            {
                // Generate and Display Maze
                Point startPoint = new Point(0, 0);
                maze.GenerateUnstepped(startPoint);
                mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
                //DisplayMazeBitmap(maze, mazeBitmap);
                using (Graphics graphics = CreateGraphics())
                {
                    graphics.DrawImage(mazeBitmap, imageStartPoint);
                }
            }
        }

        private void mazeGenerationStepTimer_Tick(object sender, EventArgs e)
        {
            ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).MoveNext();
            MazeDelta currChange = ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).Current;
            mazeBitmap = maze.AlterMazeBitmap(mazeBitmap, currChange, bgColourBrush);
            //DisplayMazeBitmap(maze, mazeBitmap);
            using (Graphics graphics = CreateGraphics())
            {
                graphics.DrawImage(mazeBitmap, imageStartPoint);
            }
            timerTick++;
            if (timerTick == maze.dimensions[0] * maze.dimensions[0] - 1)
            {
                ((IEnumerator<MazeDelta>)mazeGenerationStepTimer.Tag).Dispose();
                mazeGenerationStepTimer.Tag = null;
                mazeGenerationStepTimer.Stop();
                timerTick = 0;
                // Enable Open Maze
                openMazeFile.Enabled = true;
            }
        }

        private void Dimensions_Click(object sender, EventArgs e)
        {
            DimensionsDialogue dimensionsDialogue = new DimensionsDialogue(((Point)dimensionsLabel.Tag).x, ((Point)dimensionsLabel.Tag).y);
            DialogResult dialogueResult = dimensionsDialogue.ShowDialog();
            // If 'Set Dimensions' was clicked, then set the dimensions.
            if (dialogueResult == DialogResult.OK)
            {
                // Change dimensions label.
                dimensionsLabel.Text = $"Dimensions - ({dimensionsDialogue.x}, {dimensionsDialogue.y})";
                dimensionsLabel.Tag = new Point(dimensionsDialogue.x, dimensionsDialogue.y);
                // Create new blank maze.
                maze = new Maze(dimensionsDialogue.x, dimensionsDialogue.y);
                mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
                //DisplayMazeBitmap(maze, mazeBitmap);
                using (Graphics graphics = CreateGraphics())
                {
                    graphics.DrawImage(mazeBitmap, imageStartPoint);
                }
            }
            // If 'Cancel' was clicked, do nothing
        }

        private void TimeInterval_Click(object sender, EventArgs e)
        {
            TimeIntervalDialogue timeIntervalDialogue = new TimeIntervalDialogue((int)timeIntervalLabel.Tag);
            DialogResult dialogueResult = timeIntervalDialogue.ShowDialog();
            // If 'Set Time Interval' was clicked, set the time interval to whatever was on the track bar.
            if (dialogueResult == DialogResult.OK)
            {
                timeIntervalLabel.Tag = timeIntervalDialogue.timeInterval;
                timeIntervalLabel.Text = $"Interval Between Steps - {timeIntervalDialogue.timeInterval}ms";
                timeIntervalBetweenGenerationSteps = timeIntervalDialogue.timeInterval;
            }
            // If 'Cancel' was clicked, do nothing
        }

        private void instantCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (instantCheckBox.Checked)
            {
                TimeInterval.Available = false;
                timeIntervalLabel.Text = $"Interval Between Steps - None";
                return;
            }
            TimeInterval.Available = true;
            timeIntervalLabel.Text = $"Interval Between Steps - {(int)timeIntervalLabel.Tag}ms";
        }

        private void DisplayMazeBitmap(Maze maze, Bitmap mazeBitmap)
        {
            int pictureBoxWidth = maze.dimensions[0] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels;
            int pictureBoxHeight = maze.dimensions[1] * Consts.pixelsPerDimension + Consts.pictureBoxPaddingPixels;
            mazePictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            mazePictureBox.Image = mazeBitmap;
        }

        private void saveMazeAsCurrentImage_Click(object sender, EventArgs e)
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

        private void saveMazeAsMazeFile_Click(object sender, EventArgs e)
        {
            // Create a Save File Dialogue to help the user save the file.
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.Filter = "Maze File|*.mz;*.jlcmz;*.proto";
            saveFileDialogue.RestoreDirectory = true;
            DialogResult dialogResult = saveFileDialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileEXT = Path.GetExtension(saveFileDialogue.FileName);
                string fileName = Path.ChangeExtension(saveFileDialogue.FileName, null);
                switch (fileEXT)
                {
                    case ".mz":
                    case ".jlcmz":
                    case ".proto":
                        fileName += fileEXT;
                        break;
                    default:
                        fileName += ".mz";
                        break;
                }
                // Create an Protobuf Serializer to serialize the data in the Maze maze obj.
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    Serializer.Serialize(stream, maze);
                }
            }
        }

        private void openMazeFile_Click(object sender, EventArgs e)
        {
            // Create an Open File Dialogue to help the user save the file.
            OpenFileDialog openFileDialogue = new OpenFileDialog();
            openFileDialogue.Filter = "Maze File|*.mz;*.jlcmz;*.proto";
            openFileDialogue.RestoreDirectory = true;

            DialogResult dialogResult = openFileDialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // Create a Proto Serializer to deserialize the data in the Maze maze obj.
                using (FileStream stream = new FileStream(openFileDialogue.FileName, FileMode.Open))
                {
                    maze = Serializer.Deserialize<Maze>(stream);
                }
                // Change button status and dimensions label
                // Change dimensions label.
                dimensionsLabel.Text = $"Dimensions - ({maze.dimensions[0]}, {maze.dimensions[1]})";
                dimensionsLabel.Tag = new Point(maze.dimensions[0], maze.dimensions[1]);
                // Change button enabled/disabled.
                instantCheckBox.Enabled = false;
                Dimensions.Enabled = false;
                TimeInterval.Enabled = false;
                GenerateMaze.Enabled = false;
                ResetMaze.Enabled = true;
                mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
                //DisplayMazeBitmap(maze, mazeBitmap);
                using (Graphics graphics = CreateGraphics())
                {
                    graphics.DrawImage(mazeBitmap, imageStartPoint);
                }
            }
        }
        private void resetMazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mazeGenerationStepTimer.Enabled)
            {
                mazeGenerationStepTimer.Stop();
                timerTick = 0;
            }
            maze = new Maze(maze.dimensions[0], maze.dimensions[1]);
            mazeBitmap = maze.GetMazeBitmap(bgColourBrush);
            //DisplayMazeBitmap(maze, mazeBitmap);
            using (Graphics graphics = CreateGraphics())
            {
                graphics.DrawImage(mazeBitmap, imageStartPoint);
            }
            ResetMaze.Enabled = false;
            instantCheckBox.Enabled = true;
            Dimensions.Enabled = true;
            TimeInterval.Enabled = true;
            GenerateMaze.Enabled = true;
        }

        private void OpenInSolver_Click(object sender, EventArgs e)
        {
            MazeSolverWindow solver = new MazeSolverWindow(maze, mazePictureBox);
            Hide();
            solver.ShowDialog();
            Show();
        }
    }
}
