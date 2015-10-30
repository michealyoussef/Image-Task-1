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
    public partial class Adjustment : Form
    {
        bufferedLockBitmap selectedimage;
        Pixel_logic__Operations op;
        public Adjustment()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void setbt(Bitmap input)
        {
            this.selectedimage = new bufferedLockBitmap(input);
            pictureBox1.Image = input;
            pictureBox2.Image = input;
            this.selectedimage.LockBits();
            this.selectedimage.UnlockBits();
            op = new Pixel_logic__Operations(selectedimage);
        }
        public Bitmap getbt()
        {
            return this.selectedimage.source;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            pictureBox2.Image = op.Brightness(this.selectedimage, trackBar1.Value).source;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(numericUpDown1.Value);
            pictureBox2.Image = op.Brightness(this.selectedimage, trackBar1.Value).source;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToInt32(numericUpDown2.Value);
            pictureBox2.Image = op.Gamma(this.selectedimage, trackBar2.Value).source;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = Convert.ToInt32(numericUpDown3.Value);
            pictureBox2.Image = op.contrast(this.selectedimage, -trackBar3.Value, trackBar3.Value).source;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            trackBar3.Value = Convert.ToInt32(numericUpDown3.Value);
            pictureBox2.Image = op.contrast(this.selectedimage, -trackBar3.Value, trackBar3.Value).source;
        }
    }
}
