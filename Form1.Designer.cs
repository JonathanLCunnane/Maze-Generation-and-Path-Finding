
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.openMazeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMaze = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMazeAsCurrentImage = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMazeAsMazeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Dimensions = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateMaze = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetMaze = new System.Windows.Forms.ToolStripMenuItem();
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.currentSettingsPlaceholder = new System.Windows.Forms.Label();
            this.dimensionsLabel = new System.Windows.Forms.Label();
            this.timeIntervalLabel = new System.Windows.Forms.Label();
            this.mazeGenerationStepTimer = new System.Windows.Forms.Timer(this.components);
            this.instantCheckBox = new System.Windows.Forms.CheckBox();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMazeFile,
            this.saveMaze,
            this.Dimensions,
            this.TimeInterval,
            this.GenerateMaze,
            this.ResetMaze});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1206, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // openMazeFile
            // 
            this.openMazeFile.BackColor = System.Drawing.SystemColors.Control;
            this.openMazeFile.Name = "openMazeFile";
            this.openMazeFile.Size = new System.Drawing.Size(100, 21);
            this.openMazeFile.Text = "Open Maze File";
            this.openMazeFile.Click += new System.EventHandler(this.openMazeFile_Click);
            // 
            // saveMaze
            // 
            this.saveMaze.BackColor = System.Drawing.SystemColors.Control;
            this.saveMaze.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMazeAsCurrentImage,
            this.saveMazeAsMazeFile});
            this.saveMaze.Margin = new System.Windows.Forms.Padding(1);
            this.saveMaze.Name = "saveMaze";
            this.saveMaze.Size = new System.Drawing.Size(74, 19);
            this.saveMaze.Text = "Save Maze";
            // 
            // saveMazeAsCurrentImage
            // 
            this.saveMazeAsCurrentImage.Name = "saveMazeAsCurrentImage";
            this.saveMazeAsCurrentImage.Size = new System.Drawing.Size(180, 22);
            this.saveMazeAsCurrentImage.Text = "As Image";
            this.saveMazeAsCurrentImage.Click += new System.EventHandler(this.saveMazeAsCurrentImage_Click);
            // 
            // saveMazeAsMazeFile
            // 
            this.saveMazeAsMazeFile.Name = "saveMazeAsMazeFile";
            this.saveMazeAsMazeFile.Size = new System.Drawing.Size(180, 22);
            this.saveMazeAsMazeFile.Text = "As Maze File";
            this.saveMazeAsMazeFile.Click += new System.EventHandler(this.saveMazeAsMazeFile_Click);
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
            // TimeInterval
            // 
            this.TimeInterval.BackColor = System.Drawing.SystemColors.MenuBar;
            this.TimeInterval.Margin = new System.Windows.Forms.Padding(1);
            this.TimeInterval.Name = "TimeInterval";
            this.TimeInterval.Size = new System.Drawing.Size(87, 19);
            this.TimeInterval.Text = "Time Interval";
            this.TimeInterval.Click += new System.EventHandler(this.TimeInterval_Click);
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
            // ResetMaze
            // 
            this.ResetMaze.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ResetMaze.Enabled = false;
            this.ResetMaze.Margin = new System.Windows.Forms.Padding(1);
            this.ResetMaze.Name = "ResetMaze";
            this.ResetMaze.Size = new System.Drawing.Size(78, 19);
            this.ResetMaze.Text = "Reset Maze";
            this.ResetMaze.Click += new System.EventHandler(this.resetMazeToolStripMenuItem_Click);
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Location = new System.Drawing.Point(12, 53);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(116, 112);
            this.mazePictureBox.TabIndex = 1;
            this.mazePictureBox.TabStop = false;
            // 
            // currentSettingsPlaceholder
            // 
            this.currentSettingsPlaceholder.AutoSize = true;
            this.currentSettingsPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.currentSettingsPlaceholder.Location = new System.Drawing.Point(12, 34);
            this.currentSettingsPlaceholder.Name = "currentSettingsPlaceholder";
            this.currentSettingsPlaceholder.Size = new System.Drawing.Size(106, 16);
            this.currentSettingsPlaceholder.TabIndex = 2;
            this.currentSettingsPlaceholder.Text = "Current Settings: ";
            // 
            // dimensionsLabel
            // 
            this.dimensionsLabel.AutoSize = true;
            this.dimensionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dimensionsLabel.Location = new System.Drawing.Point(125, 34);
            this.dimensionsLabel.Name = "dimensionsLabel";
            this.dimensionsLabel.Size = new System.Drawing.Size(116, 16);
            this.dimensionsLabel.TabIndex = 3;
            this.dimensionsLabel.Text = "Dimensions - (3, 3)";
            // 
            // timeIntervalLabel
            // 
            this.timeIntervalLabel.AutoSize = true;
            this.timeIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.timeIntervalLabel.Location = new System.Drawing.Point(327, 34);
            this.timeIntervalLabel.Name = "timeIntervalLabel";
            this.timeIntervalLabel.Size = new System.Drawing.Size(185, 16);
            this.timeIntervalLabel.TabIndex = 4;
            this.timeIntervalLabel.Text = "Interval Between Steps - 25ms";
            // 
            // mazeGenerationStepTimer
            // 
            this.mazeGenerationStepTimer.Interval = 250;
            this.mazeGenerationStepTimer.Tick += new System.EventHandler(this.mazeGenerationStepTimer_Tick);
            // 
            // instantCheckBox
            // 
            this.instantCheckBox.AutoSize = true;
            this.instantCheckBox.Location = new System.Drawing.Point(528, 35);
            this.instantCheckBox.Name = "instantCheckBox";
            this.instantCheckBox.Size = new System.Drawing.Size(78, 17);
            this.instantCheckBox.TabIndex = 5;
            this.instantCheckBox.Text = "No Interval";
            this.instantCheckBox.UseVisualStyleBackColor = true;
            this.instantCheckBox.CheckedChanged += new System.EventHandler(this.instantCheckBox_CheckedChanged);
            // 
            // MazeGeneratorSolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1206, 598);
            this.Controls.Add(this.instantCheckBox);
            this.Controls.Add(this.timeIntervalLabel);
            this.Controls.Add(this.dimensionsLabel);
            this.Controls.Add(this.currentSettingsPlaceholder);
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
        private System.Windows.Forms.Label currentSettingsPlaceholder;
        private System.Windows.Forms.Label dimensionsLabel;
        private System.Windows.Forms.Label timeIntervalLabel;
        private System.Windows.Forms.ToolStripMenuItem TimeInterval;
        private System.Windows.Forms.Timer mazeGenerationStepTimer;
        private System.Windows.Forms.ToolStripMenuItem saveMaze;
        private System.Windows.Forms.CheckBox instantCheckBox;
        private System.Windows.Forms.ToolStripMenuItem ResetMaze;
        private System.Windows.Forms.ToolStripMenuItem saveMazeAsCurrentImage;
        private System.Windows.Forms.ToolStripMenuItem saveMazeAsMazeFile;
        private System.Windows.Forms.ToolStripMenuItem openMazeFile;
    }
}

