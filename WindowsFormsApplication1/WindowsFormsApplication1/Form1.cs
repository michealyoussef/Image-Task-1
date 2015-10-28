using System;
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
        ImageController im = new ImageController();
        ImageController im2 = new ImageController();
        Histogramdrawing his;
        bufferedLockBitmap bf;
        WindowState win = new WindowState();
        int dif = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(textBox2.Text) == false)
            {
                pictureBox1.Image = im.Scale(int.Parse(textBox1.Text.ToString()), int.Parse(textBox2.Text.ToString()));

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

                im.all(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text), float.Parse(textBox4.Text), float.Parse(textBox5.Text), pictureBox1.CreateGraphics());
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
                Bitmap tmp = im.Rotate(int.Parse(textBox3.Text));
                pictureBox1.Image = tmp;
                pictureBox1.Size = tmp.Size;
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
                pictureBox1.Image = im.Shearing(int.Parse(textBox4.Text), int.Parse(textBox4.Text));

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
                im.savingpicture(ofd.SelectedPath);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = im.Grayscale();
        }

        private void nOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.NOT();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = (trackBar1.Value);
            dif = trackBar1.Value - win.brigth;
            win.brigth = trackBar1.Value;
            bf = im.Brightness(dif);
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
            pictureBox1.Image = bf.source2;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = decimal.ToInt32(numericUpDown1.Value);
            dif = trackBar1.Value - win.brigth;
            win.brigth = trackBar1.Value;
            bf = im.Brightness(dif);
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
            pictureBox1.Image = bf.source2;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToInt32(numericUpDown2.Value);
            dif = trackBar2.Value - win.gamma;
            win.gamma = trackBar2.Value;
            pictureBox1.Image = im.Gamma(dif).source2;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            dif = trackBar2.Value - win.gamma;
            win.gamma = trackBar2.Value;
            bf = im.Gamma(dif);
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
            pictureBox1.Image = im.Gamma(dif).source2;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Flipping();
        }


        private void image1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            win.rest();

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            {
                Benchmark.Start();
                pictureBox1.Image = im.Read(ofd.FileName);
                Benchmark.End();
                im.ImageLockBitmap.UnlockBits();
                Benchmark.End();
                this.textBox1.Text = Benchmark.GetSeconds().ToString();
                //   pictureBox1.Size = im.ImageBitmap.Size;
            }
            his = new Histogramdrawing();
            his.drawing(im.ImageLockBitmap, chart1);
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
            im.ImageLockBitmap.LockBits();
            im2.ImageLockBitmap.LockBits();
            Bitmap x = im.subtraction(im2.ImageLockBitmap);
            im.ImageLockBitmap.UnlockBits();
            im2.ImageLockBitmap.UnlockBits();
            resultform f = new resultform();
            f.Show();
            f.draw(x);
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultform f = new resultform();
            f.Show();
            Bitmap x = im.addtion(im2.ImageLockBitmap, double.Parse(textBox6.Text.ToString()));
            f.draw(x);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numericUpDown3.Value = trackBar3.Value;
            bf = im.cont(-trackBar3.Value, trackBar3.Value);

            pictureBox1.Image = bf.source2;
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = decimal.ToInt32(numericUpDown3.Value);
            bf = im.cont(-trackBar3.Value, trackBar3.Value);
            his.zeros();
            pictureBox1.Image = bf.source2;
            his = new Histogramdrawing();
            his.drawing(bf, chart1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Bit_plane_slicing(int.Parse(textBox7.Text.ToString()), ch1.Checked, ch2.Checked, ch3.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Quantization(int.Parse(textBox8.Text.ToString()));
        }


        private void laplasinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            pictureBox1.Image = im.laplacian().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void meanFilter1DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input();
            foreach (Control x in inp.Controls)
            {
                x.Hide();
            }
            inp.label1.Text = "Mask Size  ";
            inp.label1.Show();
            inp.textBox1.Show();
            inp.button1.Show();
            inp.ShowDialog();
            Benchmark.Start();
            pictureBox1.Image = im.mean1D(Convert.ToInt32(inp.heigth)).source2;
            Benchmark.End();
            textBox1.Text = "";
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void meanFilter2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input();
            inp.ShowDialog();
            Benchmark.Start();
            pictureBox1.Image = im.meanfilter(Convert.ToInt32(inp.width), Convert.ToInt32(inp.heigth), Convert.ToInt32(inp.x), Convert.ToInt32(inp.y)).source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void sobelFilterslineDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            pictureBox1.Image = im.line_detectionh().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void verticalLineDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            pictureBox1.Image = im.line_detectionv().source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void sobelEdgeMagnitudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benchmark.Start();
            pictureBox1.Image = im.EdgeMagnitude().source2;
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
            pictureBox1.Image = im.Gus1(Convert.ToInt32(inp.heigth), inp.width).source2;
            Benchmark.End();
            textBox1.Text = Benchmark.GetSeconds().ToString();
        }

        private void gaussianOption2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input();
            foreach (Control x in inp.Controls)
            {
                x.Hide();
            }
            inp.label1.Text = "Mask Size  ";
            inp.label1.Show();
            inp.textBox1.Show();

            inp.button1.Show();
            inp.ShowDialog();
            pictureBox1.Image = im.Gus2(inp.heigth).source2;
        }

        private void filpHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Flipping();

        }

        private void filpVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Flippingvertical();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
