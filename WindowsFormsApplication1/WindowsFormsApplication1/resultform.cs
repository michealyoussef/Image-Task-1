using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class resultform : Form
    {
        public resultform()
        {
            InitializeComponent();
        }
        public void draw(Bitmap income)
        {
            this.pictureBox1.Size  = income.Size;
            pictureBox1.Image = income;
            this.Size= income.Size;          

        }
    }
}
