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
        Bitmap temp;
        public Pixel_logic__Operations()
        {
        }
        public Bitmap Brightness(Bitmap input, int dif)
        {
            temp = new Bitmap(input);
            int R, G, B = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    R = input.GetPixel(j, i).R + dif;
                    G = input.GetPixel(j, i).G + dif;
                    B = input.GetPixel(j, i).B + dif;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return temp;

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
        public Bitmap Gamma(Bitmap input, int dif)
        {
            temp = new Bitmap(input);
            int R, G, B = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    R = input.GetPixel(j, i).R + dif;
                    G = input.GetPixel(j, i).G + dif;
                    B = input.GetPixel(j, i).B + dif;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return temp;
        }
        public Bitmap

    }
}
