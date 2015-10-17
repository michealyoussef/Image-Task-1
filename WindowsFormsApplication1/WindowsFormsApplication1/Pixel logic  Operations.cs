using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Pixel_logic__Operations
    {
        public Pixel_logic__Operations()
        {
        }
        public Bitmap Grayscale(Bitmap input)
        {
            int sum = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    sum = 0;
                    sum = input.GetPixel(j, i).R + input.GetPixel(j, i).G + input.GetPixel(j, i).B;
                    sum /= 3;
                    input.SetPixel(j, i, Color.FromArgb(sum, sum, sum));
                }
            }
            return input;
        }
        public Bitmap notoperation(Bitmap input)
        {
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    input.SetPixel(j, i, Color.FromArgb(255 - input.GetPixel(j, i).R, 255 - input.GetPixel(j, i).G, 255 - input.GetPixel(j, i).B));
                }
            }
            return input;
        }
    }
}
