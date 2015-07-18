using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5SuperVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("Server.exe",textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string adr = "localhostDOS.exe";
                for (int i = 0; i < int.Parse(textBox3.Text); i++)//можно запустить несколько программ для большей амуляции процесса
                {
                    Process.Start(adr, textBox5.Text + " " + textBox6.Text + " " + textBox7.Text);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Запустите сервер или введите корректные данные");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
