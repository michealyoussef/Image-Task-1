using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Pixel_logic__Operations
    {
        bufferedLockBitmap bf;
        Bitmap temp;
        byte[] Word;
        int maxR = 0, maxG = 0, maxb = 0;
        int minR = 1000, minG = 1000, minb = 1000;
        public Pixel_logic__Operations(bufferedLockBitmap input)
        {
            int te = 0;

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    te = input.Getpixel(j, i).R;
                    if (te > maxR) maxR = te;

                    te = input.Getpixel(j, i).G;
                    if (te > maxG) maxG = te;

                    te = input.Getpixel(j, i).B;
                    if (te > maxb) maxb = te;

                    te = input.Getpixel(j, i).R;
                    if (te < minR) minR = te;

                    te = input.Getpixel(j, i).G;
                    if (te < minG) minG = te;

                    te = input.Getpixel(j, i).B;
                    if (te < minb) minb = te;

                }
            }
            Word = new byte[8];
            Word[0] = 1;
            Word[1] = 2;
            Word[2] = 4;
            Word[3] = 8;
            Word[4] = 16;
            Word[5] = 32;
            Word[6] = 64;
            Word[7] = 128;
        }

        public Bitmap contrast(bufferedLockBitmap input, int x, int y)
        {

            int NewMinR = 0, NewMinG = 0, NewMinB = 0, NewMaxR = 0, NewMaxG = 0, NewMaxB = 0;
            temp = new Bitmap(input.Width, input.Height);
            int R, G, B;
            NewMinR = minR + x;
            NewMinG = minG + x;
            NewMinB = minb + x;

            NewMaxR = maxR + y;
            NewMaxB = maxb + y;
            NewMaxG = maxG + y;

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.Getpixel(j, i).R;
                    R = Convert.ToInt32(((double)(R - minR) / (maxR - minR)) * ((NewMaxR - NewMinR)) + NewMinR);
                    G = input.Getpixel(j, i).G;
                    G = Convert.ToInt32(((double)(G - minG) / (maxG - minG)) * ((NewMaxG - NewMinG)) + NewMinG);
                    B = input.Getpixel(j, i).B;
                    B = Convert.ToInt32(((double)(B - minb) / (maxb - minb)) * ((NewMaxB - NewMinB)) + NewMinB);

                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    input.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }

            return input.source2;
        }
        public Bitmap Bit_plane(bufferedLockBitmap input, int number, bool R, bool G, bool B)
        {
            temp = new Bitmap(input.source);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int p;
            int red = 0, blue = 0, green = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    if (R == true)
                    {
                        p = bf.Getpixel(j, i).R & Word[number - 1];
                        if (p != 0)
                            red = 255;
                        else if (p == 0)
                            red = 0;
                    }
                    if (G == true)
                    {
                        p = bf.Getpixel(j, i).G & Word[number - 1];
                        if (p != 0)
                            green = 255;
                        else if (p == 0)
                            green = 0;
                    }
                    if (B == true)
                    {
                        p = bf.Getpixel(j, i).B & Word[number - 1];
                        if (p != 0)
                            blue = 255;
                        else if (p == 0)
                            blue = 0;
                    }
                    bf.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            bf.UnlockBits();
            return bf.source2;
        }

        public Bitmap Brightness(bufferedLockBitmap input, int dif)
        {
            temp = new Bitmap(input.source);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int R, G, B = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.Getpixel(j, i).R + dif;
                    G = input.Getpixel(j, i).G + dif;
                    B = input.Getpixel(j, i).B + dif;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    bf.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            bf.UnlockBits();
            return bf.source2;
        }
        public void Grayscale(bufferedLockBitmap input)
        {
            temp = new Bitmap(input.Width, input.Height);
            int sum = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    sum = 0;
                    sum = input.Getpixel(j, i).R + input.Getpixel(j, i).G + input.Getpixel(j, i).B;
                    sum /= 3;
                    input.SetPixel(j, i, Color.FromArgb(sum, sum, sum));
                }

            }

        }
        public Bitmap Quantization(bufferedLockBitmap input, int num)
        {
            int sum = 0;
            double f = 2;
            int math = Convert.ToInt32(Math.Log(Convert.ToDouble(num), f));
            for (int w = 7; w > 7 - math; w--)
            {
                sum = sum + Convert.ToInt32(Math.Pow(f, Convert.ToInt32(w)));
            }
            temp = new Bitmap(input.Width, input.Height);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int R, G, B;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.Getpixel(j, i).R & sum;
                    G = input.Getpixel(j, i).G & sum;
                    B = input.Getpixel(j, i).B & sum;
                    bf.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            bf.UnlockBits();
            return bf.source2;

        }
        public void notoperation(bufferedLockBitmap input)
        {
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    input.SetPixel(j, i, Color.FromArgb(255 - input.Getpixel(j, i).R, 255 - input.Getpixel(j, i).G, 255 - input.Getpixel(j, i).B));
                }
            }

        }
        public void Gamma(bufferedLockBitmap input, double dif)
        {
            if (dif == 0)
                return;

            double R, G, B = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = double.Parse(Math.Pow(double.Parse(input.Getpixel(j, i).R.ToString()), dif).ToString());
                    G = double.Parse(Math.Pow(double.Parse(input.Getpixel(j, i).G.ToString()), dif).ToString());
                    B = double.Parse(Math.Pow(double.Parse(input.Getpixel(j, i).B.ToString()), dif).ToString());
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    input.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));
                }
            }

        }
        public Bitmap Addpictures(bufferedLockBitmap pic1, bufferedLockBitmap pic2, double fraction)
        {
            if (pic1.Width == pic2.Width && pic1.Height == pic2.Height)
            {
                temp = new Bitmap(pic1.Width, pic1.Height);
                bufferedLockBitmap r = new bufferedLockBitmap(temp);
                r.LockBits();
                int R, G, B = 0;
                double f;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        f = ((((double)pic1.Getpixel(j, i).R)) * fraction) + (((double)pic2.Getpixel(j, i).R) * (1 - fraction));
                        R = Convert.ToInt32(f);
                        f = ((((double)pic1.Getpixel(j, i).G)) * fraction) + (((double)pic2.Getpixel(j, i).G) * (1 - fraction));
                        G = Convert.ToInt32(f);
                        f = ((((double)pic1.Getpixel(j, i).B)) * fraction) + (((double)pic2.Getpixel(j, i).B) * (1 - fraction));
                        B = Convert.ToInt32(f);
                        r.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
                r.UnlockBits();
                return r.source2;

            }
            else
                MessageBox.Show("picture 1 size is equal to picture 2 size");
            return temp;
        }



        public Bitmap Subtraction(bufferedLockBitmap pic1, bufferedLockBitmap pic2)//////na2s el contrast
        {
            temp = new Bitmap(pic1.Width, pic1.Height);
            bufferedLockBitmap bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            if (pic1.Width == pic2.Width)
            {
                int R, G, B = 0;
                for (int i = 0; i < pic1.Height; i++)
                {
                    for (int j = 0; j < pic1.Width; j++)
                    {
                        R = pic1.Getpixel(j, i).R - pic2.Getpixel(j, i).R;
                        G = pic1.Getpixel(j, i).G - pic2.Getpixel(j, i).G;
                        B = pic1.Getpixel(j, i).B - pic2.Getpixel(j, i).B;
                        if (R < 0) R = 0;
                        if (G < 0) G = 0;
                        if (B < 0) B = 0;
                        bf.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            bf.UnlockBits();
            return bf.source2;
        }
    }
}