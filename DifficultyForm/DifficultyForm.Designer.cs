namespace DifficultyForm
{
    partial class DifficultyForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_PlayGame = new System.Windows.Forms.Button();
            this.radioButton_Difficult = new System.Windows.Forms.RadioButton();
            this.radioButton_Easy = new System.Windows.Forms.RadioButton();
            this.radioButton_Moderate = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_PlayGame);
            this.groupBox1.Controls.Add(this.radioButton_Difficult);
            this.groupBox1.Controls.Add(this.radioButton_Easy);
            this.groupBox1.Controls.Add(this.radioButton_Moderate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Level";
            // 
            // button_PlayGame
            // 
            this.button_PlayGame.Location = new System.Drawing.Point(119, 71);
            this.button_PlayGame.Name = "button_PlayGame";
            this.button_PlayGame.Size = new System.Drawing.Size(75, 23);
            this.button_PlayGame.TabIndex = 1;
            this.button_PlayGame.Text = "Play Game";
            this.button_PlayGame.UseVisualStyleBackColor = true;
            this.button_PlayGame.Click += new System.EventHandler(this.button_PlayGame_Click);
            // 
            // radioButton_Difficult
            // 
            this.radioButton_Difficult.AutoSize = true;
            this.radioButton_Difficult.Location = new System.Drawing.Point(6, 65);
            this.radioButton_Difficult.Name = "radioButton_Difficult";
            this.radioButton_Difficult.Size = new System.Drawing.Size(60, 17);
            this.radioButton_Difficult.TabIndex = 3;
            this.radioButton_Difficult.TabStop = true;
            this.radioButton_Difficult.Text = "Difficult";
            this.radioButton_Difficult.UseVisualStyleBackColor = true;
            // 
            // radioButton_Easy
            // 
            this.radioButton_Easy.AutoSize = true;
            this.radioButton_Easy.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Easy.Name = "radioButton_Easy";
            this.radioButton_Easy.Size = new System.Drawing.Size(48, 17);
            this.radioButton_Easy.TabIndex = 1;
            this.radioButton_Easy.TabStop = true;
            this.radioButton_Easy.Text = "Easy";
            this.radioButton_Easy.UseVisualStyleBackColor = true;
            // 
            // radioButton_Moderate
            // 
            this.radioButton_Moderate.AutoSize = true;
            this.radioButton_Moderate.Location = new System.Drawing.Point(6, 42);
            this.radioButton_Moderate.Name = "radioButton_Moderate";
            this.radioButton_Moderate.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Moderate.TabIndex = 2;
            this.radioButton_Moderate.TabStop = true;
            this.radioButton_Moderate.Text = "Moderate";
            this.radioButton_Moderate.UseVisualStyleBackColor = true;
            // 
            // DifficultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 125);
            this.Controls.Add(this.groupBox1);
            this.Name = "DifficultyForm";
            this.Text = "DifficultyForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Easy;
        private System.Windows.Forms.RadioButton radioButton_Moderate;
        private System.Windows.Forms.RadioButton radioButton_Difficult;
        private System.Windows.Forms.Button button_PlayGame;
    }
}

