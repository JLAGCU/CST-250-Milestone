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
        public Difficulty_Form()
        {
            InitializeComponent();
        }

        private void button_Easy_Click(object sender, EventArgs e)
        {
            Game_Form gameForm = new Game_Form(10); // 10x10 board for easy difficulty
            gameForm.Show();
        }

        private void button_Medium_Click(object sender, EventArgs e)
        {
            Game_Form gameForm = new Game_Form(20); // 20x20 board for medium difficulty
            gameForm.Show();
        }

        private void button_Hard_Click(object sender, EventArgs e)
        {
            Game_Form gameForm = new Game_Form(30); // 30x30 board for easy difficulty
            gameForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game_Form gameForm = new Game_Form(5); // 5x5 board for super easy difficulty (demonstrate win condition)
            gameForm.Show();
        }
    }
}
