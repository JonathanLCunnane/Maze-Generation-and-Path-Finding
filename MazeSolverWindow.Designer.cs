
namespace MazeDemonstration
{
    partial class MazeSolverWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazeSolverWindow));
            this.instantCheckBox = new System.Windows.Forms.CheckBox();
            this.timeIntervalLabel = new System.Windows.Forms.Label();
            this.dimensionsLabel = new System.Windows.Forms.Label();
            this.currentSettingsPlaceholder = new System.Windows.Forms.Label();
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.startPointLabel = new System.Windows.Forms.Label();
            this.finishPointLabel = new System.Windows.Forms.Label();
            this.algorithmTypeLabel = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.exitSolver = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.setStart = new System.Windows.Forms.ToolStripMenuItem();
            this.setFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathfindingAlgorithmType = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathfindingAlgorithmAStar = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathfindingAlgorithmBFS = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathfindingAlgorithmDijkstra = new System.Windows.Forms.ToolStripMenuItem();
            this.setPathfindingAlgorithmDFS = new System.Windows.Forms.ToolStripMenuItem();
            this.timeInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.startSolver = new System.Windows.Forms.ToolStripMenuItem();
            this.mazeSolvingStepTimer = new System.Windows.Forms.Timer(this.components);
            this.restartSolving = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // instantCheckBox
            // 
            this.instantCheckBox.AutoSize = true;
            this.instantCheckBox.Location = new System.Drawing.Point(339, 61);
            this.instantCheckBox.Name = "instantCheckBox";
            this.instantCheckBox.Size = new System.Drawing.Size(78, 17);
            this.instantCheckBox.TabIndex = 10;
            this.instantCheckBox.Text = "No Interval";
            this.instantCheckBox.UseVisualStyleBackColor = true;
            this.instantCheckBox.CheckedChanged += new System.EventHandler(this.instantCheckBox_CheckedChanged);
            // 
            // timeIntervalLabel
            // 
            this.timeIntervalLabel.AutoSize = true;
            this.timeIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.timeIntervalLabel.Location = new System.Drawing.Point(126, 60);
            this.timeIntervalLabel.Name = "timeIntervalLabel";
            this.timeIntervalLabel.Size = new System.Drawing.Size(186, 16);
            this.timeIntervalLabel.TabIndex = 9;
            this.timeIntervalLabel.Text = "Interval Between Steps - 25ms";
            // 
            // dimensionsLabel
            // 
            this.dimensionsLabel.AutoSize = true;
            this.dimensionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dimensionsLabel.Location = new System.Drawing.Point(126, 33);
            this.dimensionsLabel.Name = "dimensionsLabel";
            this.dimensionsLabel.Size = new System.Drawing.Size(116, 16);
            this.dimensionsLabel.TabIndex = 8;
            this.dimensionsLabel.Text = "Dimensions - (x, y)";
            // 
            // currentSettingsPlaceholder
            // 
            this.currentSettingsPlaceholder.AutoSize = true;
            this.currentSettingsPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.currentSettingsPlaceholder.Location = new System.Drawing.Point(13, 33);
            this.currentSettingsPlaceholder.Name = "currentSettingsPlaceholder";
            this.currentSettingsPlaceholder.Size = new System.Drawing.Size(107, 16);
            this.currentSettingsPlaceholder.TabIndex = 7;
            this.currentSettingsPlaceholder.Text = "Current Settings: ";
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Location = new System.Drawing.Point(16, 91);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(116, 112);
            this.mazePictureBox.TabIndex = 6;
            this.mazePictureBox.TabStop = false;
            // 
            // startPointLabel
            // 
            this.startPointLabel.AutoSize = true;
            this.startPointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.startPointLabel.Location = new System.Drawing.Point(336, 33);
            this.startPointLabel.Name = "startPointLabel";
            this.startPointLabel.Size = new System.Drawing.Size(73, 16);
            this.startPointLabel.TabIndex = 11;
            this.startPointLabel.Text = "Start - (0, 0)";
            // 
            // finishPointLabel
            // 
            this.finishPointLabel.AutoSize = true;
            this.finishPointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.finishPointLabel.Location = new System.Drawing.Point(534, 34);
            this.finishPointLabel.Name = "finishPointLabel";
            this.finishPointLabel.Size = new System.Drawing.Size(83, 16);
            this.finishPointLabel.TabIndex = 12;
            this.finishPointLabel.Text = "Finish - (a, b)";
            // 
            // algorithmTypeLabel
            // 
            this.algorithmTypeLabel.AutoSize = true;
            this.algorithmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.algorithmTypeLabel.Location = new System.Drawing.Point(534, 62);
            this.algorithmTypeLabel.Name = "algorithmTypeLabel";
            this.algorithmTypeLabel.Size = new System.Drawing.Size(192, 16);
            this.algorithmTypeLabel.TabIndex = 13;
            this.algorithmTypeLabel.Text = "Pathfinding Algorithm Type - A*";
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitSolver,
            this.saveImage,
            this.setStart,
            this.setFinish,
            this.setPathfindingAlgorithmType,
            this.timeInterval,
            this.startSolver,
            this.restartSolving});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1184, 25);
            this.MainMenu.TabIndex = 14;
            this.MainMenu.Text = "menuStrip1";
            // 
            // exitSolver
            // 
            this.exitSolver.BackColor = System.Drawing.SystemColors.Control;
            this.exitSolver.Margin = new System.Windows.Forms.Padding(1);
            this.exitSolver.Name = "exitSolver";
            this.exitSolver.Size = new System.Drawing.Size(73, 19);
            this.exitSolver.Text = "Exit Solver";
            this.exitSolver.Click += new System.EventHandler(this.exitSolver_Click);
            // 
            // saveImage
            // 
            this.saveImage.BackColor = System.Drawing.SystemColors.Control;
            this.saveImage.Margin = new System.Windows.Forms.Padding(1);
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(79, 19);
            this.saveImage.Text = "Save Image";
            this.saveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // setStart
            // 
            this.setStart.BackColor = System.Drawing.SystemColors.MenuBar;
            this.setStart.Margin = new System.Windows.Forms.Padding(1);
            this.setStart.Name = "setStart";
            this.setStart.Size = new System.Drawing.Size(62, 19);
            this.setStart.Text = "Set Start";
            this.setStart.Click += new System.EventHandler(this.setStart_Click);
            // 
            // setFinish
            // 
            this.setFinish.BackColor = System.Drawing.SystemColors.MenuBar;
            this.setFinish.Margin = new System.Windows.Forms.Padding(1);
            this.setFinish.Name = "setFinish";
            this.setFinish.Size = new System.Drawing.Size(69, 19);
            this.setFinish.Text = "Set Finish";
            this.setFinish.Click += new System.EventHandler(this.setFinish_Click);
            // 
            // setPathfindingAlgorithmType
            // 
            this.setPathfindingAlgorithmType.BackColor = System.Drawing.SystemColors.Control;
            this.setPathfindingAlgorithmType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPathfindingAlgorithmAStar,
            this.setPathfindingAlgorithmBFS,
            this.setPathfindingAlgorithmDijkstra,
            this.setPathfindingAlgorithmDFS});
            this.setPathfindingAlgorithmType.Margin = new System.Windows.Forms.Padding(1);
            this.setPathfindingAlgorithmType.Name = "setPathfindingAlgorithmType";
            this.setPathfindingAlgorithmType.Size = new System.Drawing.Size(165, 19);
            this.setPathfindingAlgorithmType.Text = "Pathfinding Algorithm Type";
            // 
            // setPathfindingAlgorithmAStar
            // 
            this.setPathfindingAlgorithmAStar.Name = "setPathfindingAlgorithmAStar";
            this.setPathfindingAlgorithmAStar.Size = new System.Drawing.Size(331, 22);
            this.setPathfindingAlgorithmAStar.Text = "A*";
            this.setPathfindingAlgorithmAStar.Click += new System.EventHandler(this.setPathfindingAlgorithmAStar_Click);
            // 
            // setPathfindingAlgorithmBFS
            // 
            this.setPathfindingAlgorithmBFS.Name = "setPathfindingAlgorithmBFS";
            this.setPathfindingAlgorithmBFS.Size = new System.Drawing.Size(331, 22);
            this.setPathfindingAlgorithmBFS.Text = "BFS";
            this.setPathfindingAlgorithmBFS.Click += new System.EventHandler(this.setPathfindingAlgorithmBFS_Click);
            // 
            // setPathfindingAlgorithmDijkstra
            // 
            this.setPathfindingAlgorithmDijkstra.Name = "setPathfindingAlgorithmDijkstra";
            this.setPathfindingAlgorithmDijkstra.Size = new System.Drawing.Size(331, 22);
            this.setPathfindingAlgorithmDijkstra.Text = "Dijkstra (Same as BFS as the maze is unweighted)";
            this.setPathfindingAlgorithmDijkstra.Click += new System.EventHandler(this.setPathfindingAlgorithmDijkstra_Click);
            // 
            // setPathfindingAlgorithmDFS
            // 
            this.setPathfindingAlgorithmDFS.Name = "setPathfindingAlgorithmDFS";
            this.setPathfindingAlgorithmDFS.Size = new System.Drawing.Size(331, 22);
            this.setPathfindingAlgorithmDFS.Text = "DFS";
            this.setPathfindingAlgorithmDFS.Click += new System.EventHandler(this.setPathfindingAlgorithmDFS_Click);
            // 
            // timeInterval
            // 
            this.timeInterval.BackColor = System.Drawing.SystemColors.MenuBar;
            this.timeInterval.Margin = new System.Windows.Forms.Padding(1);
            this.timeInterval.Name = "timeInterval";
            this.timeInterval.Size = new System.Drawing.Size(87, 19);
            this.timeInterval.Text = "Time Interval";
            this.timeInterval.Click += new System.EventHandler(this.timeInterval_Click);
            // 
            // startSolver
            // 
            this.startSolver.BackColor = System.Drawing.SystemColors.Control;
            this.startSolver.Margin = new System.Windows.Forms.Padding(1);
            this.startSolver.Name = "startSolver";
            this.startSolver.Size = new System.Drawing.Size(78, 19);
            this.startSolver.Text = "Start Solver";
            this.startSolver.Click += new System.EventHandler(this.startSolver_Click);
            // 
            // mazeSolvingStepTimer
            // 
            this.mazeSolvingStepTimer.Interval = 25;
            this.mazeSolvingStepTimer.Tick += new System.EventHandler(this.mazeSolvingStepTimer_Tick);
            // 
            // restartSolving
            // 
            this.restartSolving.Enabled = false;
            this.restartSolving.Margin = new System.Windows.Forms.Padding(1);
            this.restartSolving.Name = "restartSolving";
            this.restartSolving.Size = new System.Drawing.Size(97, 19);
            this.restartSolving.Text = "Restart Solving";
            this.restartSolving.Click += new System.EventHandler(this.restartSolving_Click);
            // 
            // MazeSolverWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.algorithmTypeLabel);
            this.Controls.Add(this.finishPointLabel);
            this.Controls.Add(this.startPointLabel);
            this.Controls.Add(this.instantCheckBox);
            this.Controls.Add(this.timeIntervalLabel);
            this.Controls.Add(this.dimensionsLabel);
            this.Controls.Add(this.currentSettingsPlaceholder);
            this.Controls.Add(this.mazePictureBox);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MazeSolverWindow";
            this.Text = "Maze Solver Window";
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox instantCheckBox;
        private System.Windows.Forms.Label timeIntervalLabel;
        private System.Windows.Forms.Label dimensionsLabel;
        private System.Windows.Forms.Label currentSettingsPlaceholder;
        private System.Windows.Forms.PictureBox mazePictureBox;
        private System.Windows.Forms.Label startPointLabel;
        private System.Windows.Forms.Label finishPointLabel;
        private System.Windows.Forms.Label algorithmTypeLabel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem exitSolver;
        private System.Windows.Forms.ToolStripMenuItem setStart;
        private System.Windows.Forms.ToolStripMenuItem setFinish;
        private System.Windows.Forms.ToolStripMenuItem setPathfindingAlgorithmType;
        private System.Windows.Forms.ToolStripMenuItem setPathfindingAlgorithmAStar;
        private System.Windows.Forms.ToolStripMenuItem setPathfindingAlgorithmBFS;
        private System.Windows.Forms.ToolStripMenuItem setPathfindingAlgorithmDijkstra;
        private System.Windows.Forms.ToolStripMenuItem setPathfindingAlgorithmDFS;
        private System.Windows.Forms.ToolStripMenuItem startSolver;
        private System.Windows.Forms.ToolStripMenuItem timeInterval;
        private System.Windows.Forms.Timer mazeSolvingStepTimer;
        private System.Windows.Forms.ToolStripMenuItem saveImage;
        private System.Windows.Forms.ToolStripMenuItem restartSolving;
    }
}