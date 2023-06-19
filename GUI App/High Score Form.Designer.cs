namespace GUI_App
{
    partial class High_Score_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(High_Score_Form));
            listBox_HighScores = new ListBox();
            SuspendLayout();
            // 
            // listBox_HighScores
            // 
            listBox_HighScores.Font = new Font("Industry-Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBox_HighScores.FormattingEnabled = true;
            listBox_HighScores.ItemHeight = 21;
            listBox_HighScores.Location = new Point(12, 12);
            listBox_HighScores.Name = "listBox_HighScores";
            listBox_HighScores.Size = new Size(300, 424);
            listBox_HighScores.TabIndex = 0;
            // 
            // High_Score_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 449);
            Controls.Add(listBox_HighScores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "High_Score_Form";
            Text = "High Scores";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox_HighScores;
    }
}