using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7fin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.Player1 = new Army("Игрок 1",Convert.ToUInt32(numericUpDown1.Value), Convert.ToUInt32(numericUpDown2.Value), Convert.ToUInt32(numericUpDown3.Value));
            DataBank.Player2 = new Army("Игрок 2", Convert.ToUInt32(numericUpDown4.Value), Convert.ToUInt32(numericUpDown5.Value), Convert.ToUInt32(numericUpDown6.Value));
            Form2 battle = new Form2();
            battle.ShowDialog();
                    

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
