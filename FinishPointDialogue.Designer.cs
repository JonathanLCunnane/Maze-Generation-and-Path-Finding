
namespace MazeDemonstration
{
    partial class FinishPointDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishPointDialogue));
            this.cancelPointButton = new System.Windows.Forms.Button();
            this.yDimension = new System.Windows.Forms.NumericUpDown();
            this.xDimension = new System.Windows.Forms.NumericUpDown();
            this.setFinishPointButton = new System.Windows.Forms.Button();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yDimension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDimension)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelPointButton
            // 
            this.cancelPointButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelPointButton.Location = new System.Drawing.Point(134, 77);
            this.cancelPointButton.Name = "cancelPointButton";
            this.cancelPointButton.Size = new System.Drawing.Size(100, 30);
            this.cancelPointButton.TabIndex = 11;
            this.cancelPointButton.Text = "Cancel";
            this.cancelPointButton.UseVisualStyleBackColor = true;
            // 
            // yDimension
            // 
            this.yDimension.Location = new System.Drawing.Point(95, 47);
            this.yDimension.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.yDimension.Name = "yDimension";
            this.yDimension.Size = new System.Drawing.Size(83, 20);
            this.yDimension.TabIndex = 10;
            // 
            // xDimension
            // 
            this.xDimension.Location = new System.Drawing.Point(95, 12);
            this.xDimension.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.xDimension.Name = "xDimension";
            this.xDimension.Size = new System.Drawing.Size(83, 20);
            this.xDimension.TabIndex = 9;
            // 
            // setFinishPointButton
            // 
            this.setFinishPointButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.setFinishPointButton.Location = new System.Drawing.Point(28, 77);
            this.setFinishPointButton.Name = "setFinishPointButton";
            this.setFinishPointButton.Size = new System.Drawing.Size(100, 30);
            this.setFinishPointButton.TabIndex = 8;
            this.setFinishPointButton.Text = "Set Finish Point";
            this.setFinishPointButton.UseVisualStyleBackColor = true;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(68, 47);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(21, 13);
            this.yLabel.TabIndex = 7;
            this.yLabel.Text = "y : ";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(68, 12);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(21, 13);
            this.xLabel.TabIndex = 6;
            this.xLabel.Text = "x : ";
            // 
            // FinishPointDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 121);
            this.Controls.Add(this.cancelPointButton);
            this.Controls.Add(this.yDimension);
            this.Controls.Add(this.xDimension);
            this.Controls.Add(this.setFinishPointButton);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FinishPointDialogue";
            this.Text = "Enter Finish Point";
            ((System.ComponentModel.ISupportInitialize)(this.yDimension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDimension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelPointButton;
        private System.Windows.Forms.NumericUpDown yDimension;
        private System.Windows.Forms.NumericUpDown xDimension;
        private System.Windows.Forms.Button setFinishPointButton;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
    }
}