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
    public partial class input : Form
    {
        public int width;
        public int heigth;
        public int x;
        public int y;
        public input()
        {
            InitializeComponent();
        }

        private void Meanform_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.heigth = Convert.ToInt32(this.textBox1.Text);
            this.width = Convert.ToInt32(this.textBox2.Text);
            this.x = Convert.ToInt32(this.textBox3.Text);
            this.y = Convert.ToInt32(this.textBox4.Text);
        }
    }
}
