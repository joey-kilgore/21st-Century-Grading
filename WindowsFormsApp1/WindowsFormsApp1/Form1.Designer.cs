namespace WindowsFormsApp1
{
    partial class Form1
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.StudentTestLabel = new System.Windows.Forms.Label();
            this.StudentTestTextBox = new System.Windows.Forms.TextBox();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.KeySubmitButton = new System.Windows.Forms.Button();
            this.StudentTestsSubmitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(544, 96);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(300, 58);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Test Grader";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyLabel.Location = new System.Drawing.Point(146, 320);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(469, 43);
            this.KeyLabel.TabIndex = 1;
            this.KeyLabel.Text = "Input path to test key file";
            // 
            // StudentTestLabel
            // 
            this.StudentTestLabel.AutoSize = true;
            this.StudentTestLabel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentTestLabel.Location = new System.Drawing.Point(146, 620);
            this.StudentTestLabel.Name = "StudentTestLabel";
            this.StudentTestLabel.Size = new System.Drawing.Size(564, 43);
            this.StudentTestLabel.TabIndex = 2;
            this.StudentTestLabel.Text = "Input path to student tests file";
            // 
            // StudentTestTextBox
            // 
            this.StudentTestTextBox.Location = new System.Drawing.Point(177, 709);
            this.StudentTestTextBox.Name = "StudentTestTextBox";
            this.StudentTestTextBox.Size = new System.Drawing.Size(681, 44);
            this.StudentTestTextBox.TabIndex = 3;
            this.StudentTestTextBox.TextChanged += new System.EventHandler(this.StudentTestTextBox_TextChanged);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(177, 396);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(681, 44);
            this.KeyTextBox.TabIndex = 4;
            this.KeyTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // KeySubmitButton
            // 
            this.KeySubmitButton.Font = new System.Drawing.Font("Bookman Old Style", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeySubmitButton.Location = new System.Drawing.Point(969, 385);
            this.KeySubmitButton.Name = "KeySubmitButton";
            this.KeySubmitButton.Size = new System.Drawing.Size(204, 65);
            this.KeySubmitButton.TabIndex = 5;
            this.KeySubmitButton.Text = "Submit";
            this.KeySubmitButton.UseVisualStyleBackColor = true;
            // 
            // StudentTestsSubmitButton
            // 
            this.StudentTestsSubmitButton.Font = new System.Drawing.Font("Bookman Old Style", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentTestsSubmitButton.Location = new System.Drawing.Point(969, 698);
            this.StudentTestsSubmitButton.Name = "StudentTestsSubmitButton";
            this.StudentTestsSubmitButton.Size = new System.Drawing.Size(204, 65);
            this.StudentTestsSubmitButton.TabIndex = 6;
            this.StudentTestsSubmitButton.Text = "Submit";
            this.StudentTestsSubmitButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1444, 1042);
            this.Controls.Add(this.StudentTestsSubmitButton);
            this.Controls.Add(this.KeySubmitButton);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.StudentTestTextBox);
            this.Controls.Add(this.StudentTestLabel);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Label StudentTestLabel;
        private System.Windows.Forms.TextBox StudentTestTextBox;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Button KeySubmitButton;
        private System.Windows.Forms.Button StudentTestsSubmitButton;
    }
}

