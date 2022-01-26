
namespace MazeDemonstration
{
    partial class MazeGeneratorSolverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Dimensions = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateMaze = new System.Windows.Forms.ToolStripMenuItem();
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dimensions,
            this.GenerateMaze});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // Dimensions
            // 
            this.Dimensions.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Dimensions.Margin = new System.Windows.Forms.Padding(1);
            this.Dimensions.Name = "Dimensions";
            this.Dimensions.Size = new System.Drawing.Size(81, 19);
            this.Dimensions.Text = "Dimensions";
            this.Dimensions.Click += new System.EventHandler(this.Dimensions_Click);
            // 
            // GenerateMaze
            // 
            this.GenerateMaze.BackColor = System.Drawing.SystemColors.MenuBar;
            this.GenerateMaze.Margin = new System.Windows.Forms.Padding(1);
            this.GenerateMaze.Name = "GenerateMaze";
            this.GenerateMaze.Size = new System.Drawing.Size(97, 19);
            this.GenerateMaze.Text = "Generate Maze";
            this.GenerateMaze.Click += new System.EventHandler(this.GenerateMaze_Click);
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Location = new System.Drawing.Point(12, 28);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(100, 50);
            this.mazePictureBox.TabIndex = 1;
            this.mazePictureBox.TabStop = false;
            // 
            // MazeGeneratorSolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mazePictureBox);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MazeGeneratorSolverForm";
            this.Text = "Maze Generator & Solver";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Dimensions;
        private System.Windows.Forms.ToolStripMenuItem GenerateMaze;
        private System.Windows.Forms.PictureBox mazePictureBox;
    }
}

