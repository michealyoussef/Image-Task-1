﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ImageController[] image = new ImageController[15];
        TabPage[] tabpag = new TabPage[15];
        Histogramdrawing his;
        bufferedLockBitmap bf;
        WindowState win = new WindowState();
        PictureBox picbox;
        int dif = 0;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();


        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(textBox2.Text) == false)
            {
               // pictureBox1.Image = image[tabControl1.SelectedIndex].Scale(int.Parse(textBox1.Text.ToString()), int.Parse(textBox2.Text.ToString()));
            }
            else
            {
                MessageBox.Show("please fill text box", "Error");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == false)
            {

              //  image[tabControl1.SelectedIndex].all(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text), float.Parse(textBox4.Text), float.Parse(textBox5.Text), pictureBox1.CreateGraphics());
            }
            else
            {
                MessageBox.Show("please fill text box 3", "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == false)
            {
                Bitmap tmp = image[tabControl1.SelectedIndex].Rotate(int.Parse(textBox3.Text));
                picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                picbox.Image = tmp;
                tmp.Save("temp.bmp");
            }
            else
            {
                MessageBox.Show("please fill text box 3", "Error");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == false && string.IsNullOrEmpty(textBox5.Text) == false)
            {
                picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                picbox.Image = image[tabControl1.SelectedIndex].Shearing(int.Parse(textBox4.Text), int.Parse(textBox4.Text));

            }
            else
            {
                MessageBox.Show("please fill text box", "Error");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.SelectedPath))
            {
                image[tabControl1.SelectedIndex].savingpicture(ofd.SelectedPath);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Grayscale();
        }

        private void nOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].NOT();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = (trackBar1.Value);
            dif = trackBar1.Value - win.brigth;
            win.brigth = trackBar1.Value;
            bf = image[tabControl1.SelectedIndex].Brightness(dif);
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = bf.source2;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = decimal.ToInt32(numericUpDown1.Value);
            dif = trackBar1.Value - win.brigth;
            win.brigth = trackBar1.Value;
            bf = image[tabControl1.SelectedIndex].Brightness(dif);
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = bf.source2;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToInt32(numericUpDown2.Value);
            dif = trackBar2.Value - win.gamma;
            win.gamma = trackBar2.Value;
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Gamma(dif).source2;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            dif = trackBar2.Value - win.gamma;
            win.gamma = trackBar2.Value;
            bf = image[tabControl1.SelectedIndex].Gamma(dif);
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Gamma(dif).source2;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Flipping();
        }


        private void image1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void image2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            //{
            //    pictureBox2.Image = im2.Read(ofd.FileName);
            //    im2.ImageLockBitmap.UnlockBits();
            //    pictureBox2.Size = im2.ImageBitmap.Size;
            //}

        }

        private void subtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //im.ImageLockBitmap.LockBits();
            //im2.ImageLockBitmap.LockBits();
            //Bitmap x = im.subtraction(im2.ImageLockBitmap);
            //im.ImageLockBitmap.UnlockBits();
            //im2.ImageLockBitmap.UnlockBits();
            //resultform f = new resultform();
            //f.Show();
            //f.draw(x);
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resultform f = new resultform();
            //f.Show();
            //Bitmap x = im.addtion(im2.ImageLockBitmap, double.Parse(textBox6.Text.ToString()));
            //f.draw(x);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numericUpDown3.Value = trackBar3.Value;
            bf = image[tabControl1.SelectedIndex].cont(-trackBar3.Value, trackBar3.Value);

            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = bf.source2;
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = decimal.ToInt32(numericUpDown3.Value);
            bf = image[tabControl1.SelectedIndex].cont(-trackBar3.Value, trackBar3.Value);
            his.zeros();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = bf.source2;
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Bit_plane_slicing(int.Parse(textBox7.Text.ToString()), ch1.Checked, ch2.Checked, ch3.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {


        }


        private void laplasinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].laplacian().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void meanFilter1DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 inp = new Form2();
            inp.label1.Text = "Mask Size  ";
            inp.ShowDialog();
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].mean1D(Convert.ToInt32(inp.textBox1.Text)).source2;
            Benchmark.End();
            textBox1.Text = "";
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void meanFilter2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input();
            inp.ShowDialog();
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].meanfilter(Convert.ToInt32(inp.width), Convert.ToInt32(inp.heigth), Convert.ToInt32(inp.x), Convert.ToInt32(inp.y)).source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void sobelFilterslineDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image= image[tabControl1.SelectedIndex].line_detectionh().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void verticalLineDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].line_detectionv().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void sobelEdgeMagnitudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].EdgeMagnitude().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void gaussianoption1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input();
            foreach (Control x in inp.Controls)
            {
                x.Hide();
            }
            inp.label1.Text = "Mask Size  ";
            inp.label1.Show();
            inp.label2.Text = "Sigma";
            inp.label2.Show();
            inp.textBox1.Show();
            inp.textBox2.Show();
            inp.button1.Show();
            inp.ShowDialog();
            Benchmark.Start();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image  = image[tabControl1.SelectedIndex].Gus1(Convert.ToInt32(inp.heigth), inp.width).source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void gaussianOption2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.label1.Text = "Mask Size  ";
            fm2.ShowDialog();
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Gus2(Convert.ToDouble(fm2.textBox1.Text)).source2;
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.label1.Text = "Quantization";
            fm2.ShowDialog();
            int value = Convert.ToInt32(fm2.textBox1.Text);
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Quantization(value);
        }

        private void filpHorizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Flipping();
        }

        private void filpVerticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            picbox = (PictureBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            picbox.Image = image[tabControl1.SelectedIndex].Flippingvertical();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            win.rest();
            OpenFileDialog ofd = new OpenFileDialog();
            image[counter] = new ImageController();

            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            {
                Benchmark.Start();
                image[counter].Read(ofd.FileName);
                Benchmark.End();
                image[counter].ImageLockBitmap.UnlockBits();
                Benchmark.End();
                this.textBox1.Text = Benchmark.GetSeconds().ToString();
                tabpag[counter] = new TabPage();
                PictureBox p = new PictureBox();
                p.Size = new Size(580, 436);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Image = (image[counter].ImageLockBitmap.source2);
                tabpag[counter].Controls.Add(p);
                tabpag[counter].Text = image[counter].P3file.namefile;
                tabControl1.TabPages.Add(tabpag[counter]);
            }
            his = new Histogramdrawing();
            his.drawing(image[counter].ImageLockBitmap, chart1);
            tabControl1.SelectedIndex = counter;
            counter++;
            
        }
    }
}
