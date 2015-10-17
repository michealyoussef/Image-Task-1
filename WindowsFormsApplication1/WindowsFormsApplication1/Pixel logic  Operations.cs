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

                    R = int.Parse(Math.Pow(double.Parse(input.GetPixel(j, i).R.ToString()), dif).ToString());
                    G = int.Parse(Math.Pow(double.Parse(input.GetPixel(j, i).G.ToString()), dif).ToString());
                    B = int.Parse(Math.Pow(double.Parse(input.GetPixel(j, i).B.ToString()), dif).ToString());

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
        public Bitmap Addpictures(Bitmap pic1, Bitmap pic2, Double fraction)
        {
            if (pic1.Size == pic2.Size)
            {
                Bitmap temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                double f;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {

                        f = (double.Parse(pic1.GetPixel(j, i).R.ToString()) * fraction) + (double.Parse(pic2.GetPixel(j, i).R.ToString()) * (1 - fraction));
                        R = Int32.Parse(f.ToString());
                        f = (double.Parse(pic1.GetPixel(j, i).G.ToString()) * fraction) + (double.Parse(pic2.GetPixel(j, i).G.ToString()) * (1 - fraction));
                        G = Int32.Parse(f.ToString());
                        f = (double.Parse(pic1.GetPixel(j, i).B.ToString()) * fraction) + (double.Parse(pic2.GetPixel(j, i).B.ToString()) * (1 - fraction));
                        B = Int32.Parse(f.ToString());
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }

            }
            return temp;
        }

        public Bitmap OR(Bitmap pic1, Bitmap pic2)//////na2s el contrast
        {
            if (pic1.Size == pic2.Size)
            {
                Bitmap temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        R = pic1.GetPixel(j, i).R | pic2.GetPixel(j, i).R;
                        G = pic1.GetPixel(j, i).G | pic2.GetPixel(j, i).G;
                        B = pic1.GetPixel(j, i).B | pic2.GetPixel(j, i).B;
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            return temp;
        }
        public Bitmap AND(Bitmap pic1, Bitmap pic2)//////na2s el contrast
        {
            if (pic1.Size == pic2.Size)
            {
                Bitmap temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        R = pic1.GetPixel(j, i).R & pic2.GetPixel(j, i).R;
                        G = pic1.GetPixel(j, i).G & pic2.GetPixel(j, i).G;
                        B = pic1.GetPixel(j, i).B & pic2.GetPixel(j, i).B;
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            return temp;
        }


        public Bitmap Subtraction(Bitmap pic1, Bitmap pic2)//////na2s el contrast
        {
            if (pic1.Size == pic2.Size)
            {
                temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        R = pic1.GetPixel(j, i).R - pic2.GetPixel(j, i).R;
                        G = pic1.GetPixel(j, i).G + pic2.GetPixel(j, i).G;
                        B = pic1.GetPixel(j, i).B + pic2.GetPixel(j, i).B;
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            return temp;
        }

    }
}