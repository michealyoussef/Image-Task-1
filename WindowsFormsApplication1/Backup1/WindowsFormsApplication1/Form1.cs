using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ImageController im = new ImageController();
        ImageController im2 = new ImageController();

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(textBox2.Text) == false)
            {
                im.Scale(int.Parse(textBox1.Text.ToString()), int.Parse(textBox2.Text.ToString()), pictureBox1.CreateGraphics());

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

                im.Rotate(int.Parse(textBox3.Text), pictureBox1.CreateGraphics());
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
                im.Shearing(int.Parse(textBox4.Text), int.Parse(textBox4.Text), pictureBox1.CreateGraphics());

            }
            else
            {
                MessageBox.Show("please fill text box", "Error");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.SelectedPath))
            {
                im.savingpicture(ofd.SelectedPath, im.ImageBitmap);
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
            numericUpDown1.Value = trackBar1.Value;
            pictureBox1.Image = im.Brightness(trackBar1.Value);
            Histogramdrawing his = new Histogramdrawing();
            his.drawing(new Bitmap(pictureBox1.Image));
          
            for (int w = 0; w < 256; w++)
            {
                chart1.Series["Red"].Points.AddXY(w, his.Rarray[w]);

                chart1.Series["Green"].Points.AddXY(w, his.Garray[w]);
                chart1.Series["Blue"].Points.AddXY(w, his.Garray[w]);

            }
            chart1.Series["Green"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Green"].Color = Color.Green;
            chart1.Series["Red"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Red"].Color = Color.Red;
            chart1.Series["Blue"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Blue"].Color = Color.Blue;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = decimal.ToInt32(numericUpDown1.Value);
            pictureBox1.Image = im.Brightness(trackBar1.Value);
            Histogramdrawing his = new Histogramdrawing();
            his.drawing(im.ImageBitmap);
            
            for (int w = 0; w < 256; w++)
            {
                chart1.Series["Red"].Points.AddXY(w, his.Rarray[w]);
                chart1.Series["Green"].Points.AddXY(w, his.Garray[w]);
                chart1.Series["Blue"].Points.AddXY(w, his.Garray[w]);

            }
            chart1.Series["Green"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Green"].Color = Color.Green;
            chart1.Series["Red"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Red"].Color = Color.Red;
            chart1.Series["Blue"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Blue"].Color = Color.Blue;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = decimal.ToInt32(numericUpDown1.Value);
            pictureBox1.Image = im.Brightness(Convert.ToInt32(numericUpDown2.Value));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            pictureBox1.Image = im.Brightness(trackBar2.Value);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            pictureBox1.Image = im.Flipping();
            im.ImageBitmap = im.Flipping();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Flippingvertical();
            im.ImageBitmap = im.Flippingvertical();

        }

        private void image1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            {
                pictureBox1.Image = im.Read(ofd.FileName);
                pictureBox1.Size = im.ImageBitmap.Size;
            }
            Histogramdrawing his = new Histogramdrawing();
            his.drawing(im.ImageBitmap);
            for (int w = 0; w < 256; w++)
            {
                chart1.Series["Red"].Points.AddXY(w, his.Rarray[w]);
                chart1.Series["Green"].Points.AddXY(w, his.Garray[w]);
                chart1.Series["Blue"].Points.AddXY(w, his.Garray[w]);

            }
            chart1.Series["Green"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Green"].Color = Color.Green;
            chart1.Series["Red"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Red"].Color = Color.Red;
            chart1.Series["Blue"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Blue"].Color = Color.Blue;
        }

        private void image2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            {
                pictureBox2.Image = im2.Read(ofd.FileName);
                pictureBox2.Size = im2.ImageBitmap.Size;
            }

        }

        private void subtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            resultform f = new resultform();
            f.Show();
            Bitmap x = im.subtraction(im2.ImageBitmap);
            f.draw(x);
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultform f = new resultform();
            f.Show();
            Bitmap x = im.addtion(im2.ImageBitmap, double.Parse(textBox6.Text.ToString()));
            f.draw(x);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numericUpDown3.Value = trackBar3.Value;
           // pictureBox1.Image = im.cont(-Convert.ToInt32(trackBar3.Value), Convert.ToInt32(trackBar3.Value));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = decimal.ToInt32(numericUpDown3.Value);
           pictureBox1.Image = im.cont(-Convert.ToInt32(numericUpDown3.Value),Convert.ToInt32(numericUpDown3.Value));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Bit_plane_slicing(int.Parse(textBox7.Text.ToString()),ch1.Checked, ch2.Checked, ch3.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Quantization(int.Parse(textBox8.Text.ToString()));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.cont(int.Parse(textBox9.Text.ToString()), int.Parse(textBox10.Text.ToString()));
        }


    }
}
