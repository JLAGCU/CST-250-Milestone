using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace GUI_App
{
    public partial class Difficulty_Form : Form
    {

        private High_Score_Form highScoreForm;

        public Difficulty_Form()
        {
            InitializeComponent();
        }

        private void button_Easy_Click(object sender, EventArgs e)
        {
            // 10x10 board for easy difficulty
            Game_Form gameForm = new Game_Form(10, highScoreForm, "Easy");
            gameForm.Show();
        }

        private void button_Medium_Click(object sender, EventArgs e)
        {
            // 20x20 board for medium difficulty
            Game_Form gameForm = new Game_Form(20, highScoreForm, "Medium");
            gameForm.Show();
        }

        private void button_Hard_Click(object sender, EventArgs e)
        {
            // 30x30 board for easy difficulty
            Game_Form gameForm = new Game_Form(30, highScoreForm, "Hard");
            gameForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 5x5 board for super easy difficulty (demonstrate win condition)
            Game_Form gameForm = new Game_Form(5, highScoreForm, "Super Easy");
            gameForm.Show();
        }

        private void button_HighScores_Click(object sender, EventArgs e)
        {
            // Check if the highScoreForm is null or disposed
            if (highScoreForm == null || highScoreForm.IsDisposed)
            {
                // If the highScoreForm is null or disposed, create a new instance of High_Score_Form
                highScoreForm = new High_Score_Form();
            }

            // Show the highScoreForm
            highScoreForm.Show();
        }
    }
}
