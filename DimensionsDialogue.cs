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
    public partial class DimensionsDialogue : Form
    {
        public int x
        {
            get
            {
                return (int)xDimension.Value;
            }
        }

        public int y
        {
            get
            {
                return (int)yDimension.Value;
            }
        }

        public DimensionsDialogue(int x, int y)
        {
            InitializeComponent();
            yDimension.Value = y;
            xDimension.Value = x;
        }
    }
}
