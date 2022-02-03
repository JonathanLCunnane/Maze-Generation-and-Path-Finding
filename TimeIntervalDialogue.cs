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
    public partial class TimeIntervalDialogue : Form
    {
        public int timeInterval
        {
            get
            {
                return (int)timeIntervalNumericUpDown.Value;
            }
        }
        public TimeIntervalDialogue(int interval)
        {
            InitializeComponent();
            timeIntervalNumericUpDown.Value = interval;
        }
    }
}
