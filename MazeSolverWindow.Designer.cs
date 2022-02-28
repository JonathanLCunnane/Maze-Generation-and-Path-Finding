﻿
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
            // 
            // timeIntervalLabel
            // 
            this.timeIntervalLabel.AutoSize = true;
            this.timeIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.timeIntervalLabel.Location = new System.Drawing.Point(126, 60);
            this.timeIntervalLabel.Name = "timeIntervalLabel";
            this.timeIntervalLabel.Size = new System.Drawing.Size(185, 16);
            this.timeIntervalLabel.TabIndex = 9;
            this.timeIntervalLabel.Text = "Interval Between Steps - 25ms";
            // 
            // dimensionsLabel
            // 
            this.dimensionsLabel.AutoSize = true;
            this.dimensionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dimensionsLabel.Location = new System.Drawing.Point(126, 33);
            this.dimensionsLabel.Name = "dimensionsLabel";
            this.dimensionsLabel.Size = new System.Drawing.Size(99, 16);
            this.dimensionsLabel.TabIndex = 8;
            this.dimensionsLabel.Text = "Dimensions - (,)";
            // 
            // currentSettingsPlaceholder
            // 
            this.currentSettingsPlaceholder.AutoSize = true;
            this.currentSettingsPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.currentSettingsPlaceholder.Location = new System.Drawing.Point(13, 33);
            this.currentSettingsPlaceholder.Name = "currentSettingsPlaceholder";
            this.currentSettingsPlaceholder.Size = new System.Drawing.Size(106, 16);
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
            this.startPointLabel.Size = new System.Drawing.Size(55, 16);
            this.startPointLabel.TabIndex = 11;
            this.startPointLabel.Text = "Start - (,)";
            // 
            // finishPointLabel
            // 
            this.finishPointLabel.AutoSize = true;
            this.finishPointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.finishPointLabel.Location = new System.Drawing.Point(534, 34);
            this.finishPointLabel.Name = "finishPointLabel";
            this.finishPointLabel.Size = new System.Drawing.Size(63, 16);
            this.finishPointLabel.TabIndex = 12;
            this.finishPointLabel.Text = "Finish - (,)";
            // 
            // algorithmTypeLabel
            // 
            this.algorithmTypeLabel.AutoSize = true;
            this.algorithmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.algorithmTypeLabel.Location = new System.Drawing.Point(534, 62);
            this.algorithmTypeLabel.Name = "algorithmTypeLabel";
            this.algorithmTypeLabel.Size = new System.Drawing.Size(191, 16);
            this.algorithmTypeLabel.TabIndex = 13;
            this.algorithmTypeLabel.Text = "Pathfinding Algorithm Type - A*";
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitSolver});
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
            // 
            // MazeSolverWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}