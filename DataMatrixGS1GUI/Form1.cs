using System;
using System.IO;
using System.Windows.Forms;

using DataMatrixGS1;

namespace DataMatrixGS1GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox4.Enabled = true;
            }
            else
            {
                this.textBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width = 0;
            int height = 0;
            try
            {
                width = Convert.ToInt32(this.textBox1.Text);
                height = Convert.ToInt32(this.textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Width and Height need to be a number > 100");
            }

            bool flag = true;
            if (width < 100 || height < 100)
            {
                flag = false;
                MessageBox.Show("Width and Height need to be a number > 100");
            }
            if (this.textBox3.Text.Length < 3)
            {
                flag = false;
                MessageBox.Show("Content field needs to be populated.");
            }
            if (this.checkBox1.Checked && this.textBox4.Text.Length < 1)
            {
                flag = false;
                MessageBox.Show("File name needs to be populated.");
            }
            if (flag)
            {
                this.pictureBox1.Image = DataMatrixGS1.DataMatrixGS1.generateDataMatrix(this.textBox3.Text, width, height);
            }

            if (flag && this.checkBox1.Checked)
            {
                Directory.CreateDirectory(".\\Output\\");
                DataMatrixGS1.DataMatrixGS1.generateDataMatrix(this.textBox3.Text, width, height, ".\\Output\\" + this.textBox4.Text + ".PNG");
            }
        }
    }
}
