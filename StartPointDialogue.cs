﻿using System;
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
    public partial class StartPointDialogue : Form
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
        public StartPointDialogue(int x, int y, Point max)
        {
            InitializeComponent();
            xDimension.Value = x;
            yDimension.Value = y;
            xDimension.Maximum = max.x;
            yDimension.Maximum = max.y;
        }
    }
}
