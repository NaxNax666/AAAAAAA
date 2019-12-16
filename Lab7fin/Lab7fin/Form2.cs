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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(DataBank.Player1.BDcount);
            textBox2.Text = Convert.ToString(DataBank.Player1.GDcount);
            textBox3.Text = Convert.ToString(DataBank.Player1.Scount);
            textBox4.Text = Convert.ToString(DataBank.Player2.BDcount);
            textBox5.Text = Convert.ToString(DataBank.Player2.GDcount);
            textBox6.Text = Convert.ToString(DataBank.Player2.Scount);
            DataBank.IsPlayer1Turn = true;
            DataBank.CurrentUnit = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataBank.IsPlayer1Turn)
            {
                richTextBox1.Text += DataBank.Player1.Attack(DataBank.CurrentUnit)+ "\r\n";
                Form3 Tar = new Form3();
                Tar.ShowDialog();
                DataBank.Player2.GetDamage(DataBank.Target, DataBank.CurrentUnit, DataBank.Player1);
                DataBank.IsPlayer1Turn = false;
                richTextBox1.Text += "После атаки в армии Игрока 2 осталось\r\n" +
                    "Костяных Драконов" + Convert.ToString(DataBank.Player2.BDcount) +
                    "\r\n Призрачных Драконов" + Convert.ToString(DataBank.Player2.GDcount) +
                    "\r\n Скелетов" + Convert.ToString(DataBank.Player2.Scount) +"\r\n";
                textBox4.Text = Convert.ToString(DataBank.Player2.BDcount);
                textBox5.Text = Convert.ToString(DataBank.Player2.GDcount);
                textBox6.Text = Convert.ToString(DataBank.Player2.Scount);
                if (!DataBank.Player2.IsArmyAlive())
                {
                    MessageBox.Show("Игрок 1 Победил");
                    this.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!DataBank.IsPlayer1Turn)
            {
                richTextBox1.Text+=DataBank.Player2.Attack(DataBank.CurrentUnit)+"\r\n";
                Form3 Tar = new Form3();
                Tar.ShowDialog();
                DataBank.Player1.GetDamage(DataBank.Target, DataBank.CurrentUnit, DataBank.Player2);
                DataBank.IsPlayer1Turn = true;
                richTextBox1.Text += "После атаки в армии Игрока 1 осталось\r\n" +
                    "Костяных Драконов" + Convert.ToString(DataBank.Player1.BDcount) +
                    "\r\n Призрачных Драконов" + Convert.ToString(DataBank.Player1.GDcount) +
                    "\r\n Скелетов" + Convert.ToString(DataBank.Player1.Scount) + "\r\n";
                DataBank.CurrentUnit++;
                DataBank.CurrentUnit%=3;
                textBox1.Text = Convert.ToString(DataBank.Player1.BDcount);
                textBox2.Text = Convert.ToString(DataBank.Player1.GDcount);
                textBox3.Text = Convert.ToString(DataBank.Player1.Scount);

                if (!DataBank.Player1.IsArmyAlive())
                {
                    MessageBox.Show("Игрок 2 Победил");
                    this.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBank.IsPlayer1Turn = !DataBank.IsPlayer1Turn;
            richTextBox1.Text += "Игрок Пропустил Ход \r\n";
            if (DataBank.IsPlayer1Turn)
            {
                DataBank.CurrentUnit++;
                DataBank.CurrentUnit %= 3;
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataBank.IsPlayer1Turn)
            {

                DataBank.Player1.Defence(DataBank.CurrentUnit);
                DataBank.IsPlayer1Turn = false;
              
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!DataBank.IsPlayer1Turn)
            {

                DataBank.Player2.Defence(DataBank.CurrentUnit);
                DataBank.IsPlayer1Turn = true;
                DataBank.CurrentUnit++;
                DataBank.CurrentUnit %= 3;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DataBank.IsPlayer1Turn)
            {
                
                Form3 Tar = new Form3();
                Tar.ShowDialog();
                Form4 Mag = new Form4();
                Mag.ShowDialog();
                DataBank.Player2.GetCast(DataBank.Target, DataBank.CurrentUnit, DataBank.Player1,DataBank.Cast);
                DataBank.IsPlayer1Turn = false;
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!DataBank.IsPlayer1Turn)
            {
                Form3 Tar = new Form3();
                Tar.ShowDialog();
                Form4 Mag = new Form4();
                Mag.ShowDialog();
                DataBank.Player1.GetCast(DataBank.Target, DataBank.CurrentUnit, DataBank.Player2, DataBank.Cast);
                DataBank.IsPlayer1Turn = true;
                DataBank.CurrentUnit++;
                DataBank.CurrentUnit %= 3;

            }
        }
    }
}
