
namespace MazeDemonstration
{
    partial class DimensionsDialogue
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
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.setDimensionsButton = new System.Windows.Forms.Button();
            this.xDimension = new System.Windows.Forms.NumericUpDown();
            this.yDimension = new System.Windows.Forms.NumericUpDown();
            this.cancelDimensionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xDimension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yDimension)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(73, 12);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(21, 13);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "x : ";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(73, 47);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(21, 13);
            this.yLabel.TabIndex = 1;
            this.yLabel.Text = "y : ";
            // 
            // setDimensionsButton
            // 
            this.setDimensionsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.setDimensionsButton.Location = new System.Drawing.Point(33, 77);
            this.setDimensionsButton.Name = "setDimensionsButton";
            this.setDimensionsButton.Size = new System.Drawing.Size(100, 30);
            this.setDimensionsButton.TabIndex = 2;
            this.setDimensionsButton.Text = "Set Dimensions";
            this.setDimensionsButton.UseVisualStyleBackColor = true;
            // 
            // xDimension
            // 
            this.xDimension.Location = new System.Drawing.Point(100, 12);
            this.xDimension.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.xDimension.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.xDimension.Name = "xDimension";
            this.xDimension.Size = new System.Drawing.Size(83, 20);
            this.xDimension.TabIndex = 3;
            this.xDimension.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // yDimension
            // 
            this.yDimension.Location = new System.Drawing.Point(100, 47);
            this.yDimension.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.yDimension.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.yDimension.Name = "yDimension";
            this.yDimension.Size = new System.Drawing.Size(83, 20);
            this.yDimension.TabIndex = 4;
            this.yDimension.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // cancelDimensionsButton
            // 
            this.cancelDimensionsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelDimensionsButton.Location = new System.Drawing.Point(139, 77);
            this.cancelDimensionsButton.Name = "cancelDimensionsButton";
            this.cancelDimensionsButton.Size = new System.Drawing.Size(100, 30);
            this.cancelDimensionsButton.TabIndex = 5;
            this.cancelDimensionsButton.Text = "Cancel";
            this.cancelDimensionsButton.UseVisualStyleBackColor = true;
            // 
            // DimensionsDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 124);
            this.Controls.Add(this.cancelDimensionsButton);
            this.Controls.Add(this.yDimension);
            this.Controls.Add(this.xDimension);
            this.Controls.Add(this.setDimensionsButton);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DimensionsDialogue";
            this.Text = "Enter Dimensions";
            ((System.ComponentModel.ISupportInitialize)(this.xDimension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yDimension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Button setDimensionsButton;
        private System.Windows.Forms.NumericUpDown xDimension;
        private System.Windows.Forms.NumericUpDown yDimension;
        private System.Windows.Forms.Button cancelDimensionsButton;
    }
}