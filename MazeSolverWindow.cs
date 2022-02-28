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
            // Set up the current window with the maze not yet solved and other information.#
            mazePictureBox.Size = picturebox.Size;
            mazePictureBox.Image = picturebox.Image;
        }
    }
}
