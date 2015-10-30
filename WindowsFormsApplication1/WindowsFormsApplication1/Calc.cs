using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Calc : Form
    {
        ImageController[] image;
        public Calc()
        {
            InitializeComponent();
            comboBox3.Items.Add("Addition");
            comboBox3.Items.Add("Subtraction");


        }
        public void getarrayimages(ImageController[] source, int count)
        {
            image = source;
            for (int w = 0; w < count; w++)
            {
                comboBox1.Items.Add(image[w].PP36File.namefile);
                comboBox2.Items.Add(image[w].PP36File.namefile);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = image[comboBox1.SelectedIndex].ImageLockBitmap.source;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = image[comboBox2.SelectedIndex].ImageLockBitmap.source;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Subtraction")
            {
                pictureBox3.Image = image[comboBox1.SelectedIndex].subtraction(image[comboBox2.SelectedIndex].ImageLockBitmap);
            }
        }
    }
}
