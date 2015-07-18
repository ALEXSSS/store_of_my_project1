using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        Bitmap BMP;
        public static bool worker;
        public Form1()
        {
            worker = false;
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*BMP)|*.BMP;*.bmp;";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                BMP = new Bitmap(open_dialog.FileName);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = BMP;
                pictureBox1.Invalidate();
                pictureBox2.Image = BMP;
                pictureBox2.Invalidate();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "1)Medium filtr.\n" +
            "2)Convolution.\n" +
            "3)Filtr Gaussa blur\n" +
            "4)Filtr Sobel to x\n" +
            "5)Filtr Sobel to y\n" +
            "6)Filtr Gaussa to x\n" +
            "7)Filtr Gaussa to y\n" +
              "Other filtrs for large objects\n" +
            "8)Happy\n" +
            "9)Pasta\n" +
            "10)Color filtr\n" +
            "11)Filtr Sobel to x and y (sunny)\n" +
            "12)Filtr Gaussa to x and y\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (worker == true)
            {
                MessageBox.Show("Идёт обработка изображения");
            }
            else
            {
                Exception ex = new Exception();
                try
                {
                    if (int.Parse(textBox1.Text) <= 12)
                    {
                        ex = null;
                        BMPCreate create = new BMPCreate(BMP, int.Parse(textBox1.Text));
                        FilterWorker mt = new FilterWorker(create.BMP, create.num_filtr, pictureBox2, progressBar1);
                        Thread mythread = new Thread(mt.FilterWork);
                        worker = true;
                        mythread.Start();
                    }
                    else
                    {
                        throw ex;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Повторите ввод данных");
                    textBox1.Text = "";
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog();
            SF.Title = "Сохранить картинку как...";
            SF.OverwritePrompt = true;
            SF.CheckPathExists = true;
            SF.Filter = "Image Files(*BMP)|*.BMP;*.bmp;";
            SF.ShowHelp = true;
            if(SF.ShowDialog()==DialogResult.OK)
            {
                pictureBox2.Image.Save(SF.FileName);
            }
        }
    }
}
