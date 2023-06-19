namespace GUI_App
{
    partial class Difficulty_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Difficulty_Form));
            button_Easy = new Button();
            button_Medium = new Button();
            button_Hard = new Button();
            label1 = new Label();
            button1 = new Button();
            button_HighScores = new Button();
            SuspendLayout();
            // 
            // button_Easy
            // 
            button_Easy.BackColor = Color.FromArgb(192, 255, 192);
            button_Easy.Font = new Font("Industry-Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_Easy.Location = new Point(12, 44);
            button_Easy.Name = "button_Easy";
            button_Easy.Size = new Size(300, 50);
            button_Easy.TabIndex = 0;
            button_Easy.Text = "Easy";
            button_Easy.UseVisualStyleBackColor = false;
            button_Easy.Click += button_Easy_Click;
            // 
            // button_Medium
            // 
            button_Medium.BackColor = Color.FromArgb(255, 255, 192);
            button_Medium.Font = new Font("Industry-Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_Medium.Location = new Point(12, 100);
            button_Medium.Name = "button_Medium";
            button_Medium.Size = new Size(300, 50);
            button_Medium.TabIndex = 1;
            button_Medium.Text = "Medium";
            button_Medium.UseVisualStyleBackColor = false;
            button_Medium.Click += button_Medium_Click;
            // 
            // button_Hard
            // 
            button_Hard.BackColor = Color.FromArgb(255, 192, 192);
            button_Hard.Font = new Font("Industry-Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_Hard.Location = new Point(12, 156);
            button_Hard.Name = "button_Hard";
            button_Hard.Size = new Size(300, 50);
            button_Hard.TabIndex = 2;
            button_Hard.Text = "Hard";
            button_Hard.UseVisualStyleBackColor = false;
            button_Hard.Click += button_Hard_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Industry-Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 9);
            label1.Name = "label1";
            label1.Size = new Size(279, 32);
            label1.TabIndex = 3;
            label1.Text = "Select A Difficulty Level";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Industry-Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 212);
            button1.Name = "button1";
            button1.Size = new Size(300, 50);
            button1.TabIndex = 4;
            button1.Text = "SUPER EASY (demo)";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button_HighScores
            // 
            button_HighScores.BackColor = Color.Gold;
            button_HighScores.Font = new Font("Industry-Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_HighScores.Location = new Point(174, 268);
            button_HighScores.Name = "button_HighScores";
            button_HighScores.Size = new Size(138, 50);
            button_HighScores.TabIndex = 5;
            button_HighScores.Text = "High Scores";
            button_HighScores.UseVisualStyleBackColor = false;
            button_HighScores.Click += button_HighScores_Click;
            // 
            // Difficulty_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 331);
            Controls.Add(button_HighScores);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(button_Hard);
            Controls.Add(button_Medium);
            Controls.Add(button_Easy);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Difficulty_Form";
            Text = "MineSweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Easy;
        private Button button_Medium;
        private Button button_Hard;
        private Label label1;
        private Button button1;
        private Button button_HighScores;
    }
}