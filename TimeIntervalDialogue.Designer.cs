
namespace MazeDemonstration
{
    partial class TimeIntervalDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeIntervalDialogue));
            this.cancelDimensionsButton = new System.Windows.Forms.Button();
            this.setTimeIntervalButton = new System.Windows.Forms.Button();
            this.setTimeIntervalLabel = new System.Windows.Forms.Label();
            this.timeIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.timeIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelDimensionsButton
            // 
            this.cancelDimensionsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelDimensionsButton.Location = new System.Drawing.Point(135, 70);
            this.cancelDimensionsButton.Name = "cancelDimensionsButton";
            this.cancelDimensionsButton.Size = new System.Drawing.Size(100, 30);
            this.cancelDimensionsButton.TabIndex = 7;
            this.cancelDimensionsButton.Text = "Cancel";
            this.cancelDimensionsButton.UseVisualStyleBackColor = true;
            // 
            // setTimeIntervalButton
            // 
            this.setTimeIntervalButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.setTimeIntervalButton.Location = new System.Drawing.Point(29, 70);
            this.setTimeIntervalButton.Name = "setTimeIntervalButton";
            this.setTimeIntervalButton.Size = new System.Drawing.Size(100, 30);
            this.setTimeIntervalButton.TabIndex = 6;
            this.setTimeIntervalButton.Text = "Set Time Interval";
            this.setTimeIntervalButton.UseVisualStyleBackColor = true;
            // 
            // setTimeIntervalLabel
            // 
            this.setTimeIntervalLabel.AutoSize = true;
            this.setTimeIntervalLabel.Location = new System.Drawing.Point(40, 9);
            this.setTimeIntervalLabel.Name = "setTimeIntervalLabel";
            this.setTimeIntervalLabel.Size = new System.Drawing.Size(195, 13);
            this.setTimeIntervalLabel.TabIndex = 9;
            this.setTimeIntervalLabel.Text = "Set Time Interval Below (10 - 1000 ms): ";
            // 
            // timeIntervalNumericUpDown
            // 
            this.timeIntervalNumericUpDown.Location = new System.Drawing.Point(89, 40);
            this.timeIntervalNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timeIntervalNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeIntervalNumericUpDown.Name = "timeIntervalNumericUpDown";
            this.timeIntervalNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.timeIntervalNumericUpDown.TabIndex = 10;
            this.timeIntervalNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // TimeIntervalDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 112);
            this.Controls.Add(this.timeIntervalNumericUpDown);
            this.Controls.Add(this.setTimeIntervalLabel);
            this.Controls.Add(this.cancelDimensionsButton);
            this.Controls.Add(this.setTimeIntervalButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeIntervalDialogue";
            this.Text = "Time Interval Dialogue";
            ((System.ComponentModel.ISupportInitialize)(this.timeIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelDimensionsButton;
        private System.Windows.Forms.Button setTimeIntervalButton;
        private System.Windows.Forms.Label setTimeIntervalLabel;
        private System.Windows.Forms.NumericUpDown timeIntervalNumericUpDown;
    }
}