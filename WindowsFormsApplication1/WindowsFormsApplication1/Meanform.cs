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
        public double width;
        public double heigth;
        public double x;
        public double y;
        public input()
        {
            InitializeComponent();
        }

        private void Meanform_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Visible == true)
            {
                this.heigth = Convert.ToDouble(this.textBox1.Text);
            }
            if (this.textBox2.Visible == true)
                this.width = Convert.ToDouble(this.textBox2.Text);
            if (this.textBox3.Visible == true)
                this.x = Convert.ToDouble(this.textBox3.Text);
            if (this.textBox4.Visible == true)
                this.y = Convert.ToDouble(this.textBox4.Text);
            this.Close();
        }
    }
}
